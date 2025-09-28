namespace SwedishBankAccounts.UnitTests;

public class BankAccountNumberToStringIbanTests
{
    [Theory]
    [InlineData("I")]
    [InlineData("IBAN")]
    [InlineData("i")]
    [InlineData("iban")]
    public void ToString_IbanFormats_ShouldReturnIbanFormat(string format)
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var result = bankAccount.ToString(format);

        result.Should().StartWith("SE");
        result.Length.Should().Be(24);
        result.Should().MatchRegex(@"^SE\d{22}$");
    }

    [Theory]
    [InlineData("9071-4172383", "SE4890714172383000000000")]
    [InlineData("6683764450808", "SE0866837644508080000000")]
    [InlineData("3300 000620-5124", "SE9133000006205124000000")]
    public void ToString_IbanFormat_ShouldGenerateExpectedIban(string input, string expected)
    {
        var bankAccount = BankAccountNumber.Parse(input);
        var result = bankAccount.ToString("I");

        result.Should().Be(expected);
    }

    [Fact]
    public void ToString_IbanFormat_ShouldHaveValidCheckDigits()
    {
        var bankAccount = BankAccountNumber.Parse("9071-4172383");
        var iban = bankAccount.ToString("I");

        var rearranged = iban[4..] + iban[..4];
        var numericString = "";
        foreach (var c in rearranged)
        {
            if (char.IsDigit(c))
            {
                numericString += c;
            }
            else
            {
                numericString += (c - 'A' + 10).ToString();
            }
        }

        Modulus97.Calculate(numericString).Should().Be(1);
    }
}