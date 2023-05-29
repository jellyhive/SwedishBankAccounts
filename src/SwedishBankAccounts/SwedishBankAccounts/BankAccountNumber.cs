using System.Linq;
using System.Text.RegularExpressions;

namespace SwedishBankAccounts;

/// <summary>
/// Represents a bank account number
/// </summary>
public record BankAccountNumber
{
    /// <summary>
    /// The name of the bank for the number
    /// </summary>
    public string Bank { get; }

    /// <summary>
    /// The bank account number sorting code (clearing number)
    /// </summary>
    public string SortingCode { get; }

    /// <summary>
    /// The actual bank account number
    /// </summary>
    public string AccountNumber { get; }

    private BankAccountNumber(string bank, string sortingCode, string accountNumber)
    {
        Bank = bank;
        SortingCode = sortingCode;
        AccountNumber = accountNumber;
    }

    /// <summary>
    /// Tries to parse a bank account number
    /// </summary>
    /// <param name="value">The bank account number togethwer with its sorting number</param>
    /// <param name="bankAccountNumber">The parsed bank account number</param>
    /// <returns>True if parse is successful, otherwise false</returns>
    public static bool TryParse(string value, out BankAccountNumber? bankAccountNumber)
    {
        bankAccountNumber = null;
        return TryParse(value, InitOptions.Strict, out bankAccountNumber);
    }

    /// <summary>
    /// Tries to parse a bank account number
    /// </summary>
    /// <param name="value">The bank account number togethwer with its sorting number</param>
    /// <param name="initOptions">Defines the strictness of the parsing </param>
    /// <param name="bankAccountNumber">The parsed bank account number</param>
    /// <returns>True if parse is successful, otherwise false</returns>
    public static bool TryParse(string value, InitOptions? initOptions, out BankAccountNumber? bankAccountNumber)
    {
        initOptions ??= InitOptions.Strict;

        bankAccountNumber = null;
        value = Regex.Replace(value, @"[^\d]", "");

        if (value.StartsWith('8') && value.Length < 7) return false;
        if(!value.StartsWith('8') && value.Length < 6) return false;

        var sortingCode = value[..(value.StartsWith('8') ? 5 : 4)];
        var accountNumber = value[(value.StartsWith('8') ? 5 : 4)..];

        if (sortingCode.Length is < 4 or > 4 && !Modulus10.Validate(sortingCode)) return false;

        var bank = SwedishBankAccounts.Bank.Banks.SingleOrDefault(s => s.HasSortingCode(sortingCode[..4]));
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