using Fanex.Data.Repository;
using System;

namespace NAP.Reports.CompanyWinLoss.Services.MainReport
{
    public class ProductWinLossCriteria : CriteriaBase
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string ProductName { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override string GetSettingKey()
        {
            return $"MainReport-{Source}-{ProductName}";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
