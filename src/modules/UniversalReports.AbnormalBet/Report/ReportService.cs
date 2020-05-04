using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
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

        public ReportServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LicenseeModel>> QueryLicensee(LicenseeQueryCriteria criteria)
        {
            return await repository.FetchAsync<LicenseeModel>(criteria);
        }

        public async Task<IEnumerable<MemberModel>> QueryMember(MemberQueryCriteria criteria)
        {
            return await repository.FetchAsync<MemberModel>(criteria);
        }
    }
}
