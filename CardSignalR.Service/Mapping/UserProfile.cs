using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}