namespace SwedishBankAccounts;

public record BankAccountNumberType2C : BankAccountNumberType2A
{
    protected override string FormatIban(BankAccountNumber bankAccount) =>
        $"{bankAccount.SortingCode}{bankAccount.AccountNumber}";
}