using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Extensions;
using CardSignal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Repository;

public class CardLinkRepository : ICardLinkRepository
{
    private readonly DataBaseContext _context;

    public CardLinkRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }

    public void AddCardLink(CardLink cardLink)
    {
        _context.CardLinks.Add(cardLink);
    }

    public async Task<CardLink> GetCardLinkByIdAsync(Guid id, bool trackChanges)
    {
        var cardLink = await _context.CardLinks
            .WithTracking(trackChanges)
            .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new CardLinkNotFoundException($"CardLink with provided {id} id is not found!");

        return cardLink;
    }
    public async Task<CardLink> GetCardLinkAsync(string cardLinkName)
    {
        return await _context.CardLinks
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Name == cardLinkName)
               ?? throw new CardLinkNotFoundException($"CardLink with provided {cardLinkName} name is not found!");
    }

    public async Task<List<CardLink>> GetAllCardLinksAsync(Guid userId)
    {
        return await _context.CardLinks
            .Where(x => x.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public void DeleteCardLink(CardLink cardLink)
    {
        _context.CardLinks.Remove(cardLink);
    }
    
    public async Task<bool> CardLinkExistsAsync(string cardLinkName)
    {
        return await _context.CardLinks.AnyAsync(x => x.Name == cardLinkName);
    }
    
    public async Task<bool> CardLinkExistsAsync(Guid cardLinkId)
    {
        return await _context.CardLinks.AnyAsync(x => x.Id == cardLinkId);
    }
}