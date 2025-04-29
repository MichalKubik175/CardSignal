using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.Service.Dto;
using CardSignalR.Service.Interfaces;

namespace CardSignalR.Service.Services;

public class CardLinkService : ICardLinkService
{
    private readonly ICardLinkRepository _cardLinkRepository;

    public CardLinkService(ICardLinkRepository cardLinkRepository)
    {
        _cardLinkRepository = cardLinkRepository;
    }

    public Task<CardLink> GetCardLink(Guid cardLinkDtoId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CardLink>> GetCardLinks()
    {
        throw new NotImplementedException();
    }

    public Task<CardLink> UpdateCardLink(CardLinkDto cardLinkDto)
    {
        throw new NotImplementedException();
    }

    public void DeleteCardLink(CardLinkDto cardLinkDto)
    {
        throw new NotImplementedException();
    }
}