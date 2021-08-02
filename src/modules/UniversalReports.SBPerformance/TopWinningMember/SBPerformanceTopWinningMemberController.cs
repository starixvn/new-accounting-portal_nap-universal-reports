using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBPerformance.TopWinningMember
{
    [RoutePrefix("api/sb-performance/main")]
    public class SBPerformanceTopWinningMemberController : ApiController
    {
        private readonly IMediator mediator;

        public SBPerformanceTopWinningMemberController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("top-winning-member")]
        public async Task<IHttpActionResult> Member(TopWinningMemberHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }
    }
}