using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Racing.MatchDetail
{
    public class LeagueWinLoss
    {
        public string LeagueName { get; set; }

        public List<WinLoss> Races { get; set; }

        public WinLoss Total { get; set; }
    }
}
