using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using MediatR;
using Olympus.FPSAPI.Client;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public class Handler : IAsyncRequestHandler<HttpParameterJson, List<UserRoleModel>>
    {
        private readonly IDynamicRepository repository;

        private readonly FraudServiceWrapper fraudServiceWrapper;

        private readonly ConfigurationService configurationService;

        public Handler(ConfigurationService configurationService, FraudServiceWrapper fraudServiceWrapper, IDynamicRepository repository)
        {
            this.configurationService = configurationService;
            this.fraudServiceWrapper = fraudServiceWrapper;
            this.repository = repository;
        }

        public async Task<List<UserRoleModel>> Handle(HttpParameterJson message)
        {
            var site = await GetSiteName(message.CustId).ConfigureAwait(false);
            var associatedCustomers = await fraudServiceWrapper.GetAssociatedCustomers(configurationService.FraudSystemApi, message.Username, site.Name, site.IsCreditSite).ConfigureAwait(false);
            var usernames = associatedCustomers.Select(c => c.Account);
            var model = await GetAccountRoles(usernames).ConfigureAwait(false);

            return new List<UserRoleModel>(model);
        }

        private async Task<Site> GetSiteName(int custId)
        {
            var criteria = new UserSiteQueryCriteria { CustId = custId };

            return await repository.GetAsync<Site>(criteria).ConfigureAwait(false);
        }

        private async Task<IEnumerable<UserRoleModel>> GetAccountRoles(IEnumerable<string> usernames)
        {
            var listUsername = string.Join(",", usernames);
            var criteria = new UserRoleQueryCriteria { ListUserName = listUsername };

            return await repository.FetchAsync<UserRoleModel>(criteria).ConfigureAwait(false);
        }
    }
}