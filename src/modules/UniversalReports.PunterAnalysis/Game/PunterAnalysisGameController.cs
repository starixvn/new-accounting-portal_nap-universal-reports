using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Epplus;
using UniversalReports.PunterAnalysis.Game.Model;

namespace UniversalReports.PunterAnalysis.Game
{
    [RoutePrefix("api/punter-analysis/game")]
    public class PunterAnalysisGameController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisGameController(IMediator mediator)
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