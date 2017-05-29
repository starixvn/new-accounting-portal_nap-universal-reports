using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.BetType
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, SummaryEntity<BetTypeModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<BetTypeModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, BetTypeModel>(message).ConfigureAwait(false);
        }
    }
}
