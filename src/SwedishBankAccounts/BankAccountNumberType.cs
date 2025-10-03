namespace SwedishBankAccounts;

public abstract record BankAccountNumberType
{
    public abstract bool Validate(string sortingCode, string accountNumber);

    public string CreateIban(BankAccountNumber bankAccount)
    {
        return string.Empty;
    }

    protected abstract string FormatIban(BankAccountNumber bankAccount);

}