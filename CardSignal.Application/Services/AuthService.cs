using AutoMapper;
using CardSignal.Application.Interfaces;
using CardSignal.Application.Options;
using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using Kirpichyov.FriendlyJwt;
using Microsoft.Extensions.Options;

namespace CardSignal.Application.Services;

public class AuthService : IAuthService
{
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public readonly IUserRepository _userRepository;
    
    public AuthService(
        IOptions<JwtSettings> jwtSettings, 
        IMapper mapper,
        IUserService userService, IUserRepository userRepository)
    {
        _jwtSettings = jwtSettings;
        _userService = userService;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    
    private string GenerateToken(User user)
    {
        var generatedTokenInfo = new JwtTokenBuilder(_jwtSettings.Value.LifeTime, 
                _jwtSettings.Value.Secret)
            .WithUserIdPayloadData(user.Id.ToString())
            .WithAudience(_jwtSettings.Value.Audience)
            .WithIssuer(_jwtSettings.Value.Issuer)
            .WithUserRolePayloadData(user.Role.ToString())
            .Build();

        return generatedTokenInfo.Token;
    }

    public async Task<string> SignInAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        if (!_userRepository.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            throw new AuthFailedException("Email or password is incorrect");
        }

        return GenerateToken(user);
    }
}