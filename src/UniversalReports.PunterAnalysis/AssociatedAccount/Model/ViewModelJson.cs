using System.Collections.Generic;

namespace UniversalReports.PunterAnalysis.AssociatedAccount.Model
{
    public class ViewModelJson : List<UserRoleModel>
    {
        public ViewModelJson()
        {
        }

        public ViewModelJson(IEnumerable<UserRoleModel> collection) : base(collection)
        {
        }
    }
}
