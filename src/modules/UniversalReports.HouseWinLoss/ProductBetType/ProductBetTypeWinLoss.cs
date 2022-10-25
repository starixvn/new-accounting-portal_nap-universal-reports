using System.Collections.Generic;
using UniversalReports.HouseWinLoss.Common.Models;

namespace UniversalReports.HouseWinLoss.ProductBetType
{
    public class ProductBetTypeWinLoss
    {
        public IEnumerable<WinLoss> BetTypes { get; set; }

        public WinLoss GrandTotal { get; set; }
    }
}
