using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface ICardLinkService
{
    public Task<CardLinkDto> AddCardLink(CardLinkDto cardLinkDto);
    public Task<CardLinkDto> GetCardLink(string cardLinkName);
    
    public Task<List<CardLinkDto>> GetCardLinks();
    
    public Task<CardLinkDto> UpdateCardLink(Guid cardLinkId, UpdateCardLinkDto cardLinkDto);
    
    public Task DeleteCardLink(Guid cardLinkId);
}