namespace UniversalReports.SBPerformance.League
{
    public class LeagueEntity
    {
        public int Id { get; set; }

        public string League { get; set; }

        public int BetCount { get; set; }

        public int ActiveMembers { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal RealMargin => RealTurnover == 0 ? 0 : RealIncome / RealTurnover;

        public static LeagueEntity operator +(LeagueEntity a, LeagueEntity b)
        {
            return new LeagueEntity
            {
                Id = 0,
                League = "Total",
                BetCount = a.BetCount + b.BetCount,
                ActiveMembers = a.ActiveMembers + b.ActiveMembers,
                RealIncome = a.RealIncome + b.RealIncome,
                RealTurnover = a.RealTurnover + b.RealTurnover
            };
        }
    }
}