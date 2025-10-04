namespace SwedishBankAccounts;

/// <summary>
/// Bank account number type 2B - Used for variable length account numbers with modulus-11 validation
/// </summary>
public record BankAccountNumberType2B : BankAccountNumberType
{
    /// <summary>
    /// Validates the account number using modulus-11 algorithm on the padded account number
    /// </summary>
    /// <param name="sortingCode">The sorting code (not used in validation)</param>
    /// <param name="accountNumber">The account number to validate</param>
    /// <returns>True if the account number passes modulus-11 validation, otherwise false</returns>
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate(accountNumber.PadLeft(9, '0'));

    /// <summary>
    /// Formats the account for IBAN generation using only the account number (excludes sorting code)
    /// </summary>
    /// <param name="bankAccount">The bank account to format</param>
    /// <returns>The account number only</returns>
    protected override string FormatIban(BankAccountNumber bankAccount) => bankAccount.AccountNumber;
}