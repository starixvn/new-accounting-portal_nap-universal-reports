using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.AbnormalBet.HttpParameter;

namespace UniversalReports.AbnormalBet.Report
{
    using Results;

    [RoutePrefix("api/ab-normal-bet/report")]
    public class AbnormalBetReportController : ApiController
    {
        private readonly IMediator mediator;

        public AbnormalBetReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("member")]
        public async Task<IHttpActionResult> Member(MemberHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }

        [Route("licensee")]
        public async Task<IHttpActionResult> Licensee(LicenseeHttpParameter httpParameters)
        {
            var viewModel = await mediator.Send(httpParameters);
            return Json(viewModel);
        }

        [Route("licensee-excel")]
        public async Task<IHttpActionResult> LicenseeExcel(LicenseeHttpParameterExcel httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter);
            return new EpplusExcelResult(excelPackage);
        }

        [Route("member-excel")]
        public async Task<IHttpActionResult> MemberExcel(MemberHttpParameterExcel httpParameter)
        {
            var excelPackage = await mediator.Send(httpParameter);
            return new EpplusExcelResult(excelPackage);
        }
    }
}
