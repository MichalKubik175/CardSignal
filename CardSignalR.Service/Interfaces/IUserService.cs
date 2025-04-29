using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface IUserService
{
    public Task<UserDto> AddUser(UserDto user );
    public void DeleteUser(UserDto user);
    public Task<UserDto> UpdateUser(UserDto user);
    public Task<IEnumerable<UserDto>> GetAllUsers();
}