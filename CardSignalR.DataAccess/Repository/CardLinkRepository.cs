using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interfaces;
using CardSignalR.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class CardLinkRepository : ICardLinkRepository
{
    private readonly DataBaseContext _context;
    public CardLinkRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
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
               ?? throw new CardLinkNotFoundException("CardLink is not exist!");
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
    
    public async Task<bool> CardLinkExistsAsync(string cardLinkName)
    {
        return await _context.CardLinks.AnyAsync(x => x.Name == cardLinkName);
    }
}