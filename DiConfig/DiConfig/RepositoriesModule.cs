
using AbstractDependencies.DiConfig;
using LinkShorteningService.Extension;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface.Repositoryes;

namespace LinkShorteningService.DiConfig;

public class RepositoriesModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services.AddTransientDeligate<IRepositoryLinkStorage, RepositoryLinkStorage>();
}
