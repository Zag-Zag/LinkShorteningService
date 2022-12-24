
using AbstractDependencies.Models;
using DataBaseEf.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace DataBaseEf.Repository;

public abstract class BaseRepository<TEntity> : MinRepository
    where TEntity : BaseEntityModel
{
    private Action<Exception> _exceptionHandler = exception => throw exception;
    protected DbSet<TEntity> ContextDb => ContextDb<TEntity>();
    private readonly List<Expression<Func<TEntity, object>>> _ignores = new();
    
    public BaseRepository(DbContext context) : base(context) => Initialization();

    private BaseRepository<TEntity> AddToContext(TEntity entity)
    {
        ContextDb.Add(entity);
        return this;
    }
    private async Task<BaseRepository<TEntity>> AddToContextAcync(TEntity entity)
    {
        await ContextDb.AddAsync(entity);
        return this;
    }
    private EntityEntry<TEntity> GetEntityEntry(TEntity entity) => ContextDb.Entry(entity);

    private EntityEntry<TEntity> UpdateToContext(TEntity entity)
    {
        var localEntity = GetLocalModel(entity.Id);

        if (!localEntity.Any())
        {
            return ContextDb.Update(entity);
        }
        return UpdateLocalData(localEntity.FirstOrDefault());

    }
    private async Task<EntityEntry<TEntity>> UpdateToContextAsync(TEntity entity)
    {
        var localEntity = GetLocalModel(entity.Id);

        if (! await localEntity.AnyAsync())
        {
            return ContextDb.Update(entity);
        }
        return GetEntityEntry(await localEntity.FirstOrDefaultAsync());
    }
    private EntityEntry<TEntity> UpdateLocalData(TEntity entity)
    {
        GetEntityEntry(entity).State = EntityState.Detached;
        var entityEntry = GetEntityEntry(entity);
        entityEntry.State = EntityState.Modified;
        return entityEntry;
    }
    private IEnumerable<TEntity> GetLocalModel(Guid id) => ContextDb
        .Local
        .Where(e => e.Id.Equals(id));

    private BaseRepository<TEntity> SetToContext(TEntity entity)
    {
        if (IsANewEntity(entity))
        {
            AddToContext(entity);
        }
        else
        {
            UpdateToContext(entity)
                .AddIgnoreProps(_ignores);
        }
        return this;
    }
    private async Task<BaseRepository<TEntity>> SetToContextAsync(TEntity entity)
    {
        if (await IsANewEntityAsync(entity))
        {
            await AddToContextAcync(entity);
        }
        else
        {
            (await UpdateToContextAsync(entity))
                .AddIgnoreProps(_ignores);
        }
        return this;
    }

    private bool Validation(TEntity entity)
    {
        var result = ValidationEntityModel(entity);
        if (result.Error)
        {
            _exceptionHandler(new(result.Message));
        }
        return !result.Error;

    }


    #region IQueryable
    protected IQueryable<TEntity> GetQueryables() => ContextDb<TEntity>();
    protected IQueryable<TEntity> GetQueryables(Expression<Func<TEntity, bool>> condition) => GetQueryables<TEntity>().Where(condition);
    #endregion

    protected virtual BaseRepository<TEntity> Initialization() => this;
    protected virtual bool IsANewEntity(TEntity entity) => entity.Id.Equals(Guid.Empty);
    protected virtual async Task<bool> IsANewEntityAsync(TEntity entity) => await Task.Run(() => IsANewEntity(entity));

    // TODO: MSG to constant!
    protected virtual ResultModel ValidationEntityModel(TEntity entity) => new(entity == default ? "No values save" : string.Empty);

    public void ClearIgnore()
    {
        _ignores.Clear();
        _ignores.TrimExcess();
    }
    public void AddIgnore(Expression<Func<TEntity, object>> ignore) => _ignores.Add(ignore);
    public void SetExceptionHandler(Action<Exception> exceptionHandler) => _exceptionHandler = exceptionHandler;
    
    public void Save(TEntity entity)
    {
        if (Validation(entity))
        {
            SetToContext(entity)
                .SaveChanges();
        }
    }
    public async Task SaveAsync(TEntity entity)
    {
        if (Validation(entity))
        {
            await SetToContextAsync(entity);
            await SaveChangesAsync();
        }
    }
}
