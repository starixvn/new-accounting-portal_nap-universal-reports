using System.Collections.Generic;

namespace NAP.Reports.CompanyWinLoss.Models
{
    public class NumberGameLeagueWinLoss
    {
        public string LeagueName { get; set; }

        public List<WinLoss> Matches { get; set; }
    }
}
