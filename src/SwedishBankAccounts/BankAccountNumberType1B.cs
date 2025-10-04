namespace SwedishBankAccounts;

/// <summary>
/// Bank account number type 1B - Used for 4+7 digit account numbers with modulus-11 validation on sorting code plus account number
/// </summary>
public record BankAccountNumberType1B : BankAccountNumberType
{
    /// <summary>
    /// Validates the account number using modulus-11 algorithm on the full sorting code plus padded account number
    /// </summary>
    /// <param name="sortingCode">The 4-digit sorting code</param>
    /// <param name="accountNumber">The account number (up to 7 digits)</param>
    /// <returns>True if the account number passes modulus-11 validation, otherwise false</returns>
    public override bool Validate(string sortingCode, string accountNumber) =>
        Modulus11.Validate($"{sortingCode}{accountNumber.PadLeft(7, '0')}");

    /// <summary>
    /// Formats the account for IBAN generation by concatenating sorting code and account number
    /// </summary>
    /// <param name="bankAccount">The bank account to format</param>
    /// <returns>Concatenated sorting code and account number</returns>
    protected override string FormatIban(BankAccountNumber bankAccount) =>
        $"{bankAccount.SortingCode}{bankAccount.AccountNumber}";
}