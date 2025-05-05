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
    
}