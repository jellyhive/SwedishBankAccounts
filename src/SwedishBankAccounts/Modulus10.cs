namespace SwedishBankAccounts;

/// <summary>
/// Handles validation and calculation of check digit accordning to the modulus-10 method
/// </summary>
public static class Modulus10
{
    /// <summary>
    /// Validates the given number  according to to the modulus-10 method
    /// </summary>
    /// <param name="number">The number to perform the validation upon</param>
    /// <returns>True if the number is valid according to to the modulus-10 method, otherwise false</returns>
    public static bool Validate(long number) => Validate(number.ToString());

    public static bool Validate(string number)
    {
        var deltas = new[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
        var checksum = 0;
        for (var i = number.Length - 1; i > -1; i--)
        {
            var j = number[i] - 48;

            if (j is < 0 or > 9)
                return false;

            checksum += j;
            if ((i - number.Length) % 2 == 0)
                checksum += deltas[j];
        }

        return checksum % 10 == 0;
    }

    /// <summary>
    /// Calculates the check digit according to to the modulus-10 method
    /// </summary>
    /// <param name="number">The number to calculate the modulus-10 check digit upon</param>
    /// <returns>
    /// Returns the calculated modulus-10 check digit
    /// 
    /// Note that if the product is equal to 1 and the check digit is 10, then the account
    /// number cannot be used as a basis of a modulus-10 account number and the method will then return -1
    /// </returns>
    public static int CalculateCheckDigit(long number)
    {
        var digits = number.ToString();

        var sum = 0;
        var multiplier = 2;

        for (var i = 0; i < digits.Length; i++)
        {
            var product = (digits[digits.Length - 1 - i] - 48) * multiplier;
            sum += product > 9 ? product - 9 : product;

            multiplier = multiplier == 2 ? 1 : 2;
        }

        return (10 - sum % 10) % 10;
    }
}