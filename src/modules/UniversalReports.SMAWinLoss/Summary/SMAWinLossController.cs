using MediatR;
using Olympus.WebApi.Epplus;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SMAWinLoss.Summary
{
    [RoutePrefix("api/sma-win-loss/summary")]
    public class SMAWinLossController : ApiController
    {
        private readonly IMediator mediator;

        public SMAWinLossController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Summary(WinLossHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(WinLossHttpParameterExcel httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter);
            return new EpplusExcelResult(excelPackage);
        }
    }
}