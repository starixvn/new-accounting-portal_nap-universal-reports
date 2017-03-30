using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    [RoutePrefix("api/punter-analysis/bet-type")]
    public class PunterAnalysisAssociatedAccountController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisAssociatedAccountController(IMediator mediator)
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
