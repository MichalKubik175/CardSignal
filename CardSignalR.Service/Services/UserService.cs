using CardSignalR.DataAccess.Repository;
using CardSignalR.Service.Interfaces;
using CardSignalR.Service.Models;

namespace CardSignalR.Service.Services;

public class UserService : IUserService
{
    private readonly DataBaseContext _context;

    public UserService(DataBaseContext context)
    {
        _context = context;
    }

    public void AddUser(UserModel userModel)
    {
        throw new NotImplementedException();
    }
}