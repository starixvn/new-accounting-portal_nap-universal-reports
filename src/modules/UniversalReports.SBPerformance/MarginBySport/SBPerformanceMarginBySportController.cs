using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.MarginBySport
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceMarginBySportController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceMarginBySportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("margin-by-sport")]
        public async Task<IHttpActionResult> Site(MarginBySportHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}