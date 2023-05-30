[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/jellyhive/swedishbankaccounts/csharp.yml?branch=main)](https://github.com/jellyhive/swedishbankaccounts/actions)

# Swedish Bank Account for C#

This package validates and returns details about Swedish bank account numbers using C#/.NET. The details and validation rules are based on the documentation provided by Bankgirot, which can be found [here](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf).

This repository is based on  [swantzter/kontonummer](https://github.com/swantzter/kontonummer) as the foundational model, thank you!

## Important Caveat

Some bank account numbers that is impossible to validate (as they do not have a check
digit) that are indistinguishable from validatable accounts. We recommend using
this library on form input fields but do not prevent form submission if the
account number is reported as invalid. A good idea would instead be a warning saying 
"there is a chance this is not a valid bank account number you may want to double check."

## Specification

### TryParse Example

```csharp

using SwedishBankAccounts;

// 
SwedishBankAccounts.TryParse("8424-4,983 189 224-6", out var bankAccountNumber)
// Returns true if successful, otherwise false
```

### Modulus10 Validation

A static method for validating a number according to the Modulus-10 method should be included.

### Modulus11 Validation

A static method for validating a number according to the Modulus-11 method should be included.