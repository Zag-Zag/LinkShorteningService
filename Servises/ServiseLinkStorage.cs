using AbstractDependencies.Models;
using Repository.Interface.Repositoryes;
using Repository.Model;
using Servises.Interface;

namespace Servises;

public class ServiseLinkStorage : IServiseLinkStorage
{

    private readonly Func<IRepositoryLinkStorage> _createrMinRepo;

    public ServiseLinkStorage(Func<IRepositoryLinkStorage> repoCreater) => _createrMinRepo = repoCreater;

    public Task<LinkStorageBaseModel> GetModelAsync()
    {
        throw new NotImplementedException();
    }

    public IList<LinkStorageBaseModel> GetModels()
    {
        using var repo = _createrMinRepo();
        return repo.GetModels();
    }

    public Task<IList<LinkStorageBaseModel>> GetModelsAsync()
    {
        throw new NotImplementedException();
    }

    public void SaveToRepo(LinkStorageBaseModel model)
    {
        using var repo = _createrMinRepo();
        repo.Save(new LinkStorageBaseModel() {LinkKey = "text", LinkValue = "Text" });
    }

    public Task SaveToRepoAsync(LinkStorageBaseModel model)
    {
        throw new NotImplementedException();
    }
}
