using CardSignalR.DataAccess.Entities;

namespace CardSignalR.DataAccess.Interface;

public interface IUserRepository
{
    Task<User> CreateUserAsync(User user, string password);
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> GetUserByIdAsync(Guid id);
    Task<bool> UserExistsAsync(string username);
}