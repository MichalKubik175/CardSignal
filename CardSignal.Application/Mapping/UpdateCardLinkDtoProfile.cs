using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Mapping;

public sealed class UpdateCardLinkDtoProfile : Profile
{
    public UpdateCardLinkDtoProfile()
    {
        CreateMap<UpdateCardLinkDto, CardLink>();
    }
}