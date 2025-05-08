using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardSignal.Api.Controllers;

[ApiController]
[Route("api/offices")]
[Produces("application/json")]
public class OfficeController : Controller
{
    private readonly IOfficeService _officeService;

    public OfficeController(IOfficeService officeService)
    {
        _officeService = officeService;
    }
    
    [Authorize(Roles = "User, Admin")]
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(OfficeDto),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOffice([FromRoute] string name)
    {
        var officeDto = await _officeService.GetOffice(name);
        return Ok(officeDto);
    }
    
    [Authorize(Roles = "User, Admin")]
    [HttpGet]
    [ProducesResponseType(typeof(List<OfficeDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOffices()
    {
        var offices = await _officeService.GetOffices();
        return Ok(offices);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(typeof(List<OfficeDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOffice([FromBody] OfficeDto officeDto)
    {
        var office = await _officeService.AddOffice(officeDto);
        return Ok(office);
    }
    
    [Authorize(Roles = "Admin")]
    [HttpDelete("{name}")]
    [ProducesResponseType(typeof(List<OfficeDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteOffice([FromBody] string name)
    {
        await _officeService.DeleteOffice(name);
        return Ok();
    }
}