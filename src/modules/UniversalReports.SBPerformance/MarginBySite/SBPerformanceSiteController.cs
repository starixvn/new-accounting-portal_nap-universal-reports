using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.MarginBySite
{
    [RoutePrefix("api/sb-performance/main/site")]
    public class SBPerformanceSiteController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceSiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Site(SiteHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}