using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardSignal.Api.Controllers;

[ApiController]
[Route("api/users")]
[Produces("application/json")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet]
    [ProducesResponseType(typeof(List<User>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(List<UserDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
    {
        var users = await _userService.AddUser(userDto);
        return Ok(users);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        await _userService.DeleteUser(id);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUser([FromRoute] UserDto userDto)
    {
        await _userService.UpdateUser(userDto);
        return NoContent();
    }
}