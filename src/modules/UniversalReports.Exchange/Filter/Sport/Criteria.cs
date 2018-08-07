using Fanex.Data.Repository;

namespace UniversalReports.Exchange.Filter.Sport
{
    public class Criteria : CriteriaBase
    {
        public override string GetSettingKey() => "Exchange-SportQuery";

        public override bool IsValid() => true;
    }
}