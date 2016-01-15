using Fanex.Data.Repository;
using System;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class WinLossCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-Main-{Source}";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
