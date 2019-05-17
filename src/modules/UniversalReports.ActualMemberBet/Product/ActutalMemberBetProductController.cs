using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Olympus.WebApi.Epplus;

namespace UniversalReports.ActualMemberBet.Product
{
    [RoutePrefix("api/actual-member-bet/product")]
    public class ActutalMemberBetProductController : ApiController
    {
        private readonly IMediator mediator;

        public ActutalMemberBetProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("")]
        public async Task<IHttpActionResult> Index(HttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(HttpParameterExcel httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter);
            return new EpplusExcelResult(excelPackage);
        }
    }
}
