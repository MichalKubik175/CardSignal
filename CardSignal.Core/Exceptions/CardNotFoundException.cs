namespace CardSignal.Core.Exceptions;

public class CardNotFoundException(string exception) : System.Exception(exception);