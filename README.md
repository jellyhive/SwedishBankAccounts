[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/jellyhive/swedishbankaccounts/swedishbankaccounts.yml?branch=main)](https://github.com/jellyhive/swedishbankaccounts/actions)

# Swedish Bank Account for C#

This package validates and returns details about Swedish bank account numbers using C#/.NET. The details and validation rules are based on the documentation provided by Bankgirot, which can be found [here](https://www.bankgirot.se/globalassets/dokument/anvandarmanualer/bankernaskontonummeruppbyggnad_anvandarmanual_sv.pdf).

This repository is based on  [swantzter/kontonummer](https://github.com/swantzter/kontonummer) as the foundational model, thank you!

## Important Caveat

Some bank account numbers that is impossible to validate (as they do not have a check
digit) that are indistinguishable from validatable accounts. We recommend using
this library on form input fields but do not prevent form submission if the
account number is reported as invalid. A good idea would instead be a warning saying 
"there is a chance this is not a valid bank account number you may want to double check."
