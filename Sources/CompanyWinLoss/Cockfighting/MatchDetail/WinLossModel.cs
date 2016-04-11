using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class WinLossModel
    {
        public List<LeagueWinLoss> Arenas { get; set; }

        public MatchDetailWinLoss Total { get; set; }
    }
}