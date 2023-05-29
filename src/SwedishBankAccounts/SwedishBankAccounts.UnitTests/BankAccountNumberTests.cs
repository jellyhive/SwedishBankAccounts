namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberTests : UnitTests
{
    [Theory] 
    [InlineData("9071, 417 23 83", "Multitude Bank")]
    [InlineData("6683764450808", "Handelsbanken")]
    [InlineData("8424-4,983 189 224-6", "Swedbank")]
    public void AccountNumber_TryParse_ShouldValidate(string accountNumber, string bankName)
    {
        BankAccountNumber.TryParse(accountNumber, out var bankAccountNumber)
            .Should().BeTrue($"it should be validated to {bankName}");

        bankAccountNumber.Should().NotBeNull($"it should be validated to {bankName}");
        bankAccountNumber!.Bank.Should().Be(bankName, $"it should be validated to {bankName}");
    }
}