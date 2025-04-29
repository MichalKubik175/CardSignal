using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface ICardLinkService
{
    public Task<CardLink> GetCardLink(Guid cardLinkDtoId);
    
    public Task<IEnumerable<CardLink>> GetCardLinks();
    
    public Task<CardLink> UpdateCardLink(CardLinkDto cardLinkDto);
    
    public void DeleteCardLink(CardLinkDto cardLinkDto);
}