using CardSignalR.Service.Models;

namespace CardSignalR.Service.Interfaces;

public interface IUserService
{
    public void AddUser(UserModel user );
}