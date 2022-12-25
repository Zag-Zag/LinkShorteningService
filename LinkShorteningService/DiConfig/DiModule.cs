
using AbstractDependencies.DiConfig;
using LinkShorteningService.Extension;

namespace LinkShorteningService.DiConfig;

internal class DiModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services
            .AddModule<RepositoriesModule>()
            .AddModule<ServicesModule>()
            .AddModule<AutomapperModule>();
}
