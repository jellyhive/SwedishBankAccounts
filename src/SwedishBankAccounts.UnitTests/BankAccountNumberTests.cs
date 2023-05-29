using System;

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
    [InlineData("9585, 612345740", "Aion Bank")]
    [InlineData("9553-5894364", "Avanza Bank")]
    [InlineData("9683,143 579 155", "BlueStep Finans")]
    [InlineData("9472,456 987 154", "BNP Paribas")]
    [InlineData("9045,987 456 128", "Citibank")]
    [InlineData("1255,6548711", "Danske Bank")]
    [InlineData("9199,321 8647", "DNB Bank")]
    [InlineData("9704,861 957 3564", "Ekobanken")]
    [InlineData("9597 984 216 868", "Erik Penser")]
    [InlineData("9273-956 609 3", "ICA Banken")]
    [InlineData("9178-516 4155", "IKANO Bank")]
    [InlineData("9674-9871358", "JAK Medlemsbank")]
    [InlineData("97891111113", "Klarna Bank")]
    [InlineData("9398-2159875", "Landshypotek")]
    [InlineData("9714-8924679", "Lunar Bank")]
    [InlineData("9630, 6541128", "Lån & Spar Bank Sverige")]
    [InlineData("3400, 123 4645", "Länsförsäkringar Bank")]
    [InlineData("9060, 541 6877", "Länsförsäkringar Bank")]
    [InlineData("9234, 879 1554", "Marginalen Bank")]
    [InlineData("9646, 1230477", "Nordax Bank")]
    [InlineData("1150, 9743685", "Nordea")]
    [InlineData("4564, 154 1970", "Nordea")]
    [InlineData("9108 876 1587", "Nordnet Bank")]
    [InlineData("9752-6546873", "Northmill Bank")]
    [InlineData("9280 689 1477", "Resurs Bank")]
    [InlineData("9882 134 6325", "Riksgälden")]
    [InlineData("9462 613 5412", "Santander Consumer Bank")]
    [InlineData("9252 132 2148", "SBAB")]
    [InlineData("5140 321 5642", "SEB")]
    [InlineData("9160 741 6680", "Skandiabanken")]
    [InlineData("9664 446 5511", "Svea Bank")]
    [InlineData("9180 331 4218", "Danske Bank")]
    [InlineData("9530 364 8748", "Nordea Plusgirot")]
    [InlineData("9892 398 7468", "Riksgälden")]
    [InlineData("9578 633 1128", "Sparbanken Syd")]
    [InlineData("9340 321 4681", "Swedbank")]
    public void AccountNumber_TryParse_ShouldValidate(string accountNumber, string bankName)
    {
        BankAccountNumber.TryParse(accountNumber, out var bankAccountNumber)
            .Should().BeTrue($"it should be validated to {bankName}");

        bankAccountNumber.Should().NotBeNull($"it should be validated to {bankName}");
        bankAccountNumber!.Bank.Should().Be(bankName, $"it should be validated to {bankName}");
    }
}