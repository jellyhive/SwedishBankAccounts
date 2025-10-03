namespace SwedishBankAccounts;

public record SortingCodeRange(int Min, int Max, BankAccountNumberType BankAccountNumberType)
{
    public bool IsInRange(int value) => value >= Min && value <= Max;
}