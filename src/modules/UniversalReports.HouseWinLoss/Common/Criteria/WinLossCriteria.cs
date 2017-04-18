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

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [SpParam(Ignored = true)]
        public string Source { get; set; }

        public override bool IsValid() => true;

        protected void Update(BalanceUpSource source)
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