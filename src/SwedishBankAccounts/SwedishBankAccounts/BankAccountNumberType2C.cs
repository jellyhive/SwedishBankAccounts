namespace SwedishBankAccounts;

public record BankAccountNumberType2C(Range? AccountLength) : 
    BankAccountNumberType2A(AccountLength);