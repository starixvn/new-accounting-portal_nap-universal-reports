using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace UniversalReports.Exchange.Report
{
    [RoutePrefix("api/exchange")]
    public class ExchangeController : ApiController
    {
        private readonly IMediator mediator;

        public ExchangeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("report")]
        public async Task<IHttpActionResult> Exchange(HttpParameterJson httpParameter)
        {
            var viewModel = await mediator.Send(httpParameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}
