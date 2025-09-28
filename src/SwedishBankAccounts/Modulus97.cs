using System.Linq;

namespace SwedishBankAccounts;

/// <summary>
/// Handles validation and calculation according to the modulus-97 method
/// </summary>
public static class Modulus97
{
    /// <summary>
    /// Calculates the modulus 97 remainder for a given number string
    /// </summary>
    /// <param name="number">The number string to calculate modulus 97 for</param>
    /// <returns>The modulus 97 remainder (0-96)</returns>
    public static int Calculate(string number) => number.Aggregate(0, (current, digit) => (current * 10 + (digit - '0')) % 97);
}