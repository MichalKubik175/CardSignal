using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Mapping;

public class OfficeProfile : Profile
{
    public OfficeProfile()
    {
        CreateMap<Office, OfficeDto>().ReverseMap();;
    }
}