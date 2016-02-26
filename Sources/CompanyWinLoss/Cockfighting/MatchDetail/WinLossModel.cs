using System.Collections.Generic;

namespace UniversalReports.CompanyWinLoss.Cockfighting.MatchDetail
{
    public class WinLossModel
    {
        public List<ArenaWinLoss> Arenas { get; set; }

        public WinLoss Total { get; set; }
    }
}
