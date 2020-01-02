using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.GameBetType.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.GameBetType
{
    public class Handler : HandlerBase, IRequestHandler<HttpParameterJson, SummaryEntity<GameBetTypeModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<GameBetTypeModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, GameBetTypeModel>(request);
        }
    }
}