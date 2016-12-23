using Fanex.Data;
using Fanex.Data.Repository;
using System;
using UniversalReports.HouseWinLoss.Common.BalanceUpServices;

namespace UniversalReports.HouseWinLoss.Common.Criteria
{
    public class WinLossCriteria : CriteriaBase
    {
        [SpParam(Ignored = true)]
        public bool NormalMode { get; set; } = true;

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid() => true;

        protected virtual void Update(BalanceUpSource source)
        {
            StartDate = source.StartDate;
            EndDate = source.EndDate;
            Source = source.Source;
        }

        public override string GetSettingKey()
        {
            throw new NotImplementedException();
        }
    }
}