using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PlayForFun.Filter.Product;

namespace UniversalReports.PlayForFun.Filter
{
    [RoutePrefix("api/play-for-fun/filter")]
    public class PlayForFunFilterController : ApiController
    {
        private readonly IMediator mediator;

        public PlayForFunFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("product")]
        public async Task<IHttpActionResult> Product()
        {
            var viewModel = await mediator.Send(new HttpParameterJson()).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}
