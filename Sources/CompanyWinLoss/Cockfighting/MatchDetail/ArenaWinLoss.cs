using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class ArenaWinLoss
    {
        public string ArenaName { get; set; }
        public List<WinLoss> Matches { get; set; }

        public WinLoss Total { get; set; }
    }
}
