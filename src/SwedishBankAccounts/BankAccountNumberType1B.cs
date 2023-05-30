namespace SwedishBankAccounts;

public record BankAccountNumberType1B : BankAccountNumberType
{
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate($"{sortingCode}{accountNumber.PadLeft(7, '0')}");
}