using CardSignal.Application.Dto;
using CardSignal.Core.Entities;

namespace CardSignal.Application.Interfaces;

public interface IAuthService
{
    Task<string> SignInAsync(AuthDto authDto);
}