using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
    using Results;

    [RoutePrefix("api/sb-customer-performance-by-danger/report")]
    public class CustomerPerformanceByDangerController : ApiController
    {
        private readonly IMediator mediator;

        public CustomerPerformanceByDangerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("data")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCustomerPerformanceByDanger(CustomerPerformanceByDangerQueryHttpParameter parameter)
        {
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        [Route("excel")]
        [HttpPost]
        public async Task<IHttpActionResult> LicenseeExcel(CustomerPerformanceByDangerQueryExcelHttpParameter httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter);
            return new EpplusExcelResult(excelPackage);
        }
    }
}