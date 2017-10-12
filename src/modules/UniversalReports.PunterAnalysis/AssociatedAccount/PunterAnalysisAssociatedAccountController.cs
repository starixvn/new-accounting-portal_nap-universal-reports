using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.AssociatedAccount
{
    [RoutePrefix("api/punter-analysis/associated-account")]
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
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}