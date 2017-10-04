using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using HttpParameterAvailableDatabase = UniversalReports.PunterAnalysis.Filter.AvailableDatabase.HttpParameterJson;
using HttpParameterAvailableDataRange = UniversalReports.PunterAnalysis.Filter.AvailableDateRange.HttpParameterJson;
using HttpParameterLeague = UniversalReports.PunterAnalysis.Filter.League.HttpParameterJson;
using HttpParameterProductSportBetType = UniversalReports.PunterAnalysis.Filter.ProductSportBetType.HttpParameterJson;
using HttpParameterSportsbookSportBetType = UniversalReports.PunterAnalysis.Filter.SportsbookSportBetType.HttpParameterJson;
using HttpParameterSportTypeLeague = UniversalReports.PunterAnalysis.Filter.SportTypeLeague.HttpParameterJson;
using HttpParameterUsernameSuggestion = UniversalReports.PunterAnalysis.Filter.UsernameSuggestion.HttpParameterJson;

namespace UniversalReports.PunterAnalysis.Filter
{
    [RoutePrefix("api/punter-analysis/filter")]
    public class PunterAnalysisFilterController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisFilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("available-database")]
        public async Task<IHttpActionResult> AvailableDatabase(HttpParameterAvailableDatabase parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("available-date-range")]
        public async Task<IHttpActionResult> AvailableDateRange(HttpParameterAvailableDataRange parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("league")]
        public async Task<IHttpActionResult> League(HttpParameterLeague parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("product-sport-bet-type")]
        public async Task<IHttpActionResult> ProductSportBetType(HttpParameterProductSportBetType parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("username-suggestion")]
        public async Task<IHttpActionResult> UsernameSuggestion(HttpParameterUsernameSuggestion parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("sportsbook-sport-bet-type")]
        public async Task<IHttpActionResult> SportsbookSportBetType(HttpParameterSportsbookSportBetType parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("sport-type-league")]
        public async Task<IHttpActionResult> SportTypeLeague(HttpParameterSportTypeLeague parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}