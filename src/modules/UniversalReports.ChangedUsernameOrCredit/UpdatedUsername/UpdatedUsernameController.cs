using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UniversalReports.UpdatedUsernameAndGivenCredit.UpdatedUsername
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
    }
}
