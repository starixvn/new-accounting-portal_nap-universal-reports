using MediatR;
using Olympus.WebApi.Results;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.UpdatedUsernameAndCredit.UpdatedUsername
{
    [RoutePrefix("api/updated-username")]
    public class UpdatedUsernameController : ApiController
    {
        private readonly IMediator mediator;

        public UpdatedUsernameController(IMediator mediator)
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
