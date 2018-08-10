using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using HttpParameterAvailableDatabase = UniversalReports.PunterAnalysis.Filter.AvailableDatabase.HttpParameterJson;
using HttpParameterAvailableDataRange = UniversalReports.PunterAnalysis.Filter.AvailableDateRange.HttpParameterJson;
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
            return await Handle(parameter).ConfigureAwait(false);
        }

        [Route("available-date-range")]
        public async Task<IHttpActionResult> AvailableDateRange(HttpParameterAvailableDataRange parameter)
        {
            return await Handle(parameter).ConfigureAwait(false);
        }

        [Route("product-sport-bet-type")]
        public async Task<IHttpActionResult> ProductSportBetType(HttpParameterProductSportBetType parameter)
        {
            return await Handle(parameter).ConfigureAwait(false);
        }

        [Route("username-suggestion")]
        public async Task<IHttpActionResult> UsernameSuggestion(HttpParameterUsernameSuggestion parameter)
        {
            return await Handle(parameter).ConfigureAwait(false);
        }

        [Route("sportsbook-sport-bet-type")]
        public async Task<IHttpActionResult> SportsbookSportBetType(HttpParameterSportsbookSportBetType parameter)
        {
            return await Handle(parameter).ConfigureAwait(false);
        }

        [Route("sport-type-league")]
        public async Task<IHttpActionResult> SportTypeLeague(HttpParameterSportTypeLeague parameter)
        {
            return await Handle(parameter).ConfigureAwait(false);
        }

        private async Task<IHttpActionResult> Handle<TResponse>(IRequest<TResponse> parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }
    }
}