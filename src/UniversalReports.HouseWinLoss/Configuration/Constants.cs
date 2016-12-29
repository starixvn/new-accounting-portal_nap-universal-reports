namespace UniversalReports.HouseWinLoss.Configuration
{
    public static class Constants
    {
        public const string SheetName = "House Win Loss by Products";

        public const int LiveDefault = 2;

        public const int HedgeDefault = 2;

        public const int SystemParlayBetType = 29;

        public const string SiteDefault = "ALL";

        public const int SportTypeSoccer = 1;

        public static readonly string RM = "RM";

        public static string[] NameSportsbook
        {
            get
            {
                return new[]
                {
                    "Soccer",
                    "Metric Gaming - Superlive",
                    "Other Sports",
                    "Parlay"
                };
            }
        }

        public static string[] ProductsExtraPT
        {
            get
            {
                return new[]
                {
                    "Soccer",
                    "Metric Gaming - Superlive",
                    "Other Sports",
                    "Parlay",
                    "Sportsbook Total",
                    "Number Game",
                    "Casino",
                    "Live Casino",
                    "MBC_RNG Casino",
                    "Virtual Sports",
                    "Keno",
                    "Bingo",
                    "Gold Deluxe",
                    "Non-Sports Total",
                    "NG2"
                };
            }
        }

        public static string[] CasinoProductsNonExtraPT
        {
            get
            {
                return new[]
                {
                    "Microgaming - Live Casino",
                    "AG Casino",
                    "Allbet",
                    "Microgaming - RNG Casino",
                    "Macau"
                };
            }
        }
    }
}