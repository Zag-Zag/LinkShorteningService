using Microsoft.Extensions.DependencyInjection;

namespace AbstractDependencies.DiConfig;

public interface IDiModule
{
    public IServiceCollection Registration(IServiceCollection services);
}
