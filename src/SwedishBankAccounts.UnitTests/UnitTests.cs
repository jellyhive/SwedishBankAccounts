namespace SwedishBankAccounts.UnitTests;

public abstract class UnitTests
{
    protected Fixture Fixture { get; }

    protected UnitTests()
    {
        Fixture = new Fixture();
    }
}