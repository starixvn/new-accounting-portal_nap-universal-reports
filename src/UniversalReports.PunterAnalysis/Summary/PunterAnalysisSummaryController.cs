using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.PunterAnalysis.Summary
{
    [RoutePrefix("api/punter-analysis/summary")]
    public class PunterAnalysisSummaryController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisSummaryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> Index(HttpParameterJson parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }
    }
}
