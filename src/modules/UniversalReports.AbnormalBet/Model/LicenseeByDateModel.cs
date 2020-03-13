namespace UniversalReports.AbnormalBet.Model
{
    public class LicenseeByDateModel
    {
        public string Date { get; set; }

        public string Licensee { get; set; }

        public int CurrencyId { get; set; }

        public string Currency { get; set; }

        public string League { get; set; }

        public int HomeTeamId { get; set; }

        public string HomeTeamName { get; set; }

        public int AwayTeamId { get; set; }

        public string AwayTeamName { get; set; }

        public string Reason { get; set; }

        public bool IsLive { get; set; }

        public string Bettype { get; set; }

        public string Choice { get; set; }

        public string BettingScore { get; set; }

        public decimal HDPOU { get; set; }

        public string HTScore { get; set; }

        public string FinalScore { get; set; }

        public decimal MemberTurnover { get; set; }

        public decimal MemberTurnoverRM { get; set; }
    }
}
