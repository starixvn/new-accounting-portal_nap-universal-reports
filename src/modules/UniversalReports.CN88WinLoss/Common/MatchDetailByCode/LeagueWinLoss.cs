using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.Common.MatchDetailByCode
{
    public class LeagueWinLoss
    {
        public string Name { get; set; }

        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}