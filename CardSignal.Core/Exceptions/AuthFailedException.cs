namespace CardSignal.Core.Exceptions;

public class AuthFailedException(string exception) : System.Exception(exception);
