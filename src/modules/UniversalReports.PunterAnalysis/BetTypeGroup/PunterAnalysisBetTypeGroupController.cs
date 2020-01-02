using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Epplus;
using UniversalReports.PunterAnalysis.BetTypeGroup.Model;

namespace UniversalReports.PunterAnalysis.BetTypeGroup
{
    [RoutePrefix("api/punter-analysis/bet-type-group")]
    public class PunterAnalysisBetTypeGroupController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisBetTypeGroupController(IMediator mediator)
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