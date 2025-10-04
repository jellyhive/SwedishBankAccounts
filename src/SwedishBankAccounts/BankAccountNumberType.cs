namespace SwedishBankAccounts;

/// <summary>
/// Abstract base class for different Swedish bank account number validation types
/// </summary>
public abstract record BankAccountNumberType
{
    /// <summary>
    /// Validates the account number according to the specific bank account number type rules
    /// </summary>
    /// <param name="sortingCode">The bank sorting code (clearing number)</param>
    /// <param name="accountNumber">The account number to validate</param>
    /// <returns>True if the account number is valid, otherwise false</returns>
    public abstract bool Validate(string sortingCode, string accountNumber);

    /// <summary>
    /// Creates an IBAN (International Bank Account Number) for the given bank account
    /// </summary>
    /// <param name="bankAccount">The bank account to create IBAN for</param>
    /// <returns>A valid IBAN string in Swedish format</returns>
    public string CreateIban(BankAccountNumber bankAccount)
    {
        var paddedBankAccountNumber = FormatIban(bankAccount).PadLeft(17, '0');

        var rearranged = $"{bankAccount.Bank.IbanId}{paddedBankAccountNumber}281400";
        var remainder = Modulus97.Calculate(rearranged);
        var checkDigits = (98 - remainder).ToString("D2");

        return $"SE{checkDigits}{bankAccount.Bank.IbanId}{paddedBankAccountNumber}";
    }

    /// <summary>
    /// Formats the bank account for IBAN generation according to the specific account type
    /// </summary>
    /// <param name="bankAccount">The bank account to format</param>
    /// <returns>The formatted account string for IBAN calculation</returns>
    protected abstract string FormatIban(BankAccountNumber bankAccount);
}