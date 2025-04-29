using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Service.Interfaces;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public void DeleteUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> AddUser(UserDto user)
    {
        throw new NotImplementedException();
    }
}