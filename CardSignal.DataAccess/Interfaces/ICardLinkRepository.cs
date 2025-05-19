using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface ICardLinkRepository
{
    void AddCardLink(CardLink cardLink);
    
    Task<CardLink> GetCardLinkByIdAsync(Guid id, bool trackChanges);

    Task<CardLink> GetCardLinkAsync(string cardLinkName);

    Task<List<CardLink>> GetAllCardLinksAsync(Guid userId);

    void DeleteCardLink(CardLink cardLink);

    Task<bool> CardLinkExistsAsync(string cardLinkName);

    Task<bool> CardLinkExistsAsync(Guid cardLinkId);
}