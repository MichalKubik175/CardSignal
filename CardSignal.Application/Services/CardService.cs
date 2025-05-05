using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using CardSignal.DataAccess.Interfaces;
using CardSignal.DataAccess.Repository;

namespace CardSignal.Application.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly ICardLinkRepository _cardLinkRepository;
    private readonly IMapper _mapper;
    private readonly DataBaseContext _dataBaseContext;
    
    public CardService(
        ICardRepository cardRepository,
        ICardLinkRepository cardLinkRepository,
        IMapper mapper,
        DataBaseContext dataBaseContext)
    {
        _cardRepository = cardRepository;
        _cardLinkRepository = cardLinkRepository;
        _mapper = mapper;
        _dataBaseContext = dataBaseContext;
    }    
    public async Task<CardDto> AddCard(CardDto cardDto)
    {
        var card = _mapper.Map<Card>(cardDto);
        
        _cardRepository.AddCard(card);
        
        await _dataBaseContext.SaveChangesAsync();
        
        return _mapper.Map<CardDto>(card);
    }
    
    
}