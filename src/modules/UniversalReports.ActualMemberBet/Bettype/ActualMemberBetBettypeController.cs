using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Epplus;

namespace UniversalReports.ActualMemberBet.Bettype
{
    [RoutePrefix("api/actual-member-bet/bettype")]
    public class ActualMemberBetBettypeController : ApiController
    {
        private readonly IMediator mediator;

        public ActualMemberBetBettypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Index(HttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(HttpParameterExcel httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter).ConfigureAwait(false);
            return new EpplusExcelResult(excelPackage);
        }
    }
}
