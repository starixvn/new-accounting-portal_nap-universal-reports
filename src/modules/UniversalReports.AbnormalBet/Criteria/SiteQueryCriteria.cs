using Fanex.Data.Repository;

namespace UniversalReports.AbnormalBet.Criteria
{
    public class SiteQueryCriteria : CriteriaBase
    {
        public override bool IsValid() => true;

        public override string GetSettingKey() => $"Acc_Rpt_AbnormalBet_LicenseeSel";
    }
}
