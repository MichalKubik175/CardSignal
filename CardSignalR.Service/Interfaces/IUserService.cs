using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface IUserService
{
    public void AddUser(UserDto user );
}