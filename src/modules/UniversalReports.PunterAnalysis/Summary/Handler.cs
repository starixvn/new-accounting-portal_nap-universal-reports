using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService)
            : base(mapper, punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SummaryModel>(message);
        }
    }
}
