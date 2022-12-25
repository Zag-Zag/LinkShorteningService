using AbstractDependencies.DiConfig;
using Repository;

namespace LinkShorteningService.DiConfig;

internal class AutomapperModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services
            .AddAutoMapper(typeof(LinkStorageProfile));
}
