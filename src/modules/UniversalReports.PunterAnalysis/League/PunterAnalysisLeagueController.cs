using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.League.Model;
using Olympus.WebApi.Results;

namespace UniversalReports.PunterAnalysis.League
{
    [RoutePrefix("api/punter-analysis/league")]
    public class PunterAnalysisLeagueController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisLeagueController(IMediator mediator)
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
