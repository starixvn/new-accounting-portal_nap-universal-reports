using Fanex.Data.Repository;

namespace UniversalReports.NG2Statistic.Filter
{
    public class CurrencyCriteria : CriteriaBase
    {
        public override string GetSettingKey()
        {
            return "NG2-Statistics-Currencies";
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
