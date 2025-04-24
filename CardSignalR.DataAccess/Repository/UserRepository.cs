using System.Security.Cryptography;
using System.Text;
using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }

    public async Task<User> CreateUserAsync(User user, string password)
    {
        if (await UserExistsAsync(user.Name, user.Surname))
            throw new UserAreAlreadyExistException("User with the same name and surname are already exists");

        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public Task<User> AuthenticateAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UserExistsAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id) ?? throw new UserNotFoundException("User is not exist!");
    }

    public async Task<bool> UserExistsAsync(string name, string surname)
    {
        return await _context.Users.AnyAsync(x => x.Name == name && x.Surname == surname);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }
    
    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}