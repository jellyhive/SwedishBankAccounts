namespace SwedishBankAccounts;

public record BankAccountNumberType2C(Range? AccountLength) :
    BankAccountNumberType2A(AccountLength)
{
    public BankAccountNumberType2C(int accountMinLength, int accountMaxLength) :
        this(new Range(accountMinLength, accountMaxLength))
    {

    }
}