using System.Collections.Generic;
using System.Linq;

namespace SwedishBankAccounts;

/// <summary>
/// Defines a bank
/// </summary>
/// <param name="Name">The name of the bank</param>
/// <param name="SortingCodeRange">The ranges of sorting numbers used by the bank</param>
/// <param name="BankAccountNumberType">The specific account number type used</param>
public record Bank(string Name, Range[] SortingCodeRange, BankAccountNumberType BankAccountNumberType)
{
    /// <summary>
    /// Returns a list of known Swedish banks
    /// </summary>
    public static IEnumerable<Bank> Banks
    {
        get
        {
            return new[]
            {
                new Bank("Aion Bank", new[] { new Range(9580, 9589) }, new BankAccountNumberType1A()),
                new Bank("Avanza Bank", new[] { new Range(9550, 9569) }, new BankAccountNumberType1B()),
                new Bank("BlueStep Finans", new[] { new Range(9680, 9689) }, new BankAccountNumberType1A()),
                new Bank("BNP Paribas", new[] { new Range(9470, 9479) }, new BankAccountNumberType1B()),
                new Bank("Citibank", new[] { new Range(9040, 9049) }, new BankAccountNumberType1B()),
                new Bank("Danske Bank", new[] { new Range(1200, 1399), new Range(2400, 2499) }, new BankAccountNumberType1A()),
                new Bank("DNB Bank", new[]
                {
                    new Range(9190, 9199), 
                    new Range(9260, 9269)
                }, new BankAccountNumberType1B()),
                new Bank("Ekobanken", new[] { new Range(9700, 9709) }, new BankAccountNumberType1B()),
                new Bank("Erik Penser", new[] { new Range(9590, 9599) }, new BankAccountNumberType1B()),
                new Bank("ICA Banken", new[] { new Range(9270, 9279) }, new BankAccountNumberType1A()),
                new Bank("IKANO Bank", new[] { new Range(9170, 9179) }, new BankAccountNumberType1A()),
                new Bank("JAK Medlemsbank", new[] { new Range(9670, 9679) }, new BankAccountNumberType1B()),
                new Bank("Klarna Bank", new[] { new Range(9780, 9789) }, new BankAccountNumberType1B()),
                new Bank("Landshypotek", new[] { new Range(9390, 9399) }, new BankAccountNumberType1B()),
                new Bank("Lunar Bank", new[] { new Range(9710, 9719) }, new BankAccountNumberType1B()),
                new Bank("Lån & Spar Bank Sverige", new[] { new Range(9630, 9639) }, new BankAccountNumberType1A()),
                new Bank("Länsförsäkringar Bank", new[] { new Range(3400, 3409), new Range(9060, 9069) }, new BankAccountNumberType1A()),
                new Bank("Länsförsäkringar Bank", new[] { new Range(9020, 9029) }, new BankAccountNumberType1B()),
                new Bank("Marginalen Bank", new[] { new Range(9230, 9239) }, new BankAccountNumberType1B()),
                new Bank("Multitude Bank", new[] { new Range(9070, 9079) }, new BankAccountNumberType1A()),
                new Bank("Nordax Bank", new[] { new Range(9640, 9649) }, new BankAccountNumberType1B()),
                new Bank("Nordea", new[] 
                { 
                    new Range(1100, 1199), 
                    new Range(1400, 2099), 
                    new Range(3000, 3299),
                    new Range(3301, 3399),
                    new Range(3410, 3781),
                    new Range(3783, 3999),
                }, new BankAccountNumberType1A()),
                new Bank("Nordea", new[] { new Range(4000, 4999) }, new BankAccountNumberType1B()),
                new Bank("Nordnet Bank", new[] { new Range(9100, 9109) }, new BankAccountNumberType1B()),
                new Bank("Northmill Bank", new[] { new Range(9750, 9759) }, new BankAccountNumberType1B()),
                new Bank("Resurs Bank", new[] { new Range(9280, 9289) }, new BankAccountNumberType1A()),
                new Bank("Riksgälden", new[] { new Range(9880, 9889) }, new BankAccountNumberType1B()),
                new Bank("Santander Consumer Bank", new[] { new Range(9460, 9469) }, new BankAccountNumberType1A()),
                new Bank("SBAB", new[] { new Range(9250, 9259) }, new BankAccountNumberType1A()),
                new Bank("SEB", new[]
                {
                    new Range(5000, 5999),
                    new Range(9120, 9124),
                    new Range(9130, 9149),
                }, new BankAccountNumberType1A()),
                new Bank("Skandiabanken", new[] { new Range(9150, 9169) }, new BankAccountNumberType1B()),
                new Bank("Svea Bank", new[] { new Range(9660, 9669) }, new BankAccountNumberType1B()),
                new Bank("Swedbank", new[] { new Range(7000, 7999) }, new BankAccountNumberType1A()),
                
                new Bank("Danske Bank", new[] { new Range(9180, 9189) }, new BankAccountNumberType2A()),
                new Bank("Handelsbanken", new[] { new Range(6000, 6999) }, new BankAccountNumberType2B()),
                new Bank("Nordea", new[]
                {
                    new Range(3300, 3300),
                    new Range(3782, 3782)
                }, new BankAccountNumberType2A()),
                new Bank("Nordea Plusgirot", new[]
                {
                    new Range(9500, 9549),
                    new Range(9960, 9969)
                }, new BankAccountNumberType2C()),
                new Bank("Riksgälden", new[] { new Range(9890, 9899) }, new BankAccountNumberType2A()),
                new Bank("Sparbanken Syd", new[] { new Range(9570, 9579) }, new BankAccountNumberType2A()),
                new Bank("Swedbank", new[]
                {
                    // Adding an extra 5-digit case to catch their 5 digit sorting codes
                    // Source: https://www.swedbank.se/privat/kort-och-betala/konton-for-in-och-utbetalningar/clearingnummer.html
                    new Range(8000, 8999)
                }, new BankAccountNumberType2C()), // Allowing 11 here in case clearingnumber is sent as the first four instead of the first five
                new Bank("Swedbank", new[] { new Range(9300, 9349) }, new BankAccountNumberType2A())
            };
        }
    }

    public bool HasSortingCode(string sortingCode) => SortingCodeRange.Any(s => s.IsInRange(int.Parse(sortingCode)));
}