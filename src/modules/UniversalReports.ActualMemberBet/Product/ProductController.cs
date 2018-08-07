using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace UniversalReports.ActualMemberBet.Product
{
    [RoutePrefix("api/actual-member-bet/product")]
    public class ProductController : ApiController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
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
