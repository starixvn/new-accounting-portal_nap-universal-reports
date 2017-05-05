using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, ReportModelBase<SportTypeModel>>
    {
        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService) : base(mapper, punterAnalysisService)
        {
        }

        public async Task<ReportModelBase<SportTypeModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SportTypeModel>(message);
        }
    }
}
