using CardSignalR.DataAccess.Entities;

namespace CardSignalR.DataAccess.Interfaces;

public interface ICardLinkRepository
{
    Task<CardLink> CreateCardLinkAsync(CardLink cardLink);
    
    Task<CardLink> GetCardLinkAsync(string cardLinkName);
    
    Task<IEnumerable<CardLink>> GetAllCardLinksAsync();
    
    Task DeleteCardLinkAsync(CardLink cardLink);
}