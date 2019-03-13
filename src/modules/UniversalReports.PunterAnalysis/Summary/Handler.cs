using System.Threading;
using System.Threading.Tasks;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : HandlerBase, IRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService)
            : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            return await Handle<Criteria, SummaryModel>(request);
        }

    }
}