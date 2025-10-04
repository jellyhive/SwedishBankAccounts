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
    public static int Calculate(string number)
    {
        var remainder = 0;
        foreach (var chunk in ChunkString(number, 9))
        {
            var combined = remainder + chunk;
            remainder = combined.Length > 9 ? (int)(long.Parse(combined) % 97) : int.Parse(combined) % 97;
        }
        return remainder;
    }

    private static System.Collections.Generic.IEnumerable<string> ChunkString(string str, int chunkSize)
    {
        for (var i = 0; i < str.Length; i += chunkSize)
            yield return str.Substring(i, System.Math.Min(chunkSize, str.Length - i));
    }
}