namespace SwedishBankAccounts.UnitTests;

public abstract class UnitTests
{
    protected Fixture Fixture { get; }

    protected UnitTests()
    {
        Fixture = new Fixture();
    }

    public static IEnumerable<object[]> ValidAccountNumbers =>
        new List<object[]>
        {
            new object[] { "9071, 417 23 83", "Multitude Bank", InitOptions.Strict },
            new object[] { "6683764450808", "Handelsbanken", InitOptions.Strict },
            new object[] { "8424-4,983 189 224-6", "Swedbank", InitOptions.Strict },
            new object[] { "8351-9,392 242 224-5", "Swedbank", InitOptions.Strict },
            new object[] { "8129-9,043 386 711-6", "Swedbank", InitOptions.Strict },
            new object[] { "3300 000620-5124", "Nordea", InitOptions.Strict },
            new object[] { "9585, 612345740", "Aion Bank", InitOptions.Strict },
            new object[] { "9553-5894364", "Avanza Bank", InitOptions.Strict },
            new object[] { "9683,143 579 155", "Bluestep Bank", InitOptions.Strict },
            new object[] { "9472,456 987 154", "BNP Paribas", InitOptions.Strict },
            new object[] { "9045,987 456 128", "Citibank", InitOptions.Strict },
            new object[] { "1255,6548711", "Danske Bank", InitOptions.Strict },
            new object[] { "9199,321 8647", "DNB Bank", InitOptions.Strict },
            new object[] { "9704,861 957 3564", "Ekobanken", InitOptions.Strict },
            new object[] { "9597 984 216 868", "EP Bank", InitOptions.Strict },
            new object[] { "9273-956 609 3", "ICA Banken", InitOptions.Strict },
            new object[] { "9178-516 4155", "Ikano Bank", InitOptions.Strict },
            new object[] { "9674-9871358", "JAK Medlemsbank", InitOptions.Strict },
            new object[] { "97891111113", "Klarna Bank", InitOptions.Strict },
            new object[] { "9398-2159875", "Landshypotek", InitOptions.Strict },
            new object[] { "9714-8924679", "Lunar Bank", InitOptions.Strict },
            new object[] { "9630, 6541128", "Lån & Spar Bank", InitOptions.Strict },
            new object[] { "3400, 123 4645", "Länsförsäkringar Bank", InitOptions.Strict },
            new object[] { "9060, 541 6877", "Länsförsäkringar Bank", InitOptions.Strict },
            new object[] { "9234, 879 1552", "Marginalen Bank", InitOptions.Strict },
            new object[] { "9646, 1230477", "Nordax Bank", InitOptions.Strict },
            new object[] { "1150, 9743685", "Nordea", InitOptions.Strict },
            new object[] { "4564, 154 1970", "Nordea", InitOptions.Strict },
            new object[] { "9108 876 1587", "Nordnet Bank", InitOptions.Strict },
            new object[] { "9752-6546873", "Northmill Bank", InitOptions.Strict },
            new object[] { "9280 689 1477", "Resurs Bank", InitOptions.Strict },
            new object[] { "9882 134 6325", "Riksgälden", InitOptions.Strict },
            new object[] { "9462 613 5412", "Santander Consumer Bank", InitOptions.Strict },
            new object[] { "9252 132 2148", "SBAB Bank", InitOptions.Strict },
            new object[] { "5140 321 5642", "SEB", InitOptions.Strict },
            new object[] { "9160 741 6680", "Skandiabanken", InitOptions.Strict },
            new object[] { "9664 446 5511", "Svea Bank", InitOptions.Strict },
            new object[] { "9180 331 4218", "Danske Bank", InitOptions.Strict },
            new object[] { "9530 364 8748", "Nordea Plusgirot", InitOptions.Strict },
            new object[] { "9892 398 7468", "Riksgälden", InitOptions.Strict },
            new object[] { "9578 633 1128", "Sparbanken Syd", InitOptions.Strict },
            new object[] { "9340 321 4681", "Swedbank", InitOptions.Strict },
            new object[] { "9340 321 4682", "Swedbank", InitOptions.Lax },
            new object[] { "9565-0000012343", "Avanza Bank", InitOptions.Strict }
        };
}