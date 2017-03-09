using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class UserRoleQueryCriteria : CriteriaBase
    {
        public string ListUserName { get; set; }

        public override string GetSettingKey() => "Punter-AssociatedAccount";

        public override bool IsValid() => true;
    }
}