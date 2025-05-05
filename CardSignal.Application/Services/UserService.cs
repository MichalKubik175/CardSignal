using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using CardSignal.DataAccess.Repository;

namespace CardSignal.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly DataBaseContext _dataBaseContext;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper,
        DataBaseContext dataBaseContext)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _dataBaseContext = dataBaseContext;
    }
    
    public void DeleteUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserDto>> GetAllUsers()
    {
        List<User> users = await _userRepository.GetAllUsers();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> AddUser(UserDto userDto)
    {
        if (await _userRepository.UserExistsAsync(userDto.Name, userDto.Surname))
            throw new UserAreAlreadyExistException("User with the same name and surname are already exists");
        
        User user = _mapper.Map<User>(userDto);
        _userRepository.AddUser(user, userDto.Password);
        await _dataBaseContext.SaveChangesAsync();
        
        return _mapper.Map<UserDto>(user);
    }
}