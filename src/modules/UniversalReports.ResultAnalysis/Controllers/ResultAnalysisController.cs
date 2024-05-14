using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.ResultAnalysis.Requests;
using UniversalReports.Results;

namespace UniversalReports.ResultAnalysis.Controllers
{
	[RoutePrefix("api/result-analysis")]
	public class ResultAnalysisController: ApiController
	{
		private readonly IMediator mediator;

		public ResultAnalysisController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[Route("leagues")]
		public async Task<IHttpActionResult> Leagues(LeagueRequest request)
		{
			var viewModel = await mediator.Send(request);
			return Json(viewModel);
		}

		[Route("result-analysis")]
		public async Task<IHttpActionResult> ResultAnalysis(ResultAnalysisRequest request)
		{
			var viewModel = await mediator.Send(request);
			return Json(viewModel);
		}

		[Route("export-excel")]
		[HttpPost]
		public async Task<IHttpActionResult> Excel(ResultAnalysisExcelRequest request)
		{
			var excelPackage = await mediator.Send(request);
			return new EpplusExcelResult(excelPackage);
		}
	}
}
