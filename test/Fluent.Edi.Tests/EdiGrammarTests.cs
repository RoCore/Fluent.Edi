using Fluent.Edi.Exceptions;
using FluentAssertions;
using System.Globalization;

namespace Fluent.Edi.Tests;

public class EdiGrammarTests
{
    [Theory(DisplayName = "EDI grammar try parse from string")]
    [InlineData("UNA:+,? '")]
    [InlineData("UNA;-,! \"")]
    public void EdiGrammar_TryParse_ReturnValidValue(string unaSegment)
    {
        //arrange

        //act
        EdiGrammar.TryParse(unaSegment, out var result).Should().BeTrue();

        //assert
        result.Should().NotBeNull();
        result.ComponentDataElementSeparator.Should().Be(unaSegment[3]);
        result.SegmentNameDelimiter.Should().Be(unaSegment[4]);
        result.DecimalSeparator.Should().Be(unaSegment[5]);
        result.ReleaseCharacter.Should().Be(unaSegment[6]);
        result.SegmentTerminator.Should().Be(unaSegment[8]);
    }

    [Theory(DisplayName = "EDI Grammar has invalid segment")]
    [InlineData("124")]
    [InlineData(null)]
    public void EdiGrammar_Parse_InvalidSegmentString(string? unaSegment)
    {
        //arrange

        //act
        Action execute = () => EdiGrammar.Parse(unaSegment);

        //assert
        execute
            .Should()
            .Throw<EdiGrammarNotAnAdviceSegmentException>()
            .Where(a => a.Message == (unaSegment ?? EdiGrammarNotAnAdviceSegmentException.NoSegmentToCheckValue));
    }

    [Theory(DisplayName = "Different grammar for different ui cultures")]
    [InlineData("de", ',')]
    [InlineData("en", '.')]
    public void EdiGrammar_DefaultValue_WithDifferentCultures(string culture, char expectedDecimalSeparator)
    {
        //arrange
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

        //act
        var grammar = EdiGrammar.Default();

        //assert
        grammar.DecimalSeparator.Should().Be(expectedDecimalSeparator);
    }
}