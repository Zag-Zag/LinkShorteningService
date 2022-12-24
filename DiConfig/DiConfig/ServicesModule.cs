
using AbstractDependencies.DiConfig;
using Microsoft.Extensions.DependencyInjection;
using Servises;
using Servises.Interface;

namespace LinkShorteningService.DiConfig;

public class ServicesModule : IDiModule
{
    public IServiceCollection Registration(IServiceCollection services) =>
        services.AddScoped<IServiseLinkStorage, ServiseLinkStorage>();
}
