using CardSignal.Core.Entities;
using CardSignal.DataAccess.Interfaces;

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
}