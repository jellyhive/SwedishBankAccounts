namespace SwedishBankAccounts;

public abstract record BankAccountNumberType
{
    public abstract bool Validate(string sortingCode, string accountNumber);

}