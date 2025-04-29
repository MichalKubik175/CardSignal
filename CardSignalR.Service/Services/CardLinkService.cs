using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.Service.Dto;
using CardSignalR.Service.Interfaces;

namespace CardSignalR.Service.Services;

public class CardLinkService : ICardLinkService
{
    private readonly ICardLinkRepository _cardLinkRepository;
    private readonly IMapper _mapper;

    public CardLinkService(ICardLinkRepository cardLinkRepository, IMapper mapper)
    {
        _cardLinkRepository = cardLinkRepository;
        _mapper = mapper;
    }

    public async Task<CardLinkDto> GetCardLink(string cardLinkName)
    {
        CardLinkDto cardLinkDto = new CardLinkDto();
        CardLink cardLink = await _cardLinkRepository.GetCardLinkAsync(cardLinkName);
        
        return _mapper.Map(cardLink, cardLinkDto);
    }

    public async Task<IEnumerable<CardLinkDto>> GetCardLinks()
    {
        IEnumerable<CardLinkDto> cardLinkDto = new List<CardLinkDto>();
        IEnumerable<CardLink> cardLink = await _cardLinkRepository.GetAllCardLinksAsync();
        
        return _mapper.Map<IEnumerable<CardLinkDto>>(cardLink);
    }

    public async Task<CardLinkDto> UpdateCardLink(CardLinkDto cardLinkDto)
    {
        CardLink cardLink = _mapper.Map<CardLink>(cardLinkDto);
        CardLink mappedCardLink = await _cardLinkRepository.UpdateCardLinkAsync(cardLink);
        
        return _mapper.Map<CardLinkDto>(mappedCardLink);
    }

    public async void DeleteCardLink(CardLinkDto cardLinkDto)
    {
        CardLink cardLink = _mapper.Map<CardLink>(cardLinkDto);
        
        await _cardLinkRepository.DeleteCardLinkAsync(cardLink);
    }
}