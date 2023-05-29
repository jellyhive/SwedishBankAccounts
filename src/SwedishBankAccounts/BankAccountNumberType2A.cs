namespace SwedishBankAccounts;

public record BankAccountNumberType2A(Range? AccountLength = null) : BankAccountNumberType(AccountLength)
{
    public BankAccountNumberType2A(int accountMinLength, int accountMaxLength) :
        this(new Range(accountMinLength, accountMaxLength))
    {

    }

    public override bool Validate(string sortingCode, string accountNumber) => 
        Modulus10.Validate(accountNumber.PadLeft(10, '0'));
}