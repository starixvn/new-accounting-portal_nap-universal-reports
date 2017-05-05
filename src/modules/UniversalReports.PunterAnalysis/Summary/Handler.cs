using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, ReportModelBase<SummaryModel>>
    {
        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService)
            : base(mapper, punterAnalysisService)
        {
        }

        public async Task<ReportModelBase<SummaryModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SummaryModel>(message);
        }
    }
}
