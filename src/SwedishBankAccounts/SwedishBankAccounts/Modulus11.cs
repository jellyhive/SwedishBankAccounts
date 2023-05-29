namespace SwedishBankAccounts;

/// <summary>
/// Handles validation and calculation of check digit accordning to the modulus-11 method
/// </summary>
public static class Modulus11
{
    /// <summary>
    /// Validates the given number according to to the modulus-11 method
    /// </summary>
    /// <param name="number">The number to perform the validation upon</param>
    /// <returns>True if the number is valid according to to the modulus-11 method, otherwise false</returns>
    public static bool Validate(long number) => Validate(number.ToString());

    /// <summary>
    /// Validates the given number according to to the modulus-11 method
    /// </summary>
    /// <param name="number">The number to perform the validation upon</param>
    /// <returns>True if the number is valid according to to the modulus-11 method, otherwise false</returns>
    public static bool Validate(string number)
    {
        var weight = 2;
        var checksum = 0m;

        for (var i = number.Length - 2; i > -1; i--)
        {
            var j = number[i] - 48;
            if (j is < 0 or > 9) return false;

            checksum += j * weight;
            weight++;
            if (weight > 10) weight = 1;
        }

        var control = number[^1] - 48;
        if (control is < 0 or > 9) return false;

        var result = checksum % 11;
        return result == 0 && control == 0 || 11 - result == control;
    }

    /// <summary>
    /// Calculates the check digit according to to the modulus-11 method
    /// </summary>
    /// <param name="number">The number to calculate the modulus-11 check digit upon</param>
    /// <returns>
    /// Returns the calculated modulus-11 check digit
    /// 
    /// Note that if the product is equal to 1 and the check digit is 10, then the account
    /// number cannot be used as a basis of a modulus-11 account number and the method will then return -1
    /// </returns>
    public static int CalculateCheckDigit(long number)
    {
        var digits = number.ToString();
        var weight = 2;
        var sum = 0;

        for (var i = 0; i < digits.Length; i++)
        {
            var val = digits[digits.Length - 1 - i] - 48;
            sum += val * weight;
            weight += 1;

            if (weight > 10) weight = 1;
        }

        var validator = 11 - sum % 11;
        return validator switch
        {
            11 => 0,
            10 => -1,
            _ => validator
        };
    }
}