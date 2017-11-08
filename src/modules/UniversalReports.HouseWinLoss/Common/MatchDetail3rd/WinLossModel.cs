using System.Collections.Generic;

namespace UniversalReports.HouseWinLoss.Common.MatchDetail3rd
{
    public class WinLossModel
    {
        public List<LeagueWinLoss> Leagues { get; set; }

        public WinLoss Total { get; set; }
    }
}
