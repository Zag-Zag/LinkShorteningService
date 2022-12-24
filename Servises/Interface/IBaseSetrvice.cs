using AbstractDependencies.Models;

namespace Servises.Interface;

public interface IBaseSetrvice<T>
    where T : IBusinessModel
{
    public IList<T> GetModels();
    public Task<IList<T>> GetModelsAsync();
    public Task<T> GetModelAsync();
    public void SaveToRepo(T model);
    public Task SaveToRepoAsync(T model);
}