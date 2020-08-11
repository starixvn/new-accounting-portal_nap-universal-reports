using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SMAWinLoss.VirtualRate
{
    [RoutePrefix("api/sma-win-loss/virtual-rate")]
    public class SMAWinLossVirtualRateController : ApiController
    {
        private readonly IMediator mediator;

        public SMAWinLossVirtualRateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> VirtualRate(VirtualRateHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}