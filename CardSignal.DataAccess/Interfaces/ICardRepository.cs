using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface ICardRepository
{
    void AddCard(Card card);
}