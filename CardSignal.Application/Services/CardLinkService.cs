using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using CardSignal.DataAccess.Repository;

namespace CardSignal.Application.Services;

public class CardLinkService : ICardLinkService
{
    private readonly ICardLinkRepository _cardLinkRepository;
    private readonly IMapper _mapper;
    private readonly DataBaseContext _dataBaseContext;

    public CardLinkService(
        ICardLinkRepository cardLinkRepository,
        IMapper mapper,
        DataBaseContext dataBaseContext)
    {
        _cardLinkRepository = cardLinkRepository;
        _mapper = mapper;
        _dataBaseContext = dataBaseContext;
    }

    public async Task<CardLinkDto> AddCardLink(CardLinkDto cardLinkDto)
    {
        if (await _cardLinkRepository.CardLinkExistsAsync(cardLinkDto.Name))
        {
            throw new CardLinkAreAlreadyExistException($"Card link with provided {cardLinkDto.Name} name are already exist!");
        }
        
        var cardLink = _mapper.Map<CardLink>(cardLinkDto);
        _cardLinkRepository.AddCardLink(cardLink);
        
        await _dataBaseContext.SaveChangesAsync();
        
        return _mapper.Map<CardLinkDto>(cardLink);
    }

    public async Task<CardLinkDto> GetCardLink(string cardLinkName)
    {
        var cardLink = await _cardLinkRepository.GetCardLinkAsync(cardLinkName);
        return _mapper.Map<CardLinkDto>(cardLink);
    }

    public async Task<List<CardLinkDto>> GetCardLinks()
    {
        List<CardLink> cardLinks = await _cardLinkRepository.GetAllCardLinksAsync();
        return _mapper.Map<List<CardLinkDto>>(cardLinks);
    }

    public async Task<CardLinkDto> UpdateCardLink(Guid cardLinkId, UpdateCardLinkDto cardLinkDto)
    {
        var cardLink = await _cardLinkRepository.GetCardLinkByIdAsync(cardLinkId, trackChanges: true);
        _mapper.Map(cardLinkDto, cardLink);

        await _dataBaseContext.SaveChangesAsync();
        
        return _mapper.Map<CardLinkDto>(cardLink);
    }

    public async Task DeleteCardLink(Guid cardLinkId)
    {
        var cardLink = await _cardLinkRepository.GetCardLinkByIdAsync(cardLinkId, trackChanges: true);
        
        _cardLinkRepository.DeleteCardLink(cardLink);
        await _dataBaseContext.SaveChangesAsync();
    }
}