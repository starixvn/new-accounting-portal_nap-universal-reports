using AutoMapper;
using Linq.DynamicSum;
using MediatR;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Shared;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.SportType
{
    public class Handler : HandlerBase, IAsyncRequestHandler<HttpParameterJson, SummaryEntity<SportTypeModel>>
    {
        public Handler(PunterAnalysisService punterAnalysisService) : base(punterAnalysisService)
        {
        }

        public async Task<SummaryEntity<SportTypeModel>> Handle(HttpParameterJson message)
        {
            return await Handle<Criteria, SportTypeModel>(message).ConfigureAwait(false);
        }
    }
}
