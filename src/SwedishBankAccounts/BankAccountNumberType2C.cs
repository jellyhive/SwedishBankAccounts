namespace SwedishBankAccounts;

/// <summary>
/// Bank account number type 2C - Inherits from type 2A but uses different IBAN formatting for Plusgiro accounts
/// </summary>
public record BankAccountNumberType2C : BankAccountNumberType2A
{
    /// <summary>
    /// Formats the account for IBAN generation by concatenating sorting code and account number (overrides 2A behavior)
    /// </summary>
    /// <param name="bankAccount">The bank account to format</param>
    /// <returns>Concatenated sorting code and account number</returns>
    protected override string FormatIban(BankAccountNumber bankAccount) =>
        $"{bankAccount.SortingCode}{bankAccount.AccountNumber}";
}