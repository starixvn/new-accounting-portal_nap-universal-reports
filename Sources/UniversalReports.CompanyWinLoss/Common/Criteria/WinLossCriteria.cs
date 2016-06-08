using Fanex.Data.Repository;
using System;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.Common.Criteria
{
    public class WinLossCriteria : CriteriaBase
    {
        [SpParam(Ignored = true)]
        public bool NormalMode { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid()
        {
            return true;
        }

        protected virtual void Update(BalanceUpSource source)
        {
            StartDate = source.StartDate;
            EndDate = source.EndDate;
            Source = source.Source;
        }
    }
}