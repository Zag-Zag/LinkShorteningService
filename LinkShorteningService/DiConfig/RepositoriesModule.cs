
using AbstractDependencies.DiConfig;
using Repository;
using Repository.Interface.Repositoryes;

namespace LinkShorteningService.DiConfig;

internal class RepositoriesModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services.AddScoped<IRepositoryLinkStorage, RepositoryLinkStorage>();
}
