using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class LeagueWinLoss
    {
        public string Name { get; set; }

        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}
