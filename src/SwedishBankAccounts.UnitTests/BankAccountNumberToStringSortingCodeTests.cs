namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringSortingCodeTests
{
    [Theory]
    [InlineData("S")]
    [InlineData("SORTINGCODE")]
    [InlineData("s")]
    [InlineData("sortingcode")]
    public void ToString_SortingCodeFormats_ShouldReturnSortingCodeOnly(string format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("9071");
    }

    [Theory]
    [InlineData("6683764450808", "6683")]
    [InlineData("8424-4,983 189 224-6", "84244")]
    [InlineData("3300 000620-5124", "3300")]
    [InlineData("9071, 417 23 83", "9071")]
    public void ToString_SortingCodeFormat_ShouldHandleDifferentBankAccounts(string input, string expected)
    {
        var bankAccount = BankAccountNumber.Parse(input);
        var result = bankAccount.ToString("S");

        result.Should().Be(expected);
    }

    [Fact]
    public void ToString_SortingCodeFormat_ShouldReturnOnlyNumbers()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("SORTINGCODE");

        result.Should().NotContain("-");
        result.Should().NotContain(" ");
        result.Should().MatchRegex(@"^\d+$");
        result.Length.Should().BeOneOf(4, 5);
    }

    [Fact]
    public void ToString_SortingCodeWithFormatProvider_ShouldReturnSortingCodeOnly()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString("S", null);

        result.Should().Be("9071");
    }
}