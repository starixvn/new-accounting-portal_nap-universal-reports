using System.Linq;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;

namespace UniversalReports.CashOutPerformance.Controllers
{
    using Results;
    using UniversalReports.CashOutPerformance.Criteria;
    using UniversalReports.CashOutPerformance.Utility;

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

        [Route("sport-level")]
        [HttpPost]
        public async Task<IHttpActionResult> SportLevel(SportLevelRequest request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("event-status-level")]
        [HttpPost]
        public async Task<IHttpActionResult> EventStatusLevel(TicketRequest<EventStatusLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("bettype-level")]
        [HttpPost]
        public async Task<IHttpActionResult> BetTypeLevel(TicketRequest<BetTypeLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("game-time-level")]
        [HttpPost]
        public async Task<IHttpActionResult> GameTimeLevel(GameTimeCriteria criteria)
        {
            var request = new BetTypeDrillDownRequest();
            var data = await mediator.Send(request);
            var viewModel = ModelsHelper.UpdateGameTimeLevelModel(data.TicketList.ToList(), criteria);
            return Json(viewModel);
        }

        [Route("winning-probability-level")]
        [HttpPost]
        public async Task<IHttpActionResult> WinningProbabilityLevel(GameTimeCriteria criteria)
        {
            var request = new BetTypeDrillDownRequest();
            var data = await mediator.Send(request);
            var viewModel = ModelsHelper.UpdateWinningProbabilityLevelModel(data.TicketList.ToList(), criteria);
            return Json(viewModel);
        }

        [Route("detail-game-time-level")]
        [HttpPost]
        public async Task<IHttpActionResult> DetailGameTimeLevel(GameTimeCriteria criteria)
        {
            var request = new BetTypeDrillDownRequest();
            var data = await mediator.Send(request);
            var viewModel = ModelsHelper.UpdateDetailGameTimeLevelModel(data.TicketList.ToList(), criteria);
            return Json(viewModel);
        }

        [Route("match-detail-level")]
        [HttpPost]
        public async Task<IHttpActionResult> MatchDetailLevel(TicketRequest<MatchDetailLevelModel> request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("excel-sport")]
        [HttpPost]
        public async Task<IHttpActionResult> TicketsExcel(SportLevelExcelRequest request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }

        [Route("excel-event-status")]
        [HttpPost]
        public async Task<IHttpActionResult> TicketsExcel(TicketExcelRequest<EventStatusLevelModel> request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }

        [Route("excel-bettype")]
        [HttpPost]
        public async Task<IHttpActionResult> TicketsExcel(TicketExcelRequest<BetTypeLevelModel> request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }

        [Route("excel-match-detail")]
        [HttpPost]
        public async Task<IHttpActionResult> TicketsExcel(TicketExcelRequest<MatchDetailLevelModel> request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }
    }
}