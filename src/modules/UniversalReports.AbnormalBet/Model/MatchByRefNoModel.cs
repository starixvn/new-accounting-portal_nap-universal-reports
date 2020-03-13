namespace UniversalReports.AbnormalBet.Model
{
    public class MatchByRefNoModel
    {
        public string RefNo { get; set; }

        public string Sport { get; set; }

        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public int HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public int AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public string Reason { get; set; }

        public decimal Odds { get; set; }

        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public decimal Stake { get; set; }

        public decimal HDP { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public string TransTime { get; set; }

        public string IP { get; set; }

        public string Location { get; set; }
    }
}
