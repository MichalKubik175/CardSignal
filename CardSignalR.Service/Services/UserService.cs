using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Service.Interfaces;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public void DeleteUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        IEnumerable<User> users = await _userRepository.GetAllUsers();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> CreateUser(UserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        user = await _userRepository.CreateUserAsync(user, userDto.Password);
        
        return _mapper.Map<UserDto>(user);
    }
}