using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Mapping;

public class OfficeProfile : Profile
{
    public OfficeProfile()
    {
        CreateMap<Office, OfficeDto>().ReverseMap();;
    }
}