using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface ICardService
{
    Task<CardDto> AddCard(CardDto cardDto);
}