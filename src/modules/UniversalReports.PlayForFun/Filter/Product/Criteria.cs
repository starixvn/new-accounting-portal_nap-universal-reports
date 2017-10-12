using Fanex.Data.Repository;

namespace UniversalReports.PlayForFun.Filter.Product
{
    public class Criteria : CriteriaBase
    {
        public override string GetSettingKey() => "PlayForFun-ProductQuery";

        public override bool IsValid() => true;
    }
}