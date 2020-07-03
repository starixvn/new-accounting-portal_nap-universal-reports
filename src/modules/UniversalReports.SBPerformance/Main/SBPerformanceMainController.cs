using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.Main
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceMainController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceMainController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Main(HttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}