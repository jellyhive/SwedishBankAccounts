namespace SwedishBankAccounts.UnitTests;

public class BankBicTests : UnitTests
{
    [Theory]
    [InlineData("7000", "SWEDSESS")]
    [InlineData("8000", "SWEDSESS")]
    [InlineData("5000", "ESSESESS")]
    [InlineData("6000", "HANDSESS")]
    [InlineData("1100", "NDEASESS")]
    [InlineData("9550", "AVANSESX")]
    [InlineData("9100", "NNSESE22")]
    [InlineData("9250", "SBAVSESS")]
    [InlineData("9270", "IBCASES1")]
    [InlineData("1200", "DABASESX")]
    [InlineData("2300", "AABASESS")]
    [InlineData("9150", "SKIASESS")]
    [InlineData("9400", "FORXSESA")]
    [InlineData("9190", "DNBASESS")]
    [InlineData("3400", "ELLFSESS")]
    [InlineData("9390", "LAHYSESS")]
    [InlineData("9280", "RESUSE21")]
    public void GetBic_WhenBankHasBic_ShouldReturnCorrectBic(string sortingCode, string expectedBic)
    {
        var bank = Bank.Banks.FirstOrDefault(b => b.HasSortingCode(sortingCode));
        bank!.Bic.Should().Be(expectedBic);
    }
}
