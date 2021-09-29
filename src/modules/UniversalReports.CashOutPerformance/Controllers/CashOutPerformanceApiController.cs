using MediatR;
using Olympus.WebApi.Epplus;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;

namespace UniversalReports.CashOutPerformance.Controllers
{
    [RoutePrefix("api/cash-out-performance")]
    public class CashOutPerformanceApiController : ApiController
    {
        private readonly IMediator mediator;

        public CashOutPerformanceApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("sports")]
        public async Task<IHttpActionResult> Sports()
        {
            var viewModel = await mediator.Send(new SportRequest());
            return Json(viewModel);
        }

        [Route("licensees")]
        public async Task<IHttpActionResult> Licensees()
        {
            var viewModel = await mediator.Send(new LicenseeRequest());
            return Json(viewModel);
        }

        [Route("leagues")]
        public async Task<IHttpActionResult> Leagues(LeagueRequest request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("leagueGroups")]
        public async Task<IHttpActionResult> LeagueGroups()
        {
            var viewModel = await mediator.Send(new LeagueGroupRequest());
            return Json(viewModel);
        }

        [Route("tickets")]
        [HttpPost]
        public async Task<IHttpActionResult> Tickets(TicketRequest<TicketModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("sportLevel")]
        [HttpPost]
        public async Task<IHttpActionResult> SportLevel(TicketRequest<SportLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("eventStatusLevel")]
        [HttpPost]
        public async Task<IHttpActionResult> EventStatusLevel(TicketRequest<EventStatusLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("betTypeLevel")]
        [HttpPost]
        public async Task<IHttpActionResult> BetTypeLevel(TicketRequest<BetTypeLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("matchDetailLevel")]
        [HttpPost]
        public async Task<IHttpActionResult> MatchDetailLevel(TicketRequest<MatchDetailLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("excel")]
        [HttpPost]
        public async Task<IHttpActionResult> TicketsExcel(TicketExcelRequest request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }
    }
}