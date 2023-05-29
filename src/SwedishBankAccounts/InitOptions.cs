namespace SwedishBankAccounts;

public enum InitOptions
{
    /// <summary>
    /// Validates sorting code, account number length and account number check digit. Should throw if any of these checks fail.
    /// </summary>
    Strict,

    /// <summary>
    /// Validates strict checks for type 1 account numbers (4+7) but lax checks for type 2 account numbers.
    /// </summary>
    Semi,

    /// <summary>
    /// Validation should not throw if the check digit of the account number cannot be validated. Should instead set the valid property to false if the check digit or length is invalid. Should still throw for invalid sorting codes
    /// </summary>
    Lax
}