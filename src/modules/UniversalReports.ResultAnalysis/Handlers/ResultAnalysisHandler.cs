using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalReports.ResultAnalysis.Criteria;
using UniversalReports.ResultAnalysis.Models;
using UniversalReports.ResultAnalysis.Requests;
using UniversalReports.ResultAnalysis.Services;

namespace UniversalReports.ResultAnalysis.Handlers
{
	public class ResultAnalysisHandler: IRequestHandler<LeagueRequest, IEnumerable<LeagueModel>>
	{
		private readonly ResultAnalysisService service;

		public ResultAnalysisHandler(ResultAnalysisService service)
		{
			this.service = service;
		}

		public async Task<IEnumerable<LeagueModel>> Handle(LeagueRequest request, CancellationToken cancellationToken)
		{
			var criteria = Mapper.Map<LeagueCriteria>(request);
			return await service.GetLeagues(criteria);
		}
	}
}
