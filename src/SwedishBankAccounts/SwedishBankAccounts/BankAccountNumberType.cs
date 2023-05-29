using System.Collections.Generic;

namespace SwedishBankAccounts;






public record Bank(string Name, Range[] Range, BankAccountNumberType BankAccountNumberType)
{
    public static IEnumerable<Bank> Banks
    {
        get
        {
            return new[]
            {
                new Bank("Aion Bank", new[] { new Range(9580, 9589) }, new BankAccountNumberType1A())
            };
        }
    }
}




public abstract record BankAccountNumberType(Range? AccountLength)
{
    public abstract bool Validate(string sortingCode, string accountNumber);

}

public record Range(int Min, int Max);