using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Epplus;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Summary
{
    [RoutePrefix("api/play-for-fun/summary")]
    public class PlayForFunSummaryController : ApiController
    {
        private readonly IMediator mediator;

        public PlayForFunSummaryController(IMediator mediator)
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
            return new EpplusExcelResult(excelPackage, "pl@y4o3un");
        }
    }
}