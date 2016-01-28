using System;
using Fanex.Data.Repository;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.Common.Criteria
{
    public abstract class WinLossCriteria : CriteriaBase
    {
        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        public abstract WinLossCriteria Clone(BalanceUpSource source);

        protected virtual void Update(BalanceUpSource source)
        {
            StartDate = source.StartDate;
            EndDate = source.EndDate;
            Source = source.Source;
        }
    }
}
