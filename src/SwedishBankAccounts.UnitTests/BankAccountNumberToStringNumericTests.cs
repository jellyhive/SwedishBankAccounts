namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringNumericTests
{
    [Fact]
    public void ToString_Default_ShouldReturnNumericFormat()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString();

        result.Should().Be("9071-4172383");
    }

    [Theory]
    [InlineData("N")]
    [InlineData("NUMERIC")]
    [InlineData("n")]
    [InlineData("numeric")]
    [InlineData(null)]
    [InlineData("")]
    public void ToString_NumericFormats_ShouldReturnNumericFormat(string? format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("9071-4172383");
    }

    [Theory]
    [InlineData("6683764450808", "6683-764450808")]
    [InlineData("8424-4,983 189 224-6", "84244-9831892246")]
    [InlineData("3300 000620-5124", "3300-0006205124")]
    [InlineData("9071, 417 23 83", "9071-4172383")]
    public void ToString_NumericFormat_ShouldHandleDifferentBankAccounts(string input, string expected)
    {
        var bankAccount = BankAccountNumber.Parse(input);
        var result = bankAccount.ToString("N");

        result.Should().Be(expected);
    }

    [Fact]
    public void ToString_WithFormatProvider_ShouldReturnNumericFormat()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("N", null);

        result.Should().Be("9071-4172383");
    }
}