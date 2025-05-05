using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    void AddUser(User user, string password);
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> GetUserByIdAsync(Guid id);
    Task<bool> UserExistsAsync(string username);
    Task<bool> UserExistsAsync(string name, string surname);
}