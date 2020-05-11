using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.IpLocation;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Report
{
    public interface ReportService
    {
        Task<IEnumerable<MemberModel>> QueryMember(MemberQueryCriteria criteria);

        Task<IEnumerable<LicenseeModel>> QueryLicensee(LicenseeQueryCriteria criteria);
    }

    public class ReportServiceImp : ReportService
    {
        private readonly IDynamicRepository repository;

        private readonly LocationService locationService;

        public ReportServiceImp(IDynamicRepository repository, LocationService locationService)
        {
            this.repository = repository;
            this.locationService = locationService;
        }

        public async Task<LocationModel> QueryIP(string ip)
        {
            ip = string.IsNullOrEmpty(ip) ? string.Empty : ip.Trim();
            var criteria = new GetIPInfoCriteria { IP = ip };
            return await repository.GetAsync<LocationModel>(criteria);
        }

        public async Task<IEnumerable<LicenseeModel>> QueryLicensee(LicenseeQueryCriteria criteria)
        {
            return await repository.FetchAsync<LicenseeModel>(criteria);
        }

        public async Task<IEnumerable<MemberModel>> QueryMember(MemberQueryCriteria criteria)
        {
            var members = await repository.FetchAsync<MemberModel>(criteria);

            foreach (var item in members)
            {
                item.Location = await GetLocationFromIp(item.IP);
            }

            return members;
        }

        private async Task<string> GetLocationFromIp(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return string.Empty;
            }

            var locations = new List<string>();
            var ips = ip.Split(',').ToList();
            foreach (var i in ips)
            {
                var location = await locationService.QueryIP(i);
                var list = new List<string>
                {
                    location.CountryLong,
                    location.IpRegion,
                    location.IpCity
                };

                locations.Add(string.Join(", ", list.Where(s => s.Length > 2)));

            }

            return string.Join("; ", locations);
        }
    }
}
