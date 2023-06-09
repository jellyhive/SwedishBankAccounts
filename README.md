[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/jellyhive/swedishbankaccounts/csharp.yml?branch=main)](https://github.com/jellyhive/swedishbankaccounts/actions)
[![NuGet](http://img.shields.io/nuget/v/SwedishBankAccounts.svg)](https://www.nuget.org/packages/SwedishBankAccounts/)
[![Downloads](https://img.shields.io/nuget/dt/SwedishBankAccounts)](#)

# Swedish Bank Account for C#

This package validates and returns details about Swedish bank account numbers using C#/.NET. The details and validation rules are based on the documentation provided by Bankgirot, which can be found [here](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf).

This repository is based on  [swantzter/kontonummer](https://github.com/swantzter/kontonummer) as the foundational model, thank you!

## Important Caveat

Some bank account numbers that is impossible to validate (as they do not have a check
digit) that are indistinguishable from validatable accounts. We recommend using
this library on form input fields but do not prevent form submission if the
account number is reported as invalid. A good idea would instead be a warning saying 
"there is a chance this is not a valid bank account number you may want to double check."

## Examples

### TryParse

```csharp
using SwedishBankAccounts;

class Test 
{
  public void BankAccountLogic() 
  {
      if(SwedishBankAccounts.TryParse("9071, 417 23 83", out var bankAccountNumber))
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
