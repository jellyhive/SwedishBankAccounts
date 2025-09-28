namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringAccountNumberTests
{
    [Theory]
    [InlineData("A")]
    [InlineData("ACCOUNTNUMBER")]
    [InlineData("a")]
    [InlineData("accountnumber")]
    public void ToString_AccountNumberFormats_ShouldReturnAccountNumberOnly(string format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("4172383");
    }

    [Theory]
    [InlineData("6683764450808", "764450808")]
    [InlineData("8424-4,983 189 224-6", "9831892246")]
    [InlineData("3300 000620-5124", "0006205124")]
    [InlineData("9071, 417 23 83", "4172383")]
    public void ToString_AccountNumberFormat_ShouldHandleDifferentBankAccounts(string input, string expected)
    {
        var bankAccount = BankAccountNumber.Parse(input);
        var result = bankAccount.ToString("A");

        result.Should().Be(expected);
    }

    [Fact]
    public void ToString_AccountNumberFormat_ShouldReturnOnlyNumbers()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("ACCOUNTNUMBER");

        result.Should().NotContain("-");
        result.Should().NotContain(" ");
        result.Should().MatchRegex(@"^\d+$");
    }

    [Fact]
    public void ToString_AccountNumberWithFormatProvider_ShouldReturnAccountNumberOnly()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("A", null);

        result.Should().Be("4172383");
    }
}