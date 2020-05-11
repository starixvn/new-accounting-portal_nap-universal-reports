using Fanex.Data.Repository;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class GetIPInfoCriteria : CriteriaBase
    {
        public string IP { get; set; }

        public override string GetSettingKey() => "Acc_GetIPInfo_Full";

        public override bool IsValid() => true;
    }
}
