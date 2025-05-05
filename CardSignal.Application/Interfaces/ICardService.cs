using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface ICardService
{
    Task<CardDto> AddCard(CardDto cardDto);
    
    Task<CardDto> GetCard(Guid id);
    
    Task<List<CardDto>> GetAllCards();
    
    Task<List<CardDto>> GetAllCardsByCardLinkId(Guid cardLinkId);
}