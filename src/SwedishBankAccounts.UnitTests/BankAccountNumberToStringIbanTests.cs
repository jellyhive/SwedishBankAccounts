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
        result.Should().MatchRegex(@"^SE\d{22}$");
    }

    [Theory]
    [InlineData("5140 321 5642", "SE8450000000051403215642")]
    [InlineData("9160 741 6680", "SE5291500000091607416680")]
    [InlineData("8424-4,983 189 224-6", "SE7680000842449831892246")]
    [InlineData("6683764450808", "SE1360000000000764450808")]
    [InlineData("9565-0000108", "SE4495500000095650000108")]
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