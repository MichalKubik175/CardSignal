using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;
using CardSignalR.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardSignalR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CardLinksController : Controller
{
    private readonly ICardLinkService _cardLinkService;

    public CardLinksController(ICardLinkService cardLinkService)
    {
        _cardLinkService = cardLinkService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> GetAll()
    {
        var cardLinks = await _cardLinkService.GetCardLinks();
        return Ok(cardLinks);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> AddCardLink()
    {
        var cardLinks = await _cardLinkService.GetCardLinks();
        return Ok(cardLinks);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> DeleteCardLink([FromBody] CardLinkDto cardLinkDto)
    {
        await _cardLinkService.DeleteCardLink(cardLinkDto);
        return Ok();
    }
    
    
    [HttpPut("updateCardLink")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CardLink>))]
    public async Task<IActionResult> UpdateCardLink([FromBody] CardLinkDto cardLinkDto)
    {
        var cardLinks = await _cardLinkService.UpdateCardLink(cardLinkDto);
        return Ok(cardLinks);
    }
}