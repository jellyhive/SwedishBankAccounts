namespace SwedishBankAccounts;

public record BankAccountNumberType2A : BankAccountNumberType
{
    public override bool Validate(string sortingCode, string accountNumber) => 
        Modulus10.Validate(accountNumber.PadLeft(10, '0'));
}