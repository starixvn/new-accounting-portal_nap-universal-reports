using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using UniversalReports.ResultAnalysis.Requests;

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
	}
}
