namespace Fluent.Edi.Abstraction.Exceptions;

/// <summary>
/// Exception thrown by parsing EDI fact grammar
/// </summary>
public class EdiGrammarParseException : Exception
{
    /// <inheritdoc />
    public EdiGrammarParseException(string message) : base(message) { }
}
