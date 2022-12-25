using AutoMapper;
using DataBaseEf.Model;
using Repository.Model;

namespace Repository;

public class LinkStorageProfile : Profile
{
    public LinkStorageProfile() 
    {
        CreateMap<LinkStorage, LinkStorageBaseModel>();
        CreateMap<LinkStorageBaseModel, LinkStorage>();
    }
}
