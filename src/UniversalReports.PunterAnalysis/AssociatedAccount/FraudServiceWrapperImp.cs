using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UniversalReports.Core.Configurations;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    public interface FraudServiceWrapper
    {
        Task<List<UserDevice>> GetAssociatedUsers(string username, string siteName);
    }

    public class FraudServiceWrapperImp : FraudServiceWrapper
    {
        private readonly ApplicationConfigurationService configurationService;

        public FraudServiceWrapperImp(ApplicationConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public async Task<List<UserDevice>> GetAssociatedUsers(string username, string siteName)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = configurationService.FraudSystemAPI;

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var path = $"{baseAddress}/associatedaccounts/{username}/{siteName}";
                var response = await client.GetAsync(path);
                return response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<List<UserDevice>>()
                    : new List<UserDevice>();
            }
        }
    }
}
