namespace Fluent.Edi.Abstraction;

/// <summary>
/// Grammar definition for edi fact files
/// </summary>
public interface IEdiGrammar
{
    /// <summary>
    /// Segment name delimiter is the character used to separate between a segment name and its elements
    /// </summary>
    /// <value>+</value>
    char SegmentNameDelimiter { get; }

    /// <summary>
    /// Component data element separator is the "second level" separator of data elements within a message segment
    /// </summary>
    /// <value>:</value>
    char ComponentDataElementSeparator { get; }

    /// <summary>
    /// EDI-Fact only, depends on culture/location
    /// </summary>
    char? DecimalSeparator { get; }

    /// <summary>
    /// <para>The release character (analogous to the \ in regular expressions)</para>
    /// is used as a prefix to remove special meaning from the separator, segment termination, 
    /// and release characters when they are used as plain text. Default value is <value>'?'</value>
    /// </summary>
    /// <value>?</value>
    char? ReleaseCharacter { get; }

    /// <summary>
    /// Segment terminator indicates the end of a message segment.
    /// </summary>
    /// <value>'</value>
    char SegmentTerminator { get; }

    /// <summary>
    /// EDI Fact only
    /// </summary>
    /// <value>UNA</value>
    string ServiceStringAdviceTag { get; }

    /// <summary>
    /// The segment name that marks the Interchange Header.
    /// </summary>
    /// <value>UNB</value>
    string InterchangeHeaderTag { get; }

    /// <summary>
    /// The segment name that marks the Message Header.
    /// </summary>
    /// <value>UNH</value>
    string MessageHeaderTag { get; }

    /// <summary>
    /// The segment name that marks the Message Trailer.
    /// </summary>
    /// <value>UNT</value>
    string MessageTrailerTag { get; }

    /// <summary>
    /// The segment name that marks the interchange Trailer.
    /// </summary>
    /// <value>UNZ</value>
    string InterchangeTrailerTag { get; }
}