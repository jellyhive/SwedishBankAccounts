namespace SwedishBankAccounts;

public abstract record BankAccountNumberType(Range? AccountLength)
{
    public abstract bool Validate(string sortingCode, string accountNumber);

}