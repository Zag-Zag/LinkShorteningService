using AutoMapper;
using DataBaseEf.Model;
using Repository.Model;

namespace Repository;

public class LinkStatisticProfile : Profile
{
    public LinkStatisticProfile() 
    {
        CreateMap<LinkStatistic, LinkStatisticBaseModel>();
        CreateMap<LinkStatisticBaseModel, LinkStatistic>();
    }
}
