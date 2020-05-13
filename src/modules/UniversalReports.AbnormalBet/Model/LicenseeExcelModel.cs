using Epplus.Mapper.Annotations;

namespace UniversalReports.AbnormalBet.Model
{
    public class LicenseeExcelModel
    {
        [Cell("A5")]
        public string Date { get; set; }

        [Cell("B5")]
        public string Licensee { get; set; }

        [Cell("C5")]
        public string Currency { get; set; }

        [Cell("D5")]
        public string League { get; set; }

        [Cell("E5")]
        public string Match { get; set; }

        [Cell("F5")]
        public string Reason { get; set; }

        [Cell("G5")]
        public string Live { get; set; }

        [Cell("H5")]
        public string BetType { get; set; }

        [Cell("I5")]
        public string Choice { get; set; }

        [Cell("J5")]
        public string BettingScore { get; set; }

        [Cell("K5")]
        public decimal HDPOU { get; set; }

        [Cell("L5")]
        public string HTScore { get; set; }

        [Cell("M5")]
        public string FinalScore { get; set; }

        [Cell("N5")]
        public decimal MemberTO { get; set; }

        [Cell("O5")]
        public decimal MemberTORM { get; set; }
    }
}
