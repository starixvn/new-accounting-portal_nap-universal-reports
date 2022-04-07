using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
  public  class UniversalThirdPartyBetTypeCriteria : WinLossCriteria
    {
        public bool IsNoDraw { get; set; }

        public int AliasProductID { get; set; }

        public int PermissionProfileID { get; } = 1;

        public int IsLive { get; set; }

        public int SportType { get; set; }

        public override string GetSettingKey() => $"HouseWinlossByProducts_LvlN_3rd_Bettype";
    }
}
