using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class NumberGameMatchDetailWinLoss
    {
        public List<NumberGameLeagueWinLoss> Leagues { get; set; }

        public WinLoss Total { get; set; }
    }
}
