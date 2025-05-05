using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface ICardRepository
{
    void AddCard(Card card);
    
    Task<Card> GetCardAsync(Guid id);
    
    Task<List<Card>> GetAllCardsAsync();
    
    Task<List<Card>> GetAllCardsByCardLinkIdAsync(Guid cardLinkId);
}