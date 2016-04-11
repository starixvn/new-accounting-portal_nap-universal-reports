using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Common.MatchDetailServices
{
    public class WinLossModel
    {
        public List<LeagueWinLoss> Leagues { get; set; }

        public MatchDetailWinLoss Total { get; set; }

        public List<MatchDetailWinLoss> RM { get; set; }
    }
}