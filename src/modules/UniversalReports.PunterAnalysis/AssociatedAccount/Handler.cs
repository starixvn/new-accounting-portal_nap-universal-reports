using Fanex.Data.Repository;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, List<UserRoleModel>>
    {
        private readonly IDynamicRepository repository;

        private readonly FraudServiceWrapper fraudServiceWrapper;

        public Handler(IDynamicRepository repository, FraudServiceWrapper fraudServiceWrapper)
        {
            this.repository = repository;
            this.fraudServiceWrapper = fraudServiceWrapper;
        }

        public async Task<List<UserRoleModel>> Handle(HttpParameterJson message)
        {
            var siteName = await GetSiteName(message.CustId).ConfigureAwait(false);
            var userDevices = await fraudServiceWrapper.GetAssociatedUsers(message.Username, siteName).ConfigureAwait(false);
            var model = await GetAccountRoles(userDevices).ConfigureAwait(false);

            return new List<UserRoleModel>(model);
        }

        private async Task<string> GetSiteName(int custId)
        {
            var criteria = new UserSiteQueryCriteria { CustId = custId };

            return await repository.GetAsync<string>(criteria).ConfigureAwait(false);
        }

        private async Task<IEnumerable<UserRoleModel>> GetAccountRoles(IEnumerable<UserDevice> userDevices)
        {
            var usernames = string.Join(",", userDevices.Select(u => u.Account));
            var criteria = new UserRoleQueryCriteria { ListUserName = usernames };

            return await repository.FetchAsync<UserRoleModel>(criteria).ConfigureAwait(false);
        }
    }
}
