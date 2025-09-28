using FluentAssertions;

namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringErrorHandlingTests
{
    [Theory]
    [InlineData("X")]
    [InlineData("INVALID")]
    [InlineData("Z")]
    [InlineData("FORMAT")]
    [InlineData("UNKNOWN")]
    [InlineData("123")]
    public void ToString_InvalidFormat_ShouldThrowFormatException(string invalidFormat)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        Action act = () => bankAccount.ToString(invalidFormat);

        act.Should().Throw<FormatException>()
           .WithMessage($"Invalid format string: '{invalidFormat}'. Valid formats are: N/NUMERIC, C/COMPACT, S/SORTINGCODE, A/ACCOUNTNUMBER, I/IBAN, P/PRETTY");
    }

    [Theory]
    [InlineData("X")]
    [InlineData("INVALID")]
    [InlineData("Z")]
    public void ToString_InvalidFormatWithProvider_ShouldThrowFormatException(string invalidFormat)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        Action act = () => bankAccount.ToString(invalidFormat, null);

        act.Should().Throw<FormatException>()
           .WithMessage($"Invalid format string: '{invalidFormat}'. Valid formats are: N/NUMERIC, C/COMPACT, S/SORTINGCODE, A/ACCOUNTNUMBER, I/IBAN, P/PRETTY");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ToString_NullEmptyOrWhitespaceFormat_ShouldReturnNumericFormat(string? format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("9071-4172383");
    }
}