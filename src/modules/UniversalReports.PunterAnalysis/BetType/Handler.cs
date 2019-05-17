using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class Handler : HandlerBase, IRequestHandler<HttpParameterJson, SummaryEntity<BetTypeModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<BetTypeModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, BetTypeModel>(request);
        }
    }
}