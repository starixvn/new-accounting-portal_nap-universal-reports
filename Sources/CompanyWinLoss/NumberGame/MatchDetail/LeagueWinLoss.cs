using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.NumberGame.MatchDetail
{
    public class LeagueWinLoss
    {
        public string LeagueName { get; set; }

        public List<WinLoss> Matches { get; set; }
    }
}
