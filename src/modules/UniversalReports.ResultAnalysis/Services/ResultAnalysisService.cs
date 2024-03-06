using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.ResultAnalysis.Criteria;
using UniversalReports.ResultAnalysis.Models;

namespace UniversalReports.ResultAnalysis.Services
{
	public interface ResultAnalysisService
	{
		Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria);

		Task<ResultAnalysisModel> GetResultAnalysis(ResultAnalysisCriteria criteria);
	}

	public class ResultAnalysisServiceImp : ResultAnalysisService
	{
		private readonly IDynamicRepository repository;

		public ResultAnalysisServiceImp(IDynamicRepository repository)
		{
			this.repository = repository;
		}
		public async Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria)
		{
			return await repository.FetchAsync<LeagueModel>(criteria);
		}

		public async Task<ResultAnalysisModel> GetResultAnalysis(ResultAnalysisCriteria criteria)
		{
			var items = (await repository.FetchAsync<DetailedResultAnalysisModel>(criteria)).ToList();
			var result = new ResultAnalysisModel
			{
				Items = items,
				Summary = GetSummaryModel(items)
			};
			return await Task.FromResult(result);
		}

		private static ResultAnalysisSummaryModel GetSummaryModel(List<DetailedResultAnalysisModel> data)
		{
			var total = data.Count;
			var result = new ResultAnalysisSummaryModel
			{
				TotalLeague = total,
				TotalMatch = total,
				FavHdpResult = data.Count(item => item.ResultHDP == "Fav"),
				UnderdogHdpResult = data.Count(item => item.ResultHDP == "Underdog"),
				DrawHdpResult = data.Count(item => item.ResultHDP == "Draw"),
				OverOuResult = data.Count(item => item.ResultOU == "Over"),
				UnderOuResult = data.Count(item => item.ResultOU == "Under"),
				DrawOuResult = data.Count(item => item.ResultOU == "Draw"),
				Fav1x2Result = data.Count(item => item.Result1x2 == "Fav"),
				Underdog1x2Result = data.Count(item => item.Result1x2 == "Underdog"),
				Draw1x2Result = data.Count(item => item.Result1x2 == "Draw"),
				TgResult01 = data.Count(item => item.ResultTG == 1 || item.ResultTG == 0),
				TgResult23 = data.Count(item => item.ResultTG == 2 || item.ResultTG == 3),
				TgResult46 = data.Count(item => item.ResultTG >= 4 && item.ResultTG <= 6),
				TgResult7 = data.Count(item => item.ResultTG >= 7),
			};
			return result;
		}
	}
}
