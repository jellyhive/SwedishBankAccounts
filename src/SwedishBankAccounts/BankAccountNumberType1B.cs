namespace SwedishBankAccounts;

public record BankAccountNumberType1B(Range? AccountLength = null) : BankAccountNumberType(AccountLength)
{
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate($"{sortingCode}{accountNumber.PadLeft(7, '0')}");
}