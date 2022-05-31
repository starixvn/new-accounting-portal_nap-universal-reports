using Fanex.Data.Repository;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.Common.Services
{
    public interface PermissionFilterService
    {
        int GetPermissionProfileId(string functionKeyValue);
    }

    public class PermissionFilterServiceImp : PermissionFilterService
    {
        private readonly IDynamicRepository repository;

        public PermissionFilterServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }
     
        public int GetPermissionProfileId(string functionKeyValue)
        {
            var criteria = new PermissionCriteria
            {
                FunctionKey = functionKeyValue
            };

            return repository.Get<int>(criteria);
        }
    }
}
