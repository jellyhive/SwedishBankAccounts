namespace SwedishBankAccounts;

public record Range(int Min, int Max)
{
    public bool IsInRange(int value) => value >= Min && value <= Max;
}