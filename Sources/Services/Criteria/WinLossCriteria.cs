using Fanex.Data.Repository;
using System;

namespace NAP.Reports.CompanyWinLoss.Services.Criteria
{
    public class WinLossCriteria : CriteriaBase
    {
        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
