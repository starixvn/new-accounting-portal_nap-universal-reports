using MediatR;
using System.Web.Http;

namespace UniversalReports.PunterAnalysis.Performance
{
    [RoutePrefix("api/punter-analysis/performance")]
    public class PunterAnalysisPerformanceController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisPerformanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
