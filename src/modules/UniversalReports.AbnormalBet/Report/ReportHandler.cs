using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            return await service.QueryMember(request);
        }

        public async Task<IEnumerable<LicenseeModel>> Handle(LicenseeHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.QueryLicensee(request);
        }
    }
}
