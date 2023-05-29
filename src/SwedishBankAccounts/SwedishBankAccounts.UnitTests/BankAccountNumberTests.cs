namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberTests : UnitTests
{
    [Theory] 
    [InlineData("9071, 417 23 83", "Multitude Bank")]
    [InlineData("6683764450808", "Handelsbanken")]
    [InlineData("8424-4,983 189 224-6", "Swedbank")]
    [InlineData("8351-9,392 242 224-5", "Swedbank")]
    [InlineData("8129-9,043 386 711-6", "Swedbank")]
    [InlineData("3300 000620-5124", "Nordea")]
    [InlineData("97891111113", "Klarna Bank")]
    [InlineData("9585, 612345740", "Aion Bank")]
    [InlineData("9553-589436168", "Avanza Bank")]
    [InlineData("9683,143 579 155", "BlueStep Finans")]
    [InlineData("9273-956 609 3", "ICA Banken")]
    public void AccountNumber_TryParse_ShouldValidate(string accountNumber, string bankName)
    {
        BankAccountNumber.TryParse(accountNumber, out var bankAccountNumber)
            .Should().BeTrue($"it should be validated to {bankName}");

        bankAccountNumber.Should().NotBeNull($"it should be validated to {bankName}");
        bankAccountNumber!.Bank.Should().Be(bankName, $"it should be validated to {bankName}");
    }
}