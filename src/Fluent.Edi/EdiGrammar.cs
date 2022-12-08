using Fluent.Edi.Abstraction;
using Fluent.Edi.Exceptions;

namespace Fluent.Edi;

/// <inheritdoc />
public class EdiGrammar : IEdiGrammar
{
    private const string ServiceStringAdviceTagConst = "UNA";
    private const string InterchangeHeaderTagConst = "UNB";
    private const string MessageHeaderTagConst = "UNH";
    private const string MessageTrailerTagConst = "UNT";
    private const string InterchangeTrailerTagConst = "UNZ";
    /// <inheritdoc />
    public char ComponentDataElementSeparator { get; }

    /// <inheritdoc />
    public char SegmentNameDelimiter { get; }

    /// <inheritdoc />
    public char? DecimalSeparator { get; }

    /// <inheritdoc />
    public char? ReleaseCharacter { get; }

    /// <inheritdoc />
    public char SegmentTerminator { get; }

    /// <inheritdoc />
    public string ServiceStringAdviceTag => ServiceStringAdviceTagConst;

    /// <inheritdoc />
    public string InterchangeHeaderTag => InterchangeHeaderTagConst;

    /// <inheritdoc />
    public string MessageHeaderTag => MessageHeaderTagConst;

    /// <inheritdoc />
    public string MessageTrailerTag => MessageTrailerTagConst;

    /// <inheritdoc />
    public string InterchangeTrailerTag => InterchangeTrailerTagConst;

    /// <summary>
    /// Use default initialization parameters for grammar
    /// </summary>
    /// <param name="componentDataElementSeparator">:</param>
    /// <param name="segmentNameDelimiter">+</param>
    /// <param name="decimalSeparator">depends on culture info ',' or '.'</param>
    /// <param name="releaseCharacter">?</param>
    /// <param name="segmentTerminator">'</param>
    private EdiGrammar(char componentDataElementSeparator, char segmentNameDelimiter, char? decimalSeparator, char? releaseCharacter, char segmentTerminator)
    {
        ComponentDataElementSeparator = componentDataElementSeparator;
        SegmentNameDelimiter = segmentNameDelimiter;
        DecimalSeparator = decimalSeparator;
        ReleaseCharacter = releaseCharacter;
        SegmentTerminator = segmentTerminator;
    }

    /// <summary>
    /// Try to parse string to correct EDI grammar
    /// </summary>
    /// <example>UNA:+,? '</example>
    /// <param name="grammar">EDI grammar as string</param>
    /// <returns>EDI Grammar</returns>
    public static bool TryParse(string? grammar, out IEdiGrammar? ediGrammar)
    {
        if (grammar == null || grammar.Length < 9 || !grammar.StartsWith("UNA"))
        {
            ediGrammar = null;
            return false;
        }

        ediGrammar = new EdiGrammar(grammar[3], grammar[4], grammar[5], grammar[6], grammar[8]);
        return true;
    }

    public static IEdiGrammar Parse(string? grammar)
    {
        if (!TryParse(grammar, out var ediGrammar))
        {
            throw new EdiGrammarNotAnAdviceSegmentException(grammar);
        }

        return ediGrammar!;
    }

    public static IEdiGrammar Default()
    {
        var decimalSeparator = Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator[0];
        return new EdiGrammar(':', '+', decimalSeparator, '?', '\'');
    }

}
