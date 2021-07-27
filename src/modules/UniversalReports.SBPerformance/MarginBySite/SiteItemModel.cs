namespace UniversalReports.SBPerformance.MarginBySite
{
    public class SiteItemModel
    {
        public int Id { get; set; }

        public string Sport { get; set; }

        public int BetCount { get; set; }

        public int ActiveMembers { get; set; }

        public decimal RealIncome { get; set; }

        public decimal RealTurnover { get; set; }

        public decimal RealMargin { get; set; }
    }
}