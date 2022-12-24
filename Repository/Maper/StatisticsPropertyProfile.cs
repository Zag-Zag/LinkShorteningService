using AutoMapper;
using DataBaseEf.Model;
using Repository.Model;

namespace Repository;

internal class StatisticsPropertyProfile : Profile
{
    public StatisticsPropertyProfile() 
    {
        CreateMap<StatisticsProperty, StatisticsPropertyBaseModel>();
        CreateMap<StatisticsPropertyBaseModel, StatisticsProperty>();
    }
}
