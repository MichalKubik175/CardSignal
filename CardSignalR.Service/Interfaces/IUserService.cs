using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface IUserService
{
    public Task<User> AddUser(UserDto user );
    public void DeleteUser(UserDto user);
    public Task<User> UpdateUser(UserDto user);
    public Task<IEnumerable<User>> GetAllUsers();
}