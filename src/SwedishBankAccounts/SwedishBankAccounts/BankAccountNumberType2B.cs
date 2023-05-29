using System;

namespace SwedishBankAccounts;

public record BankAccountNumberType2B(Range? AccountLength) : BankAccountNumberType(AccountLength)
{
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus10.Validate(accountNumber.PadLeft(9, '0'));
}