using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardSignal.Api.Controllers;

[ApiController]
[Route("api/auth")]
[Produces("application/json")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(string),StatusCodes.Status200OK)]
    public async Task<IActionResult> SignIn([FromBody] AuthDto authDto)
    {
        var token = await _authService.SignInAsync(authDto);
        return Ok(new { token });
    }    
}