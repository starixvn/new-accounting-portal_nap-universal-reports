using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.Site
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceSiteController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceSiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("site")]
        public async Task<IHttpActionResult> Site(SiteHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}