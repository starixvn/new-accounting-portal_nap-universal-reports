namespace UniversalReports.CN88WinLoss.Products
{
    public static class ProductConstant
    {
        public const string RM = "RM";

        public const string OtherSports = "Other Sports";

        public const string Soccer = "Soccer";

        public static string[] NameSportsbook => new[]
        {
            "Soccer",
            "Other Sports",
            "Parlay"
        };

        public static string[] SoccerPermissionProducts => new[]
       {
            "Soccer",
            "Parlay",
            "RM"
        };

        public static string[] OtherSportsPermissionProducts => new[]
        {
            "Other Sports",
            "Parlay"
        };
    }
}
