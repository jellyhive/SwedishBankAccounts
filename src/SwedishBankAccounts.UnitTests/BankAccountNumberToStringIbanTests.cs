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
    [InlineData("5001-1108053", "SE8250000000050011108053")]
    [InlineData("5001-3408852", "SE2550000000050013408852")]
    //[InlineData("9071-4172383", "SE2800000000090714172383")]
    //[InlineData("6683764450808", "SE1600000006683764450808")]
    //[InlineData("3300 000620-5124", "SE2300000033000006205124")]
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