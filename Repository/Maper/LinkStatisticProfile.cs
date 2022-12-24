using AutoMapper;
using DataBaseEf.Model;
using Repository.Model;

namespace Repository;

internal class LinkStatisticProfile : Profile
{
    public LinkStatisticProfile() 
    {
        CreateMap<LinkStatistic, LinkStatisticBaseModel>();
        CreateMap<LinkStatisticBaseModel, LinkStatistic>();
    }
}
