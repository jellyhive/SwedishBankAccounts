using System.Linq;
using System.Text.RegularExpressions;

namespace SwedishBankAccounts;

public record BankAccountNumber
{
    public string Bank { get; }
    public string SortingCode { get; }
    public string AccountNumber { get; }

    private BankAccountNumber(string bank, string sortingCode, string accountNumber)
    {
        Bank = bank;
        SortingCode = sortingCode;
        AccountNumber = accountNumber;
    }

    public static bool TryParse(string value, out BankAccountNumber? bankAccountNumber)
    {
        bankAccountNumber = null;
        return TryParse(value, InitOptions.Strict, out bankAccountNumber);
    }

    public static bool TryParse(string value, InitOptions? initOptions, out BankAccountNumber? bankAccountNumber)
    {
        initOptions ??= InitOptions.Strict;

        bankAccountNumber = null;
        value = Regex.Replace(value, @"[^\d]", "");

        if (value.StartsWith('8') && value.Length < 7) return false;
        if(!value.StartsWith('8') && value.Length < 6) return false;

        var test = value.Substring(0, value.StartsWith('8') ? 5 : 4);

        var sortingCode = value[..(value.StartsWith('8') ? 5 : 4)];
        var accountNumber = value[(value.StartsWith('8') ? 5 : 4)..];

        if (sortingCode.Length is < 4 or > 4 && !Modulus10.Validate(sortingCode)) return false;

        var bank = SwedishBankAccounts.Bank.Banks.SingleOrDefault(s => s.HasSortingCode(sortingCode));
        if(bank == null) return false;

        var valid = bank.BankAccountNumberType.Validate(sortingCode, accountNumber);
        switch (valid)
        {
            case false when initOptions == InitOptions.Strict:
            case false when bank.BankAccountNumberType is BankAccountNumberType1A or BankAccountNumberType1B:
                return false;
        }

        bankAccountNumber = new BankAccountNumber(bank.Name, sortingCode, accountNumber);
        return true;
    }
}