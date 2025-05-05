using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Repository;

public class CardRepository : ICardRepository
{
    private readonly DataBaseContext _context;
    
    public CardRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }

    public void AddCard(Card card)
    {
        _context.Cards.Add(card);
    }

    public async Task<Card> GetCardAsync(Guid id)
    {
        return await _context.Cards
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id) 
               ?? throw new CardNotFoundException($"Card with provided {id} id does not exist");
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        return await _context.Cards
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Card>> GetAllCardsByCardLinkIdAsync(Guid cardLinkId)
    {
        return await _context.Cards
            .AsNoTracking()
            .Where(x => x.CardLinkId == cardLinkId)
            .ToListAsync();
    }
}