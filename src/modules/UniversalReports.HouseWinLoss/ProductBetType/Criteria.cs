using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Configuration;

namespace UniversalReports.HouseWinLoss.ProductBetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public string SiteType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public bool IsNoDraw { get; set; }

        public int IsSabaSport { get; set; } = Constants.IsSabaSportDefault;

        public int AliasProductID { get; set; }

        public int PermissionProfileID { get; set; }

        public bool IsMajor { get; set; }

        public override string GetSettingKey() => $"HouseWinlossByProducts_Lvl2_BettypePerformance";
    }
}
