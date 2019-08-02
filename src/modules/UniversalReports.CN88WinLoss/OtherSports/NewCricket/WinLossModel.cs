using System.Collections.Generic;
using UniversalReports.CN88WinLoss.Common.Models;

namespace UniversalReports.CN88WinLoss.OtherSports.NewCricket
{
    public class WinLossModel
    {
        public List<WinLoss> WinLossNonChargedCom { get; set; }

        public ChargeCommissionModel WinLossChargedCom { get; set; }

        public WinLoss GrandTotal { get; set; }
    }
}