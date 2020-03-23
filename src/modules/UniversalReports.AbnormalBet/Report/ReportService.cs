using AutoMapper;
using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Report
{
    public interface ReportService
    {
        Task<IEnumerable<MemberModel>> QueryMember(MemberHttpParameter memberParameter);

        Task<IEnumerable<LicenseeModel>> QueryLicensee(LicenseeHttpParameter memberParameter);
    }

    public class ReportServiceImp : ReportService
    {
        private readonly IDynamicRepository repository;

        public ReportServiceImp(IDynamicRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LicenseeModel>> QueryLicensee(LicenseeHttpParameter memberParameter)
        {
            var criteria = Mapper.Map<LicenseeQueryCriteria>(memberParameter);
            return await repository.FetchAsync<LicenseeModel>(criteria);
        }

        public async Task<IEnumerable<MemberModel>> QueryMember(MemberHttpParameter memberParameter)
        {
            var criteria = Mapper.Map<MemberQueryCriteria>(memberParameter);
            return await repository.FetchAsync<MemberModel>(criteria);
        }
    }
}
