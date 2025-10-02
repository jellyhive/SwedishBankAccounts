[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/jellyhive/swedishbankaccounts/csharp.yml?branch=main)](https://github.com/jellyhive/swedishbankaccounts/actions)
[![NuGet](http://img.shields.io/nuget/v/SwedishBankAccounts.svg)](https://www.nuget.org/packages/SwedishBankAccounts/)
[![Downloads](https://img.shields.io/nuget/dt/SwedishBankAccounts)](#)

# Swedish Bank Account for C#

This package validates and returns details about Swedish bank account numbers using C#/.NET. The details and validation rules are based on the documentation provided by Bankgirot, which can be found [here](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf).

This repository is based on  [swantzter/kontonummer](https://github.com/swantzter/kontonummer) as the foundational model, thank you!

## Important Caveat

Some bank account numbers are impossible to validate (as they do not have a check
digit) and are indistinguishable from validatable accounts. We recommend using
this library on form input fields but do not prevent form submission if the
account number is reported as invalid. A good idea would instead be a warning saying
"there is a chance this is not a valid bank account number, you may want to double check."

## Examples

### TryParse

```csharp
using SwedishBankAccounts;

class Test
{
  public void BankAccountLogic()
  {
      if(BankAccountNumber.TryParse("9071, 417 23 83", out var bankAccountNumber))
      {
          Console.Write(bankAccountNumber);         // 9071-4172383
          Console.Write(bankAccountNumber.Bank);    // Multitude Bank
      }
  }
}
```
### Modulus Validation and Calculation

```csharp
using SwedishBankAccounts;

class Test 
{
  public void ModulusValidation() 
  {
      SwedishBankAccounts.Modulus10.Validate("12556548711")     // True
      SwedishBankAccounts.Modulus10.Validate("12556548713")     // False

      SwedishBankAccounts.Modulus11.Validate("90714172383")     // True
      SwedishBankAccounts.Modulus11.Validate("90714172382")     // False
  }

  public void ModulusCalculation()
  {
      SwedishBankAccounts.Modulus10.CalculateCheckDigit("1255654871")       // Returns 1
      SwedishBankAccounts.Modulus11.CalculateCheckDigit("9071417238")       // Returns 3
  }
}
```

### Formatting

The library supports multiple output formats for bank account numbers:

```csharp
using SwedishBankAccounts;

var bankAccount = BankAccountNumber.Parse("9071-4172383");

// Default format (NUMERIC)
Console.WriteLine(bankAccount.ToString());           // 9071-4172383
Console.WriteLine(bankAccount.ToString("N"));       // 9071-4172383
Console.WriteLine(bankAccount.ToString("NUMERIC")); // 9071-4172383

// COMPACT format
Console.WriteLine(bankAccount.ToString("C"));       // 90714172383
Console.WriteLine(bankAccount.ToString("COMPACT")); // 90714172383

// SORTINGCODE format
Console.WriteLine(bankAccount.ToString("S"));           // 9071
Console.WriteLine(bankAccount.ToString("SORTINGCODE")); // 9071

// ACCOUNTNUMBER format
Console.WriteLine(bankAccount.ToString("A"));             // 4172383
Console.WriteLine(bankAccount.ToString("ACCOUNTNUMBER")); // 4172383

// IBAN format
Console.WriteLine(bankAccount.ToString("I"));    // SE8790714172383000000
Console.WriteLine(bankAccount.ToString("IBAN")); // SE8790714172383000000

// PRETTY format (with bank name)
Console.WriteLine(bankAccount.ToString("P"));      // Multitude Bank 9071-4172383
Console.WriteLine(bankAccount.ToString("PRETTY")); // Multitude Bank 9071-4172383
```

All format strings are case-insensitive. Invalid format strings will throw a `FormatException`.

### BIC/SWIFT Codes

Many Swedish banks have BIC/SWIFT codes available in the library:

```csharp
using SwedishBankAccounts;

// Get bank information including BIC/SWIFT code
var bank = Bank.Banks.FirstOrDefault(b => b.Name == "Swedbank");
Console.WriteLine(bank?.Bic); // SWEDSESS

// Find bank by sorting code
var sortingCode = "9550";
var avanzaBank = Bank.Banks.FirstOrDefault(b => b.HasSortingCode(sortingCode));
Console.WriteLine(avanzaBank?.Bic); // AVANSESX
```

BIC/SWIFT codes are available for major Swedish banks including Swedbank, Nordea, SEB, Handelsbanken, Danske Bank, Avanza, and many others.
