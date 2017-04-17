using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using HttpParameterProduct = UniversalReports.PlayForFun.Filter.Product.HttpParameterJson;

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
        public async Task<IHttpActionResult> Product(HttpParameterProduct parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }
    }
}
