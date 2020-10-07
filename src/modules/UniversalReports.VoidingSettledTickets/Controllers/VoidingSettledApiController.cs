using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.VoidingSettledTickets.Requests;

namespace UniversalReports.VoidingSettledTickets.Controllers
{
    public class VoidingSettledApiController : ApiController
    {
        private readonly IMediator mediator;

        public VoidingSettledApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("search")]
        public async Task<IHttpActionResult> SearchProduct(ProductRequest request) => Ok
        (
            await mediator.Send(request).ConfigureAwait(false)
        );

        [Route("ticket-by-product")]
        public async Task<IHttpActionResult> TicketByProduct(TicketRequest request) => Ok
        (
            await mediator.Send(request).ConfigureAwait(false)
        );
    }
}