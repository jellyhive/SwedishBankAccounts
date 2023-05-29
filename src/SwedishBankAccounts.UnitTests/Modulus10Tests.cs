namespace SwedishBankAccounts.UnitTests;

public class Modulus10Tests : UnitTests
{
    private readonly Random random;

    public Modulus10Tests()
    {
        random = new Random();
    }

    [Theory]
    [InlineData(1, 8)]
    [InlineData(12, 5)]
    [InlineData(991234, 6)]
    [InlineData(55555555, 6)]
    [InlineData(5555555, 1)]
    [InlineData(555555, 2)]
    public void CalculateCheckDigit_IsExpected(long value, int expect) =>
        Modulus10.CalculateCheckDigit(value).Should().Be(expect);

    [Theory]
    [InlineData(1212121212, true)]
    [InlineData(7403226330, true)]
    [InlineData(7403226331, false)]
    [InlineData(9912346, true)]
    [InlineData(55555551, true)]
    public void Validate_ValidatesCorrectly(long number, bool result) => 
        Modulus10.Validate(number).Should().Be(result);


    [Fact]
    public void Modulus10_RandomValues_ValidatesCheckDigit()
    {
        var value = random.Next(1000000, 9999999);
        var checkDigit = Modulus10.CalculateCheckDigit(value);

        if (checkDigit == -1) return;

        var number = long.Parse($"{value}{checkDigit}");
        Modulus10.Validate(number).Should().BeTrue($"Number {number}{checkDigit} is not valid");
    }
}