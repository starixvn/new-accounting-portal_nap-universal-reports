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
	public class ResultAnalysisHandler: IRequestHandler<LeagueRequest, IEnumerable<LeagueModel>>,
		IRequestHandler<ResultAnalysisRequest, ResultAnalysisModel>,
        IRequestHandler<ResultAnalysisOfQuarterRequest, ResultAnalysisOfQuarterModel>
    {
		private readonly ResultAnalysisService service;

		public ResultAnalysisHandler(ResultAnalysisService service)
		{
			this.service = service;
		}

		public Task<IEnumerable<LeagueModel>> Handle(LeagueRequest request, CancellationToken cancellationToken)
		{
			var criteria = Mapper.Map<LeagueCriteria>(request);
			return service.GetLeagues(criteria);
		}

		public Task<ResultAnalysisModel> Handle(ResultAnalysisRequest request, CancellationToken cancellationToken)
		{
			var criteria = Mapper.Map<ResultAnalysisCriteria>(request);
			return service.GetResultAnalysis(criteria);
		}

        public Task<ResultAnalysisOfQuarterModel> Handle(ResultAnalysisOfQuarterRequest request, CancellationToken cancellationToken)
        {
            var criteria = Mapper.Map<ResultAnalysisCriteria>(request);
            return service.GetResultAnalysisOfQuarter(criteria);
        }
    }
}
