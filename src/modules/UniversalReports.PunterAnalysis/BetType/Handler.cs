using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, ReportModelBase<BetTypeModel>>
    {
        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService) : base(mapper, punterAnalysisService)
        {
        }

        public async Task<ReportModelBase<BetTypeModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, BetTypeModel>(message);
        }
    }
}
