using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Detail
{
    [RoutePrefix("api/play-for-fun/detail")]
    public class PlayForFunDetailController : ApiController
    {
        private readonly IMediator mediator;

        public PlayForFunDetailController(IMediator mediator)
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
