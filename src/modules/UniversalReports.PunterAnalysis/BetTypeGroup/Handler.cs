using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.BetTypeGroup.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetTypeGroup
{
    public class Handler : HandlerBase, IRequestHandler<HttpParameterJson, SummaryEntity<BetTypeGroupModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<BetTypeGroupModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, BetTypeGroupModel>(request);
        }
    }
}