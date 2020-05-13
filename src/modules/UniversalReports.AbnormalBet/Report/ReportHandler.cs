using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet.Report
{
    public class ReportHandler : IRequestHandler<LicenseeHttpParameter, IEnumerable<LicenseeModel>>,
         IRequestHandler<MemberHttpParameter, IEnumerable<MemberModel>>
    {
        private readonly ReportService service;

        public ReportHandler(ReportService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<MemberModel>> Handle(MemberHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<MemberQueryCriteria>(request);
            return await service.QueryMember(criteria);
        }

        public async Task<IEnumerable<LicenseeModel>> Handle(LicenseeHttpParameter request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<LicenseeQueryCriteria>(request);
            return await service.QueryLicensee(criteria);
        }
    }
}
