using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Mapping;

public class CardLinkProfile : Profile
{
    public CardLinkProfile()
    {
        CreateMap<CardLink, CardLinkDto>().ReverseMap();
    }
}