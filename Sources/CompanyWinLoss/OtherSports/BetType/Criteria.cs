using System;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;

namespace UniversalReports.CompanyWinLoss.OtherSports.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int SportType { get; set; }

        public override WinLossCriteria Clone(BalanceUpSource source)
        {
            var newCriteria = new Criteria();
            newCriteria.Update(source);
            newCriteria.SportType = SportType;
            return newCriteria;
        }

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-OtherSports-BetType-{Source}";
        }
    }
}
