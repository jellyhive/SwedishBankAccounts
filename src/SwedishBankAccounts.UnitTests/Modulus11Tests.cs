using FluentAssertions;
using static SwedishBankAccounts.Modulus11;

namespace SwedishBankAccounts.UnitTests;

public class Modulus11Tests : UnitTests
{
    private readonly Random random;

    public Modulus11Tests()
    {
        random = new Random();
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(10, 8)]
    [InlineData(10003, -1)]
    [InlineData(24135, 0)]
    [InlineData(32455, 8)]
    [InlineData(001029163, 6)]
    [InlineData(76445080, 8)]
    [InlineData(12345678901, 3)]
    [InlineData(7622521, 6)]
    [InlineData(8958221, 7)]
    public void CalculateCheckDigit_IsExpected(long value, int expect) => 
        CalculateCheckDigit(value).Should().Be(expect);

    [Theory]
    [InlineData(241350, true)]
    [InlineData(324558, true)]
    [InlineData(0010291636, true)]
    [InlineData(764450808, true)]
    public void Validate_ValidatesCorrectly(long number, bool result) => 
        Validate(number).Should().Be(result);


    [Fact]
    public void Modulus11_RandomValues_ValidatesCheckDigit()
    {
        var value = random.Next(1000000, 9999999);
        var checkDigit = Modulus11.CalculateCheckDigit(value);

        if(checkDigit == -1) return;

        var number = long.Parse($"{value}{checkDigit}");
        Modulus11.Validate(number).Should().BeTrue($"Number {number}{checkDigit} is not valid");
    }
}