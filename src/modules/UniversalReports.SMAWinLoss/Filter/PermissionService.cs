using Fanex.Data.Repository;
using System.Threading.Tasks;

namespace UniversalReports.SMAWinLoss.Filter
{
    public interface PermissionService
    {
        Task<int> GetPermissionProfileId(string functionKey);
    }

    public class PermissionServiceImp : PermissionService
    {
        private readonly IDynamicRepository repository;

        public PermissionServiceImp(
            IDynamicRepository repository)
        {
            this.repository = repository;
           
        }

        public async Task<int> GetPermissionProfileId(string functionKey)
        {
            var criteria = new PermissionCriteria
            {
                FunctionKey = functionKey
            };

            return await repository.GetAsync<int>(criteria);
        }
    }
}
