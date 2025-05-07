using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    void AddUser(User user, string password);
    Task<User> AuthenticateAsync(string username, string password);
    Task<User> GetUserByIdAsync(Guid id);
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> UserExistsAsync(string username);
    Task<bool> UserExistsAsync(string name, string surname);
    bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
}