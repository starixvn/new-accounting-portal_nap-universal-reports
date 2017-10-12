using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Results;
using UniversalReports.PunterAnalysis.BetType.Model;

namespace UniversalReports.PunterAnalysis.BetType
{
    [RoutePrefix("api/punter-analysis/bet-type")]
    public class PunterAnalysisBetTypeController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisBetTypeController(IMediator mediator)
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