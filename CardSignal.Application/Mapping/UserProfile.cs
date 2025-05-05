using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}