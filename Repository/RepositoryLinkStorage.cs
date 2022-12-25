using AutoMapper;
using DataBaseEf.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Interface.Repositoryes;
using Repository.Model;

namespace Repository;

public class RepositoryLinkStorage: Repository<LinkStorage, LinkStorageBaseModel>, IRepositoryLinkStorage
{
    public RepositoryLinkStorage(DbContext context, IMapper mapper) : base(context, mapper) { }
}
