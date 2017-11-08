using System.Collections.Generic;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public class LeagueWinLoss
    {

        public string League { get; set; }

        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}
