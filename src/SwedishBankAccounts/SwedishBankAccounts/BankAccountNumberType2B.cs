namespace SwedishBankAccounts;

public record BankAccountNumberType2B(Range? AccountLength) : BankAccountNumberType(AccountLength)
{
    public BankAccountNumberType2B(int accountMinLength, int accountMaxLength) :
        this(new Range(accountMinLength, accountMaxLength))
    {

    }
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate(accountNumber.PadLeft(9, '0'));
}