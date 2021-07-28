using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.Sport
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceSportController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceSportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("sport")]
        public async Task<IHttpActionResult> Sport(SportHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}