using System.Collections.Generic;

namespace UniversalReports.CN88WinLoss.Common.MatchDetail
{
    public class LeagueWinLoss
    {
        public string LeagueName { get; set; }

        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}