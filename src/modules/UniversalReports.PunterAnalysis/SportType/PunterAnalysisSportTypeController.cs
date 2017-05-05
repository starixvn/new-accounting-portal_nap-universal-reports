using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.WebAPI.Results;

namespace UniversalReports.PunterAnalysis.SportType
{
    [RoutePrefix("api/punter-analysis/sport-type")]
    public class PunterAnalysisSportTypeController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisSportTypeController(IMediator mediator)
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
