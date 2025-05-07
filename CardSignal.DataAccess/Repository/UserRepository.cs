using System.Security.Cryptography;
using System.Text;
using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }

    public void AddUser(User user, string password)
    {
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.Users.Add(user);
    }

    public Task<User> AuthenticateAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email)
               ?? throw new UserNotFoundException($"User with provided {email} is not exist!");
    }

    public Task<bool> UserExistsAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id) ?? throw new UserNotFoundException("User is not exist!");
    }
    
    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
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
    
    public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}