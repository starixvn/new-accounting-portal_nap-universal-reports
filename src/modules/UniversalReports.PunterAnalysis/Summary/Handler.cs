using System.Threading.Tasks;
using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService)
            : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SummaryModel>(message).ConfigureAwait(false);
        }
    }
}