
using AbstractDependencies.DiConfig;
using DataBaseEf;
using LinkShorteningService.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShorteningService.DiConfig
{
    public class DiModule : IDiModule
    {
        public IServiceCollection Registration(IServiceCollection services) =>
            services
                .AddModule<RepositoriesModule>()
                .AddModule<ServicesModule>()
                .AddModule<DbContextModule>();
    }
}
