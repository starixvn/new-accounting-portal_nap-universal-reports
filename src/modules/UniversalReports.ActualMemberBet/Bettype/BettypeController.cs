using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace UniversalReports.ActualMemberBet.Bettype
{
    [RoutePrefix("api/actual-member-bet/bettype")]
    public class BettypeController : ApiController
    {
        private readonly IMediator mediator;

        public BettypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Index(HttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}
