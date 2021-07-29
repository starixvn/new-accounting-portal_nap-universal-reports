using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.MarginBySite
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceMarginBySiteController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceMarginBySiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("margin-by-site")]
        public async Task<IHttpActionResult> Site(MarginBySiteHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}