using AutoMapper;

namespace Repository;

internal static class Automapper
{
    internal static Mapper Mapper { get; } = new(new MapperConfiguration(cfg =>
    {
        cfg.AddProfiles(new Profile[]
        {
            new LinkStatisticProfile(),
            new LinkStorageProfile(),
            new StatisticsPropertyProfile()
        });
    }));

}
