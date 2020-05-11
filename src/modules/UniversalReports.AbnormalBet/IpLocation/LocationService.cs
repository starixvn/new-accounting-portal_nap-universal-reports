using Fanex.Data.Repository;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.IpLocation
{
    public interface LocationService
    {
        Task<LocationModel> QueryIP(string ip);
    }

    public class LocationServiceImp : LocationService
    {
        private readonly IDynamicRepository repository;

        public LocationServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<LocationModel> QueryIP(string ip)
        {
            ip = string.IsNullOrEmpty(ip) ? string.Empty : ip.Trim();
            var criteria = new GetIPInfoCriteria { IP = ip };
            return await repository.GetAsync<LocationModel>(criteria);
        }
    }
}
