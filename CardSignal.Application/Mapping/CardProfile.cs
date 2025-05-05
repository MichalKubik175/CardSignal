using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Mapping;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<Card, CardDto>().ReverseMap();
    }
}