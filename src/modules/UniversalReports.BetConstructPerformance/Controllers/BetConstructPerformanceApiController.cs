using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.BetConstructPerformance.Requests;
using UniversalReports.Results;

namespace UniversalReports.BetConstructPerformance.Controllers
{
    [RoutePrefix("api/bet-construct")]
    public class BetConstructPerformanceApiController : ApiController
    {
        private readonly IMediator mediator;

        public BetConstructPerformanceApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("sports")]
        public async Task<IHttpActionResult> Sports(SportRequest request)
        {
            var viewModel = await mediator.Send(request);
            return Json(viewModel);
        }

        [Route("excel-sports")]
        [HttpPost]
        public async Task<IHttpActionResult> Excel(SportExcelRequest request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }
    }
}
