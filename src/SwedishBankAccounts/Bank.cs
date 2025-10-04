using System;
using System.Collections.Generic;
using System.Linq;

namespace SwedishBankAccounts;

/// <summary>
/// Defines a bank
/// </summary>
/// <param name="IbanId">The IBAN bank identifier code used in IBAN generation</param>
/// <param name="Name">The name of the bank</param>
/// <param name="SortingCodeRange">The ranges of sorting numbers used by the bank</param>
/// <param name="Bic">The BIC/SWIFT code for the bank</param>
public record Bank(
    string IbanId,
    string Name,
    SortingCodeRange[] SortingCodeRange,
    string? Bic = null
)
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
                new Bank(
                    "120",
                    "Danske Bank",
                    new[]
                    {
                        new SortingCodeRange(1200, 1399, new BankAccountNumberType1A()),
                        new SortingCodeRange(2400, 2499, new BankAccountNumberType1A()),
                    },
                    "DABASESX"
                ),
                new Bank(
                    "211",
                    "Juni Technology AB",
                    new[] { new SortingCodeRange(2110, 2119, new BankAccountNumberType1A()) },
                    "JUNTSEG2"
                ),
                new Bank(
                    "212",
                    "Steven AB",
                    new[] { new SortingCodeRange(2120, 2129, new BankAccountNumberType1A()) },
                    "SVVVSESS"
                ),
                new Bank(
                    "213",
                    "Zimpler AB",
                    new[] { new SortingCodeRange(2130, 2139, new BankAccountNumberType1A()) },
                    "ZIMPSES2"
                ),
                new Bank(
                    "214",
                    "Trustly Group",
                    new[] { new SortingCodeRange(2140, 2149, new BankAccountNumberType1B()) },
                    "TRLYSESS"
                ),
                new Bank(
                    "215",
                    "Revolut Bank",
                    new[] { new SortingCodeRange(2150, 2159, new BankAccountNumberType2D()) }
                ),
                new Bank(
                    "230",
                    "Ålandsbanken",
                    new[] { new SortingCodeRange(2300, 2399, new BankAccountNumberType1B()) },
                    "AABASESS"
                ),
                new Bank(
                    "300",
                    "Nordea",
                    new[]
                    {
                        new SortingCodeRange(1100, 1199, new BankAccountNumberType1A()),
                        new SortingCodeRange(1400, 2099, new BankAccountNumberType1A()),
                        new SortingCodeRange(3000, 3299, new BankAccountNumberType1A()),
                        new SortingCodeRange(3300, 3300, new BankAccountNumberType2A()),
                        new SortingCodeRange(3301, 3399, new BankAccountNumberType1A()),
                        new SortingCodeRange(3410, 3781, new BankAccountNumberType1A()),
                        new SortingCodeRange(3782, 3782, new BankAccountNumberType2A()),
                        new SortingCodeRange(3783, 3999, new BankAccountNumberType1A()),
                        new SortingCodeRange(4000, 4999, new BankAccountNumberType1B()),
                    },
                    "NDEASESS"
                ),
                new Bank(
                    "500",
                    "SEB",
                    new[]
                    {
                        new SortingCodeRange(5000, 5999, new BankAccountNumberType1A()),
                        new SortingCodeRange(9120, 9124, new BankAccountNumberType1A()),
                        new SortingCodeRange(9130, 9149, new BankAccountNumberType1A()),
                    },
                    "ESSESESS"
                ),
                new Bank(
                    "600",
                    "Handelsbanken",
                    new[] { new SortingCodeRange(6000, 6999, new BankAccountNumberType2B()) },
                    "HANDSESS"
                ),
                new Bank(
                    "800",
                    "Swedbank",
                    new[]
                    {
                        new SortingCodeRange(7000, 7999, new BankAccountNumberType1A()),
                        new SortingCodeRange(8000, 8999, new BankAccountNumberType2C()),
                        new SortingCodeRange(9300, 9349, new BankAccountNumberType2A()),
                    },
                    "SWEDSESS"
                ),
                new Bank(
                    "902",
                    "Länsförsäkringar Bank",
                    new[]
                    {
                        new SortingCodeRange(3400, 3409, new BankAccountNumberType1A()),
                        new SortingCodeRange(9020, 9029, new BankAccountNumberType1B()),
                        new SortingCodeRange(9060, 9069, new BankAccountNumberType1A()),
                    },
                    "ELLFSESS"
                ),
                new Bank(
                    "904",
                    "Citibank",
                    new[] { new SortingCodeRange(9040, 9049, new BankAccountNumberType1B()) },
                    "CITISESX"
                ),
                new Bank(
                    "907",
                    "Multitude Bank",
                    new[] { new SortingCodeRange(9070, 9079, new BankAccountNumberType1A()) }
                ),
                new Bank(
                    "910",
                    "Nordnet Bank",
                    new[] { new SortingCodeRange(9100, 9109, new BankAccountNumberType1B()) },
                    "NNSESES1"
                ),
                new Bank(
                    "915",
                    "Skandiabanken",
                    new[] { new SortingCodeRange(9150, 9169, new BankAccountNumberType1B()) },
                    "SKIASESS"
                ),
                new Bank(
                    "917",
                    "Ikano Bank",
                    new[] { new SortingCodeRange(9170, 9179, new BankAccountNumberType1A()) },
                    "IKANSE21"
                ),
                new Bank(
                    "918",
                    "Danske Bank",
                    new[] { new SortingCodeRange(9180, 9189, new BankAccountNumberType2A()) },
                    "DABASESX"
                ),
                new Bank(
                    "919",
                    "DNB Bank",
                    new[] { new SortingCodeRange(9190, 9199, new BankAccountNumberType1B()) },
                    "DNBASESX"
                ),
                new Bank(
                    "923",
                    "Marginalen Bank",
                    new[] { new SortingCodeRange(9230, 9239, new BankAccountNumberType1A()) },
                    "MARGSESS"
                ),
                new Bank(
                    "925",
                    "SBAB Bank",
                    new[] { new SortingCodeRange(9250, 9259, new BankAccountNumberType1A()) },
                    "SBAVSESS"
                ),
                new Bank(
                    "927",
                    "ICA Banken",
                    new[] { new SortingCodeRange(9270, 9279, new BankAccountNumberType1A()) },
                    "IBCASES1"
                ),
                new Bank(
                    "928",
                    "Resurs Bank",
                    new[] { new SortingCodeRange(9280, 9289, new BankAccountNumberType1A()) },
                    "RESUSE21"
                ),
                new Bank(
                    "939",
                    "Landshypotek",
                    new[] { new SortingCodeRange(9390, 9399, new BankAccountNumberType1B()) },
                    "LAHYSESS"
                ),
                new Bank(
                    "940",
                    "Forex Bank",
                    new[] { new SortingCodeRange(9400, 9449, new BankAccountNumberType1A()) },
                    "FORXSES1"
                ),
                new Bank(
                    "946",
                    "Santander Consumer Bank",
                    new[] { new SortingCodeRange(9460, 9469, new BankAccountNumberType1A()) },
                    "BSNOSESS"
                ),
                new Bank(
                    "947",
                    "BNP Paribas",
                    new[] { new SortingCodeRange(9470, 9479, new BankAccountNumberType1B()) },
                    "FTSBSESS"
                ),
                new Bank(
                    "950",
                    "Nordea Plusgirot",
                    new[]
                    {
                        new SortingCodeRange(9500, 9549, new BankAccountNumberType2C()),
                        new SortingCodeRange(9960, 9969, new BankAccountNumberType2C()),
                    },
                    "NDEASESS"
                ),
                new Bank(
                    "955",
                    "Avanza Bank",
                    new[]
                    {
                        new SortingCodeRange(9550, 9564, new BankAccountNumberType1B()),
                        new SortingCodeRange(9565, 9569, new BankAccountNumberType2D()),
                    },
                    "AVANSES1"
                ),
                new Bank(
                    "957",
                    "Sparbanken Syd",
                    new[] { new SortingCodeRange(9570, 9579, new BankAccountNumberType2A()) },
                    "SPSDSE23"
                ),
                new Bank(
                    "958",
                    "Aion Bank",
                    new[] { new SortingCodeRange(9580, 9589, new BankAccountNumberType1A()) }
                ),
                new Bank(
                    "959",
                    "EP Bank",
                    new[] { new SortingCodeRange(9590, 9599, new BankAccountNumberType1B()) },
                    "ERPFSES2"
                ),
                new Bank(
                    "960",
                    "Banking Circle",
                    new[] { new SortingCodeRange(9600, 9609, new BankAccountNumberType2D()) },
                    "BCIRSE22XXX"
                ),
                new Bank(
                    "963",
                    "Lån & Spar Bank",
                    new[] { new SortingCodeRange(9630, 9639, new BankAccountNumberType1A()) },
                    "LOSADKKK"
                ),
                new Bank(
                    "964",
                    "Nordax Bank",
                    new[] { new SortingCodeRange(9640, 9649, new BankAccountNumberType1B()) },
                    "NOFBSES1"
                ),
                new Bank(
                    "965",
                    "MedMera Bank AB",
                    new[] { new SortingCodeRange(9650, 9659, new BankAccountNumberType1A()) },
                    "MEMMSE21"
                ),
                new Bank(
                    "966",
                    "Svea Bank",
                    new[] { new SortingCodeRange(9660, 9669, new BankAccountNumberType1B()) },
                    "SVEASES1"
                ),
                new Bank(
                    "967",
                    "JAK Medlemsbank",
                    new[] { new SortingCodeRange(9670, 9679, new BankAccountNumberType1B()) },
                    "JAKMSE22"
                ),
                new Bank(
                    "968",
                    "Bluestep Bank",
                    new[] { new SortingCodeRange(9680, 9689, new BankAccountNumberType1A()) },
                    "BSTPSESS"
                ),
                new Bank(
                    "970",
                    "Ekobanken",
                    new[] { new SortingCodeRange(9700, 9709, new BankAccountNumberType1B()) },
                    "EKMLSE21"
                ),
                new Bank(
                    "971",
                    "Lunar Bank",
                    new[] { new SortingCodeRange(9710, 9719, new BankAccountNumberType1B()) }
                ),
                new Bank(
                    "975",
                    "Northmill Bank",
                    new[] { new SortingCodeRange(9750, 9759, new BankAccountNumberType1B()) },
                    "NOHLSESS"
                ),
                new Bank(
                    "978",
                    "Klarna Bank",
                    new[] { new SortingCodeRange(9780, 9789, new BankAccountNumberType1B()) },
                    "KLRNSESS"
                ),
                new Bank(
                    "989",
                    "Riksgälden",
                    new[]
                    {
                        new SortingCodeRange(9880, 9889, new BankAccountNumberType1B()),
                        new SortingCodeRange(9890, 9899, new BankAccountNumberType2A()),
                    }
                ),
            };
        }
    }

    /// <summary>
    /// Determines whether this bank supports the specified sorting code
    /// </summary>
    /// <param name="sortingCode">The sorting code to check</param>
    /// <returns>True if the bank supports the sorting code, otherwise false</returns>
    public bool HasSortingCode(string sortingCode) => SortingCode(sortingCode) != null;

    /// <summary>
    /// Gets the sorting code range that contains the specified sorting code
    /// </summary>
    /// <param name="sortingCode">The sorting code to find the range for</param>
    /// <returns>The sorting code range if found, otherwise null</returns>
    public SortingCodeRange? SortingCode(string sortingCode) =>
        SortingCodeRange.FirstOrDefault(s => s.IsInRange(int.Parse(sortingCode)));

    /// <summary>
    /// Returns the bank name as string representation
    /// </summary>
    /// <returns>The name of the bank</returns>
    public override string ToString() => Name;

    /// <summary>
    /// Finds a bank and its sorting code range based on the given sorting code
    /// </summary>
    /// <param name="sortingCode">The sorting code to search for</param>
    /// <returns>A tuple containing the bank and sorting code range, or null values if not found</returns>
    public static (Bank? Bank, SortingCodeRange? sortingCodeRange) FindBank(string sortingCode)
    {
        var bank = Banks.FirstOrDefault(b => b.HasSortingCode(sortingCode));
        if (bank == null)
            return (null, null);
        var sortingCodeRange = bank.SortingCode(sortingCode);
        return (bank, sortingCodeRange);
    }
}
