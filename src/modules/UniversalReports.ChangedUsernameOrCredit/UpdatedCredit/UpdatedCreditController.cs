using MediatR;
using Olympus.WebApi.Results;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit
{
    [RoutePrefix("api/updated-credit")]
    public class UpdatedCreditController : ApiController
    {
        private readonly IMediator mediator;

        public UpdatedCreditController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("query")]
        public async Task<IHttpActionResult> Query(Message message)
        {
            var viewModel = await mediator.Send(message).ConfigureAwait(false);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(ExcelMessage message)
        {
            var excelPackage = await mediator.Send(message).ConfigureAwait(false);
            return new ExcelResult(excelPackage);
        }
    }
}
