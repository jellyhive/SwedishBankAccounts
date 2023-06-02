namespace SwedishBankAccounts;

public record BankAccountNumberType1A : BankAccountNumberType
{
    public override bool Validate(string sortingCode, string accountNumber) => 
        Modulus11.Validate($"{sortingCode.Substring(1)}{accountNumber.PadLeft(7, '0')}");
}