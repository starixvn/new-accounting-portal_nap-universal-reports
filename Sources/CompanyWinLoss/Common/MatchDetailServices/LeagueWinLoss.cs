using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public class LeagueWinLoss
    {
        public string LeagueName { get; set; }

        public List<MatchDetailWinLoss> Matches { get; set; }

        public MatchDetailWinLoss Total { get; set; }
    }
}