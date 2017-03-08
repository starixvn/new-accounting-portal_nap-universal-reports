using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.API.Results;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    [RoutePrefix("api/punter-analysis/bet-type")]
    public class PunterAnalysisBetCountController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisBetCountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Index(HttpParameterJson parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(HttpParameterExcel parameter)
        {
            var excelPackage = await mediator.Send(parameter);
            return new ExcelResult(excelPackage);
        }
    }
}
