namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringCompactTests
{
    [Theory]
    [InlineData("C")]
    [InlineData("COMPACT")]
    [InlineData("c")]
    [InlineData("compact")]
    public void ToString_CompactFormats_ShouldReturnCompactFormat(string format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("90714172383");
    }

    [Theory]
    [InlineData("6683764450808", "6683764450808")]
    [InlineData("8424-4,983 189 224-6", "842449831892246")]
    [InlineData("3300 000620-5124", "33000006205124")]
    [InlineData("9071, 417 23 83", "90714172383")]
    public void ToString_CompactFormat_ShouldHandleDifferentBankAccounts(string input, string expected)
    {
        var bankAccount = BankAccountNumber.Parse(input);
        var result = bankAccount.ToString("C");

        result.Should().Be(expected);
    }

    [Fact]
    public void ToString_CompactFormat_ShouldHaveNoSeparators()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("COMPACT");

        result.Should().NotContain("-");
        result.Should().NotContain(" ");
        result.Should().MatchRegex(@"^\d+$");
    }

    [Fact]
    public void ToString_CompactWithFormatProvider_ShouldReturnCompactFormat()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("C", null);

        result.Should().Be("90714172383");
    }
}