using Microsoft.Extensions.DependencyInjection;

namespace AbstractDependencies.DiConfig;

public interface IDiModule
{
    IServiceCollection Registration(IServiceCollection services);
}
