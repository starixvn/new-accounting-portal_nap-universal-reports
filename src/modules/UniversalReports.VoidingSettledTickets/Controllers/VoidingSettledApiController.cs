using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.VoidingSettledTickets.Requests;

namespace UniversalReports.VoidingSettledTickets.Controllers
{
    using Results;

    [RoutePrefix("api/voiding-settled-tickets")]
    public class VoidingSettledApiController : ApiController
    {
        private readonly IMediator mediator;

        public VoidingSettledApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("move-bet-date")]
        public async Task<IHttpActionResult> MoveBetDate(MoveBetsDateRequest request) => Ok(await mediator.Send(request).ConfigureAwait(false));

        [Route("products")]
        public async Task<IHttpActionResult> SearchProducts(ProductRequest request) => Ok(await mediator.Send(request).ConfigureAwait(false));

        [Route("tickets-by-product")]
        public async Task<IHttpActionResult> TicketsByProduct(TicketRequest request) => Ok(await mediator.Send(request).ConfigureAwait(false));

        [Route("products-excel")]
        public async Task<IHttpActionResult> ProductsExcel(ProductExcelRequest request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }

        [Route("tickets-by-product-excel")]
        public async Task<IHttpActionResult> TicketsByProductExcel(TicketExcelRequest request)
        {
            var excelPackage = await mediator.Send(request);
            return new EpplusExcelResult(excelPackage);
        }
    }
}