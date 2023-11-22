using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.League
{
    using Results;

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
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(HttpParameterExcel parameter)
        {
            var excelPackage = await mediator.Send(parameter);
            return new EpplusExcelResult(excelPackage);
        }
    }
}