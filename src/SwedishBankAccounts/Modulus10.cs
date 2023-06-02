using System.Linq;

namespace SwedishBankAccounts;

/// <summary>
/// Handles validation and calculation of check digit according to the modulus-10 method
/// </summary>
public static class Modulus10
{
    /// <summary>
    /// Validates the given number  according to to the modulus-10 method
    /// </summary>
    /// <param name="number">The number to perform the validation upon</param>
    /// <returns>True if the number is valid according to to the modulus-10 method, otherwise false</returns>
    public static bool Validate(long number) => Validate(number.ToString());

    /// <summary>
    /// Validates the given number  according to to the modulus-10 method
    /// </summary>
    /// <param name="number">The number to perform the validation upon</param>
    /// <returns>True if the number is valid according to to the modulus-10 method, otherwise false</returns>
    public static bool Validate(string number)
    {
        var checkDigit = CalculateCheckDigit(number.Substring(0, number.Length - 1));
        return number.Last() - 48 == checkDigit;
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
    public static int CalculateCheckDigit(string number) => CalculateCheckDigit(long.Parse(number));

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