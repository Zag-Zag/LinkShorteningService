
using AbstractDependencies.DiConfig;

namespace LinkShorteningService.Extension;

public static class ExtensionIServiceCollection
{
    internal static IServiceCollection AddTransientDeligate<Interface, Realisation>(this IServiceCollection services)
        where Realisation : class, Interface
        where Interface : class =>
            services.AddTransient<Interface, Realisation>()
                .AddTransient(Func<Interface> (servicesProvider) => () => servicesProvider.GetRequiredService<Interface>());
    public static IServiceCollection AddModule<TModule>(this IServiceCollection services)
        where TModule : IDiModule, new() => new TModule().Registration(services);
}
