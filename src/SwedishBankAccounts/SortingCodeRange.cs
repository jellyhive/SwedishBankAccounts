namespace SwedishBankAccounts;

/// <summary>
/// Represents a range of sorting codes (clearing numbers) for a specific bank account number type
/// </summary>
/// <param name="Min">The minimum sorting code in the range (inclusive)</param>
/// <param name="Max">The maximum sorting code in the range (inclusive)</param>
/// <param name="BankAccountNumberType">The bank account number type used for this sorting code range</param>
public record SortingCodeRange(int Min, int Max, BankAccountNumberType BankAccountNumberType)
{
    /// <summary>
    /// Determines whether the specified value is within this sorting code range
    /// </summary>
    /// <param name="value">The sorting code value to check</param>
    /// <returns>True if the value is within the range (inclusive), otherwise false</returns>
    public bool IsInRange(int value) => value >= Min && value <= Max;
}