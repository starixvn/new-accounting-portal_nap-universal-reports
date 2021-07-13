using MediatR;
using Olympus.WebApi.Epplus;
using System.Threading.Tasks;
using System.Web.Http;
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

        [Route("tickets")]
        [HttpPost]
        public async Task<IHttpActionResult> Tickets(TicketRequest request)
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