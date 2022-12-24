
using AbstractDependencies.DiConfig;
using Servises;
using Servises.Interface;

namespace LinkShorteningService.DiConfig;

public class ServicesModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services.AddScoped<IServiseLinkStorage, ServiseLinkStorage>();
}
