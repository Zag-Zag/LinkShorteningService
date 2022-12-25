using AbstractDependencies.DiConfig;
using Repository;

namespace LinkShorteningService.DiConfig;

public class AutomapperModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) => 
        services
            .AddAutoMapper(typeof(LinkStatisticProfile))
            .AddAutoMapper(typeof(LinkStorageProfile))
            .AddAutoMapper(typeof(StatisticsPropertyProfile));
}
