using AutoMapper;
using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class CardLinkRepository : ICardLinkRepository
{
    private readonly DataBaseContext _context;
    private readonly IMapper _mapper;
    public CardLinkRepository(DataBaseContext dataBaseContext, IMapper mapper)
    {
        _context = dataBaseContext;
        _mapper = mapper;
    }

    public async Task<CardLink> UpdateCardLinkAsync(CardLink cardLink)
    {
        CardLink contextCardLink = await _context.CardLinks
            .Where(contextCardLink => contextCardLink.Id == cardLink.Id)
            .FirstOrDefaultAsync() ?? throw new CardLinkNotFoundException($"Card with provided id: {cardLink.Id} is not found!");
        
        _context.Entry(contextCardLink).State = EntityState.Detached;
        contextCardLink = _mapper.Map(cardLink, contextCardLink);
        
        _context.Entry(contextCardLink).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
        
        return contextCardLink;
    }

    public async Task<CardLink> CreateCardLinkAsync(CardLink cardLink)
    {
        if (await CardLinkExistsAsync(cardLink.Name))
            throw new CardLinkAreAlreadyExistException("CardLink with the same name are already exists");

        _context.CardLinks.Add(cardLink);
        await _context.SaveChangesAsync();

        return cardLink;
    }

    public async Task<CardLink> GetCardLinkAsync(string cardLinkName)
    {
        return await _context.CardLinks.FirstOrDefaultAsync(x => x.Name == cardLinkName) 
               ?? throw new CardLinkNotFoundException($"CardLink with provided {cardLinkName} name is not found!");
    }

    public async Task<IEnumerable<CardLink>> GetAllCardLinksAsync()
    {
        return await _context.CardLinks.ToListAsync();
    }
    
    public async Task DeleteCardLinkAsync(CardLink cardLink)
    {
        var card = await _context.CardLinks.FindAsync(cardLink.Id);
        if (card != null)
        {
            _context.CardLinks.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
    
    private async Task<bool> CardLinkExistsAsync(string cardLinkName)
    {
        return await _context.CardLinks.AnyAsync(x => x.Name == cardLinkName);
    }
    
    private async Task<bool> CardLinkExistsAsync(Guid cardLinkId)
    {
        return await _context.CardLinks.AnyAsync(x => x.Id == cardLinkId);
    }
}