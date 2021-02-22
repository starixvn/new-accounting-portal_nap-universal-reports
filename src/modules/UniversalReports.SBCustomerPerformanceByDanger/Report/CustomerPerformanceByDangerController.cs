using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.SBCustomerPerformanceByDanger.Report
{
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
    }
}