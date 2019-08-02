using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public class ChargeCommissionModel
    {
        public List<WinLoss> Winloss { get; set; }

        public WinLoss Total { get; set; }
    }
}