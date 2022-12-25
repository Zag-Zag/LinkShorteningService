
using AbstractDependencies.DiConfig;
using LinkShorteningService.Extension;

namespace LinkShorteningService.DiConfig;

public class DiModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services
            .AddModule<RepositoriesModule>()
            .AddModule<ServicesModule>()
            .AddModule<AutomapperModule>();
}
