using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SwedishBankAccounts;

/// <summary>
/// Represents a bank account number
/// </summary>
public record BankAccountNumber
{
    /// <summary>
    /// The bank for the number
    /// </summary>
    public Bank Bank { get; }

    /// <summary>
    /// The bank account number sorting code (clearing number)
    /// </summary>
    public string SortingCode { get; }

    /// <summary>
    /// The actual bank account number
    /// </summary>
    public string AccountNumber { get; }

	private BankAccountNumber(Bank bank, string sortingCode, string accountNumber)
    {
        Bank = bank;
        SortingCode = sortingCode;
        AccountNumber = accountNumber;
    }

    /// <summary>
    /// Parses a bank account number
    /// </summary>
    /// <param name="value">The bank account number together with its sorting number</param>
    /// <returns>The parsed bank account number</returns>
    public static BankAccountNumber Parse(string value)
    {
        return !TryParse(value, InitOptions.Strict, out var bankAccountNumber)
            ? throw new FormatException("Invalid: " + nameof(value))
            : bankAccountNumber!;
    }
    /// <summary>
    /// Parses a bank account number
    /// </summary>
    /// <param name="value">The bank account number together with its sorting number</param>
    /// <param name="initOptions">Defines the strictness of the parsing </param>
    /// <returns>The parsed bank account number</returns>
    public static BankAccountNumber Parse(string value, InitOptions initOptions)
    {
        return !TryParse(value, initOptions, out var bankAccountNumber)
            ? throw new FormatException("Invalid: " + nameof(value))
            : bankAccountNumber!;
    }

    /// <summary>
    /// Tries to parse a bank account number
    /// </summary>
    /// <param name="value">The bank account number together with its sorting number</param>
    /// <param name="bankAccountNumber">The parsed bank account number</param>
    /// <returns>True if parse is successful, otherwise false</returns>
    public static bool TryParse(string value, out BankAccountNumber? bankAccountNumber)
    {
        return TryParse(value, InitOptions.Strict, out bankAccountNumber);
    }

    /// <summary>
    /// Tries to parse a bank account number
    /// </summary>
    /// <param name="value">The bank account number together with its sorting number</param>
    /// <param name="initOptions">Defines the strictness of the parsing </param>
    /// <param name="bankAccountNumber">The parsed bank account number</param>
    /// <returns>True if parse is successful, otherwise false</returns>
    public static bool TryParse(string value, InitOptions? initOptions, out BankAccountNumber? bankAccountNumber)
    {
		const int accountMaxLength = 15;
		initOptions ??= InitOptions.Strict;

        bankAccountNumber = null;
        value = Regex.Replace(value, @"[^\d]", "");

        if (value.Length > accountMaxLength) return false;
        if (value.StartsWith("8") && value.Length < 7) return false;
        if (!value.StartsWith("8") && value.Length < 6) return false;

        var sortingCode = value.Substring(0, value.StartsWith("8") ? 5 : 4);
        var accountNumber = value.Substring(value.StartsWith("8") ? 5 : 4);

        if (sortingCode.Length is < 4 or > 4 && !Modulus10.Validate(sortingCode)) return false;

        var (bank, sortingCodeRange) = Bank.FindBank(sortingCode.Substring(0, 4));
        if(bank == null || sortingCodeRange == null) return false;

        var valid = sortingCodeRange.BankAccountNumberType.Validate(sortingCode, accountNumber);
        switch (valid)
        {
            case false when initOptions == InitOptions.Strict:
            case false when sortingCodeRange.BankAccountNumberType is BankAccountNumberType1A or BankAccountNumberType1B:
                return false;
        }

        bankAccountNumber = new BankAccountNumber(bank, sortingCode, accountNumber);
        return true;
    }

    /// <summary>
    /// Returns a string representation of the bank account number using the default NUMERIC format
    /// </summary>
    /// <returns>String in format: {SortingCode}-{AccountNumber}</returns>
    public override string ToString()
    {
        return ToString("N");
    }

    /// <summary>
    /// Returns a string representation of the bank account number in the specified format
    /// </summary>
    /// <param name="format">The format string (N/NUMERIC, C/COMPACT, S/SORTINGCODE, A/ACCOUNTNUMBER, I/IBAN, P/PRETTY)</param>
    /// <returns>Formatted string representation</returns>
    /// <exception cref="FormatException">Thrown when format is invalid</exception>
    public string ToString(string? format)
    {
        return ToString(format, null);
    }

    /// <summary>
    /// Returns a string representation of the bank account number in the specified format
    /// </summary>
    /// <param name="format">The format string (N/NUMERIC, C/COMPACT, S/SORTINGCODE, A/ACCOUNTNUMBER, I/IBAN, P/PRETTY)</param>
    /// <param name="formatProvider">Format provider (not used but required for IFormattable interface)</param>
    /// <returns>Formatted string representation</returns>
    /// <exception cref="FormatException">Thrown when format is invalid</exception>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        var normalizedFormat = (format ?? "N").ToUpperInvariant();

        if (string.IsNullOrWhiteSpace(normalizedFormat))
        {
            normalizedFormat = "N";
        }

        return normalizedFormat switch
        {
            "N" or "NUMERIC" => $"{SortingCode}-{AccountNumber}",
            "C" or "COMPACT" => $"{SortingCode}{AccountNumber}",
            "S" or "SORTINGCODE" => SortingCode,
            "A" or "ACCOUNTNUMBER" => AccountNumber,
            "I" or "IBAN" => ToIban(),
            "P" or "PRETTY" => ToPretty(),
            _ => throw new FormatException($"Invalid format string: '{format}'. Valid formats are: N/NUMERIC, C/COMPACT, S/SORTINGCODE, A/ACCOUNTNUMBER, I/IBAN, P/PRETTY")
        };
    }

    private string ToIban()
    {
        var range = Bank.SortingCode(SortingCode);
        if (range == null) throw new InvalidOperationException("Cannot determine IBAN without a valid bank range");
        return range.BankAccountNumberType.CreateIban(this);
    }


    private string ToPretty()
    {
        return $"{Bank.Name} {SortingCode}-{AccountNumber}";
    }
}