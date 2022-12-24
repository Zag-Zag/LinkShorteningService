
using AbstractDependencies.DiConfig;
using DataBaseEf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LinkShorteningService.DiConfig
{
    public class DbContextModule : IDiModule
    {
        public IServiceCollection Registration(IServiceCollection services) =>
            services
                 .AddDbContext<DbContext, ContextEf>(
                    options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LinkShorteningDB;Trusted_Connection=True;"));
    }
}
