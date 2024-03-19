namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberTests : UnitTests
{
	[Theory] 
    [InlineData("9071, 417 23 83", "Multitude Bank", InitOptions.Strict)]
    [InlineData("6683764450808", "Handelsbanken", InitOptions.Strict)]
    [InlineData("8424-4,983 189 224-6", "Swedbank", InitOptions.Strict)]
    [InlineData("8351-9,392 242 224-5", "Swedbank", InitOptions.Strict)]
    [InlineData("8129-9,043 386 711-6", "Swedbank", InitOptions.Strict)]
    [InlineData("3300 000620-5124", "Nordea", InitOptions.Strict)]
    [InlineData("9585, 612345740", "Aion Bank", InitOptions.Strict)]
    [InlineData("9553-5894364", "Avanza Bank", InitOptions.Strict)]
    [InlineData("9683,143 579 155", "BlueStep Finans", InitOptions.Strict)]
    [InlineData("9472,456 987 154", "BNP Paribas", InitOptions.Strict)]
    [InlineData("9045,987 456 128", "Citibank", InitOptions.Strict)]
    [InlineData("1255,6548711", "Danske Bank", InitOptions.Strict)]
    [InlineData("9199,321 8647", "DNB Bank", InitOptions.Strict)]
    [InlineData("9704,861 957 3564", "Ekobanken", InitOptions.Strict)]
    [InlineData("9597 984 216 868", "Erik Penser", InitOptions.Strict)]
    [InlineData("9273-956 609 3", "ICA Banken", InitOptions.Strict)]
    [InlineData("9178-516 4155", "IKANO Bank", InitOptions.Strict)]
    [InlineData("9674-9871358", "JAK Medlemsbank", InitOptions.Strict)]
    [InlineData("97891111113", "Klarna Bank", InitOptions.Strict)]
    [InlineData("9398-2159875", "Landshypotek", InitOptions.Strict)]
    [InlineData("9714-8924679", "Lunar Bank", InitOptions.Strict)]
    [InlineData("9630, 6541128", "Lån & Spar Bank Sverige", InitOptions.Strict)]
    [InlineData("3400, 123 4645", "Länsförsäkringar Bank", InitOptions.Strict)]
    [InlineData("9060, 541 6877", "Länsförsäkringar Bank", InitOptions.Strict)]
    [InlineData("9234, 879 1552", "Marginalen Bank", InitOptions.Strict)]
    [InlineData("9646, 1230477", "Nordax Bank", InitOptions.Strict)]
    [InlineData("1150, 9743685", "Nordea", InitOptions.Strict)]
    [InlineData("4564, 154 1970", "Nordea", InitOptions.Strict)]
    [InlineData("9108 876 1587", "Nordnet Bank", InitOptions.Strict)]
    [InlineData("9752-6546873", "Northmill Bank", InitOptions.Strict)]
    [InlineData("9280 689 1477", "Resurs Bank", InitOptions.Strict)]
    [InlineData("9882 134 6325", "Riksgälden", InitOptions.Strict)]
    [InlineData("9462 613 5412", "Santander Consumer Bank", InitOptions.Strict)]
    [InlineData("9252 132 2148", "SBAB", InitOptions.Strict)]
    [InlineData("5140 321 5642", "SEB", InitOptions.Strict)]
    [InlineData("9160 741 6680", "Skandiabanken", InitOptions.Strict)]
    [InlineData("9664 446 5511", "Svea Bank", InitOptions.Strict)]
    [InlineData("9180 331 4218", "Danske Bank", InitOptions.Strict)]
    [InlineData("9530 364 8748", "Nordea Plusgirot", InitOptions.Strict)]
    [InlineData("9892 398 7468", "Riksgälden", InitOptions.Strict)]
    [InlineData("9578 633 1128", "Sparbanken Syd", InitOptions.Strict)]
    [InlineData("9340 321 4681", "Swedbank", InitOptions.Strict)]
    [InlineData("9340 321 4682", "Swedbank", InitOptions.Lax)]
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
}