using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CardSignal.Api.Controllers;

[ApiController]
[Route("api/card-links")]
[Produces("application/json")]
public class CardLinksController : Controller
{
    private readonly ICardLinkService _cardLinkService;
    private readonly ICardService _cardService;

    public CardLinksController(
        ICardLinkService cardLinkService,
        ICardService cardService)
    {
        _cardLinkService = cardLinkService;
        _cardService = cardService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<CardLinkDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var cardLinks = await _cardLinkService.GetCardLinks();
        return Ok(cardLinks);
    }
    
    [HttpGet("{name}")]
    [ProducesResponseType(typeof(List<CardLinkDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCardLink([FromRoute] string name)
    {
        var cardLink = await _cardLinkService.GetCardLink(name);
        return Ok(cardLink);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(List<CardLinkDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCardLink([FromBody] CardLinkDto cardLinkDto)
    {
        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        cardLinkDto.Link = baseUrl;

        var cardLink = await _cardLinkService.AddCardLink(cardLinkDto);
        return Ok(cardLink);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteCardLink([FromRoute] Guid id)
    {
        await _cardLinkService.DeleteCardLink(id);
        return NoContent();
    }
    
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(List<CardLink>), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCardLink([FromRoute] Guid id, [FromBody] UpdateCardLinkDto cardLinkDto)
    {
        var cardLinks = await _cardLinkService.UpdateCardLink(id, cardLinkDto);
        return Ok(cardLinks);
    }
    
    [HttpPost("{id:guid}/cards")]
    [ProducesResponseType(typeof(List<CardDto>),StatusCodes.Status200OK)]
    public async Task<IActionResult> AddCard(
        [FromRoute] Guid id,
        [FromBody] CardDto cardDto)
    {
        cardDto.CardLinkId = id;
        
        var card = await _cardService.AddCard(cardDto);
        return Ok(card);
    }
}