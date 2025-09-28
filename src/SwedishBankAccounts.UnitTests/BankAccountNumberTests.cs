namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberTests : UnitTests
{

    [Theory]
    [MemberData(nameof(ValidAccountNumbers))]
	public void BankAccountNumber_TryParse_ShouldValidate(string accountNumber, string bankName, InitOptions initOptions)
    {
        BankAccountNumber.TryParse(accountNumber, initOptions, out var bankAccountNumber)
            .Should().BeTrue($"it should be validated to {bankName}");

        bankAccountNumber.Should().NotBeNull($"it should be validated to {bankName}");
        bankAccountNumber!.Bank.Should().Be(bankName, $"it should be validated to {bankName}");
    }

    [Theory]
    [InlineData("1234567890123456", InitOptions.Strict)]
    [InlineData("9252 132 2149", InitOptions.Lax)]
    [InlineData("9340 321 4682", InitOptions.Strict)]
	public void BankAccountNumber_TryParse_ShouldNotValidate(string accountNumber, InitOptions initOptions)
    {
	    BankAccountNumber.TryParse(accountNumber, initOptions ,out var bankAccountNumber).Should().BeFalse();

        bankAccountNumber.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(ValidAccountNumbers))]
    public void BankAccountNumber_Parse_ShouldReturnValidAccount(string accountNumber, string bankName, InitOptions initOptions)
    {
        var result = BankAccountNumber.Parse(accountNumber, initOptions);

        result.Should().NotBeNull();
        result.Bank.Should().Be(bankName);
    }

    [Theory]
    [InlineData("1234567890123456", InitOptions.Strict)]
    [InlineData("9252 132 2149", InitOptions.Lax)]
    [InlineData("9340 321 4682", InitOptions.Strict)]
    public void BankAccountNumber_Parse_ShouldThrowFormatException(string invalidAccountNumber, InitOptions initOptions)
    {
        Action act = () => BankAccountNumber.Parse(invalidAccountNumber, initOptions);

        act.Should().Throw<FormatException>();
    }
}