using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using HttpParameterLicensee = UniversalReports.Exchange.Filter.Licensee.HttpParameterJson;
using HttpParameterSport = UniversalReports.Exchange.Filter.Sport.HttpParameterJson;

namespace UniversalReports.Exchange.Filter
{
    [RoutePrefix("api/exchange/filter")]
    public class ExchangeFilterController : ApiController
    {
        private readonly IMediator mediator;

        public ExchangeFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("licensee")]
        public async Task<IHttpActionResult> Licensee()
        {
            var viewModel = await mediator.Send(new HttpParameterLicensee());
            return Json(viewModel);
        }


        [Route("sport")]
        public async Task<IHttpActionResult> Sport()
        {
            var viewModel = await mediator.Send(new HttpParameterSport());
            return Json(viewModel);
        }
    }
}