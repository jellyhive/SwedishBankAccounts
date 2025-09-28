using FluentAssertions;

namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringPrettyTests : UnitTests
{
    [Theory]
    [InlineData("P")]
    [InlineData("PRETTY")]
    [InlineData("p")]
    [InlineData("pretty")]
    public void ToString_PrettyFormats_ShouldReturnPrettyFormat(string format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().Be("Multitude Bank 9071-4172383");
    }

    [Theory]
    [MemberData(nameof(ValidAccountNumbers))]
    public void ToString_PrettyFormat_ShouldReturnBankNameAndAccount(string accountNumber, string bankName, InitOptions initOptions)
    {
        var bankAccount = BankAccountNumber.Parse(accountNumber, initOptions);
        var result = bankAccount.ToString("P");

        result.Should().Be($"{bankName} {bankAccount.SortingCode}-{bankAccount.AccountNumber}");
    }
}