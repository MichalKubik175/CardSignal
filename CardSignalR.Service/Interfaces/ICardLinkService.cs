using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface ICardLinkService
{
    public Task<CardLinkDto> GetCardLink(string cardLinkName);
    
    public Task<IEnumerable<CardLinkDto>> GetCardLinks();
    
    public Task<CardLinkDto> UpdateCardLink(CardLinkDto cardLinkDto);
    
    public void DeleteCardLink(CardLinkDto cardLinkDto);
}