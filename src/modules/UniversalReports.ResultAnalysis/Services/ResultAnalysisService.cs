using Fanex.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.ResultAnalysis.Criteria;
using UniversalReports.ResultAnalysis.Models;

namespace UniversalReports.ResultAnalysis.Services
{
	public interface ResultAnalysisService
	{
		Task<IEnumerable<LeagueModel>> GetLeagues(LeagueCriteria criteria);
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
	}
}
