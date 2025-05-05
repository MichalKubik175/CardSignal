using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardSignal.Api.Controllers;

[ApiController]
[Route("api/cards")]
[Produces("application/json")]
public class CardController : Controller
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<CardDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var cards = await _cardService.GetAllCards();
        return Ok(cards);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(List<CardDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCard(CardDto cardDto)
    {
        var card = await _cardService.AddCard(cardDto);
        return Ok(card);
    }
}