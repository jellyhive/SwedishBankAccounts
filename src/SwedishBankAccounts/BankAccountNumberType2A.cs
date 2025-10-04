namespace SwedishBankAccounts;

/// <summary>
/// Bank account number type 2A - Used for variable length account numbers with modulus-10 validation
/// </summary>
public record BankAccountNumberType2A : BankAccountNumberType
{
    /// <summary>
    /// Validates the account number using modulus-10 algorithm on the padded account number
    /// </summary>
    /// <param name="sortingCode">The sorting code (not used in validation)</param>
    /// <param name="accountNumber">The account number to validate</param>
    /// <returns>True if the account number passes modulus-10 validation, otherwise false</returns>
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus10.Validate(accountNumber.PadLeft(10, '0'));

    /// <summary>
    /// Formats the account for IBAN generation using only the account number (excludes sorting code)
    /// </summary>
    /// <param name="bankAccount">The bank account to format</param>
    /// <returns>The account number only</returns>
    protected override string FormatIban(BankAccountNumber bankAccount) => bankAccount.AccountNumber;
}