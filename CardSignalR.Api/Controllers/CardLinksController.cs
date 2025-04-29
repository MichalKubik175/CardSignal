using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CardLinksController : Controller
{
    private readonly DataBaseContext _context;

    public CardLinksController(DataBaseContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> GetAll()
    {
        var cardLinks = await _context.CardLinks.ToListAsync();
        return Ok(cardLinks);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> AddCardLink()
    {
        var cardLinks = await _context.CardLinks.ToListAsync();
        return Ok(cardLinks);
    }
}