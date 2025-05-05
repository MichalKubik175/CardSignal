using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
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
    
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(List<OfficeDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOffice([FromRoute] string name)
    {
        var cardLink = await _officeService.GetOffice(name);
        return Ok(cardLink);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(List<OfficeDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOffice([FromBody] OfficeDto officeDto)
    {
        var office = await _officeService.AddOffice(officeDto);
        return Ok(office);
    }
}