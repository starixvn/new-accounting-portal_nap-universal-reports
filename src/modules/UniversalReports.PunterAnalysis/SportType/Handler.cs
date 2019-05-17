using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class Handler : HandlerBase, IRequestHandler<HttpParameterJson, SummaryEntity<SportTypeModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SportTypeModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, SportTypeModel>(request);
        }
    }
}