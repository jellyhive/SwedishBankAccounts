namespace SwedishBankAccounts;

public record BankAccountNumberType1A(Range? AccountLength = null) : BankAccountNumberType(AccountLength)
{
    public override bool Validate(string sortingCode, string accountNumber) => 
        Modulus11.Validate($"{sortingCode[1..]}{accountNumber.PadLeft(7, '0')}");
}