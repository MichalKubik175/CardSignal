using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface IUserService
{
    public Task<UserDto> AddUser(UserDto user );
    public void DeleteUser(UserDto user);
    public Task<UserDto> UpdateUser(UserDto user);
    public Task<UserDto> GetUserByEmail(string email);
    public Task<List<UserDto>> GetAllUsers();
    public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
}