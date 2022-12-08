using Fluent.Edi.Abstraction.Exceptions;

namespace Fluent.Edi.Exceptions;

/// <summary>
/// Notify that segment do not contain advice marker
/// </summary>
public class EdiGrammarNotAnAdviceSegmentException : EdiGrammarParseException
{
    internal static string NoSegmentToCheckValue = "given grammar is null";
    /// <inheritdoc />
    public EdiGrammarNotAnAdviceSegmentException(string? segmentToCheck) : base(segmentToCheck ?? NoSegmentToCheckValue) { }
}
