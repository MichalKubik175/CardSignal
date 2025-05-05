using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Mapping;

public class CardLinkProfile : Profile
{
    public CardLinkProfile()
    {
        CreateMap<CardLink, CardLinkDto>().ReverseMap();
    }
}