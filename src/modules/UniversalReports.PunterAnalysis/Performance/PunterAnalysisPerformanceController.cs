using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using UniversalReports.PunterAnalysis.Performance.Sportsbook;
using UniversalReports.PunterAnalysis.Performance.Summary;

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

        [Route("summary")]
        public async Task<IHttpActionResult> Summary(SummaryHttpParameterJson parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("sportsbook")]
        public async Task<IHttpActionResult> Sportsbook(SportsbookHttpParameterJson parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}