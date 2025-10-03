namespace SwedishBankAccounts;

public record BankAccountNumberType2D : BankAccountNumberType
{
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate(accountNumber.PadLeft(10, '0'));

    protected override string FormatIban(BankAccountNumber bankAccount) =>
        $"{bankAccount.SortingCode}{bankAccount.AccountNumber}";
}