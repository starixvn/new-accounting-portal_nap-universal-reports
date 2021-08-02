using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalReports.SBPerformance.TopWinningMember
{
    public class TopWinningMemberHandler : IRequestHandler<TopWinningMemberHttpParameter, SummaryEntity<TopWinningMemberItemModel>>
    {
        private readonly TopWinningMemberService service;

        public TopWinningMemberHandler(TopWinningMemberService service)
        {
            this.service = service;
        }

        public async Task<SummaryEntity<TopWinningMemberItemModel>> Handle(TopWinningMemberHttpParameter request, CancellationToken cancellationToken)
        {
            return await service.Query(request);
        }
    }
}