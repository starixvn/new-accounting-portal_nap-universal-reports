using AutoMapper;
using UniversalReports.ResultAnalysis.Criteria;
using UniversalReports.ResultAnalysis.Requests;

namespace UniversalReports.ResultAnalysis
{
	public static class AutoMapperConfiguration
	{
		public static void InitializeResultAnalysis(this IProfileExpression cfg)
		{
			cfg.CreateMap<LeagueRequest, LeagueCriteria>();
		}
	}
}