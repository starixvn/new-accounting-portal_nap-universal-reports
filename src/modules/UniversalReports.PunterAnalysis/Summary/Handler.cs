using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : IRequestHandler<HttpParameterJson, SummaryEntity<SummaryModel>>
    {
        private readonly SummaryService summaryService;

        public Handler(SummaryService summaryService)
        {
            this.summaryService = summaryService;
        }

        public async Task<SummaryEntity<SummaryModel>> Handle(HttpParameterJson request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<Criteria>(request);
            var summaries = await summaryService.GetSummaries(criteria);
            return summaries;
        }
    }
}