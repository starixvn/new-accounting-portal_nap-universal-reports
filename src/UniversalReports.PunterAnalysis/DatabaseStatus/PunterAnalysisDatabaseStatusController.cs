using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.DatabaseStatus.Model;

namespace UniversalReports.PunterAnalysis.DatabaseStatus
{
    [RoutePrefix("api/punter-analysis/database-status")]
    public class PunterAnalysisDatabaseStatusController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisDatabaseStatusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Index(HttpParameterJson parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }
    }
}
