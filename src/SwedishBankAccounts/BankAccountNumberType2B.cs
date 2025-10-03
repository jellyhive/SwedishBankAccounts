namespace SwedishBankAccounts;

public record BankAccountNumberType2B : BankAccountNumberType
{
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate(accountNumber.PadLeft(9, '0'));

    protected override string FormatIban(BankAccountNumber bankAccount) => bankAccount.AccountNumber;
}