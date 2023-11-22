using System.Threading.Tasks;
using System.Web.Http;
using MediatR;

namespace UniversalReports.UpdatedUsernameCredit.UpdatedUsername
{
    using Results;

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
            var viewModel = await mediator.Send(message);
            return Json(viewModel);
        }

        [Route("excel")]
        public async Task<IHttpActionResult> Excel(ExcelMessage message)
        {
            var excelPackage = await mediator.Send(message);
            return new EpplusExcelResult(excelPackage);
        }
    }
}