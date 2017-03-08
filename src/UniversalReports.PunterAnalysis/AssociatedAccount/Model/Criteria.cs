using Fanex.Data.Repository;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class Criteria : CriteriaBase
    {
        public string ListCustId { get; set; }

        public override string GetSettingKey() => "Punter-AssociatedAccount";

        public override bool IsValid() => true;
    }
}