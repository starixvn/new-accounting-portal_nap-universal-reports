using System.Collections.Generic;
using UniversalReports.CompanyWinLoss.Common.MatchDetailServices;

namespace UniversalReports.CompanyWinLoss.VirtualSports.SportsbookDetail
{
    public class WinLossModel
    {
        public List<MatchDetailWinLoss> Matches { get; set; }

        public MatchDetailWinLoss Total { get; set; }
    }
}