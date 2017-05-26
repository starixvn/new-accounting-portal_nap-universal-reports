using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, SummaryEntity<SportTypeModel>>
    {
        public Handler(IMapper mapper, PunterAnalysisService punterAnalysisService) : base(mapper, punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SportTypeModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SportTypeModel>(message).ConfigureAwait(false);
        }
    }
}
