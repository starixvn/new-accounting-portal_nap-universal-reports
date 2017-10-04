using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Results;
using UniversalReports.PunterAnalysis.BetCount.Model;

namespace UniversalReports.PunterAnalysis.BetCount
{
    [RoutePrefix("api/punter-analysis/bet-count")]
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
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(HttpParameterExcel parameter)
        {
            var excelPackage = await mediator.Send(parameter).ConfigureAwait(false);
            return new ExcelResult(excelPackage);
        }
    }
}