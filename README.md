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
      if(BankAccountNumber.TryParse("9553, 123 45 67", out var bankAccountNumber))
      {
          Console.Write(bankAccountNumber);              // 9553-5894364
          Console.Write(bankAccountNumber.Bank.Name);    // Avanza Bank
          Console.Write(bankAccountNumber.Bank.Bic);     // AVANSESX
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

var bankAccount = BankAccountNumber.Parse("9553-5894364");

// Default format (NUMERIC)
Console.WriteLine(bankAccount.ToString());           // 9553-5894364
Console.WriteLine(bankAccount.ToString("N"));       // 9553-5894364
Console.WriteLine(bankAccount.ToString("NUMERIC")); // 9553-5894364

// COMPACT format
Console.WriteLine(bankAccount.ToString("C"));       // 95535894364
Console.WriteLine(bankAccount.ToString("COMPACT")); // 95535894364

// SORTINGCODE format
Console.WriteLine(bankAccount.ToString("S"));           // 9553
Console.WriteLine(bankAccount.ToString("SORTINGCODE")); // 9553

// ACCOUNTNUMBER format
Console.WriteLine(bankAccount.ToString("A"));             // 5894364
Console.WriteLine(bankAccount.ToString("ACCOUNTNUMBER")); // 5894364

// IBAN format
Console.WriteLine(bankAccount.ToString("I"));    // SE8095535894364000000
Console.WriteLine(bankAccount.ToString("IBAN")); // SE8095535894364000000

// PRETTY format (with bank name)
Console.WriteLine(bankAccount.ToString("P"));      // Avanza Bank 9553-5894364
Console.WriteLine(bankAccount.ToString("PRETTY")); // Avanza Bank 9553-5894364
```

All format strings are case-insensitive. Invalid format strings will throw a `FormatException`.

### Bank Information and BIC/SWIFT Codes

The `Bank` property provides access to full bank information including BIC/SWIFT codes:

```csharp
using SwedishBankAccounts;

var bankAccount = BankAccountNumber.Parse("9553-5894364");

// Access bank information
Console.WriteLine(bankAccount.Bank.Name);                    // Avanza Bank
Console.WriteLine(bankAccount.Bank.Bic);                     // AVANSESX
Console.WriteLine(bankAccount.Bank.SortingCodeRange.Length); // 1

// Get bank information directly from Bank.Banks collection
var bank = Bank.Banks.FirstOrDefault(b => b.Name == "Swedbank");
Console.WriteLine(bank?.Bic); // SWEDSESS

// Find bank by sorting code
var sortingCode = "7000";
var swedbankAccount = Bank.Banks.FirstOrDefault(b => b.HasSortingCode(sortingCode));
Console.WriteLine(swedbankAccount?.Bic); // SWEDSESS
```

BIC/SWIFT codes are available for major Swedish banks including Swedbank, Nordea, SEB, Handelsbanken, Danske Bank, Avanza, and many others.

### Breaking Changes in v1.0.0

**Important:** Starting from version 1.0.0, the `Bank` property returns a `Bank` object instead of a string:

```csharp
// v0.x.x (old way)
string bankName = bankAccount.Bank;        // ❌ No longer works

// v1.0.0+ (new way)
string bankName = bankAccount.Bank.Name;   // ✅ Correct
string bic = bankAccount.Bank.Bic;         // ✅ New: Access to BIC codes
```
