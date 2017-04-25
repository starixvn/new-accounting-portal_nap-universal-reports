using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.PunterAnalysis.Performance.Summary;

namespace UniversalReports.PunterAnalysis.Performance
{
    [RoutePrefix("api/punter-analysis/performance")]
    public class PunterAnalysisPerformanceController : ApiController
    {
        private readonly IMediator mediator;

        public PunterAnalysisPerformanceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("summary")]
        public async Task<IHttpActionResult> Summary(SummaryHttpParameterJson parameter)
        {
            CorrectDateTimeParameter(parameter);
            var viewModel = await mediator.Send(parameter);
            return Json(viewModel);
        }

        private void CorrectDateTimeParameter(HttpParameterJson parameter)
        {
            parameter.FromDate = new DateTime(parameter.FromDate.Year, parameter.FromDate.Month, 1);
            parameter.ToDate = new DateTime(parameter.ToDate.Year, parameter.ToDate.Month, 1);
        }
    }
}
