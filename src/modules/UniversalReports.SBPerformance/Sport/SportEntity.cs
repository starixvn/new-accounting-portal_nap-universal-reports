namespace UniversalReports.SBPerformance.Sport
{
    public class SportEntity
    {
        public int Id { get; set; }

        public string Sport { get; set; }

        public int BetCount { get; set; }

        public int ActiveMembers { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal RealMargin => RealTurnover == 0 ? 0 : RealIncome / RealTurnover;

        public static SportEntity operator +(SportEntity a, SportEntity b)
        {
            return new SportEntity
            {
                Id = 0,
                Sport = "Total",
                BetCount = a.BetCount + b.BetCount,
                ActiveMembers = a.ActiveMembers + b.ActiveMembers,
                RealIncome = a.RealIncome + b.RealIncome,
                RealTurnover = a.RealTurnover + b.RealTurnover
            };
        }
    }
}