using AutoMapper;
using UniversalReports.SBPerformance.League;
using UniversalReports.SBPerformance.Main;
using UniversalReports.SBPerformance.Site;
using UniversalReports.SBPerformance.Sport;

namespace UniversalReports.SBPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSBPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<HttpParameter, Criteria>();
            cfg.CreateMap<SiteHttpParameter, SiteCriteria>();
            cfg.CreateMap<LeagueHttpParameter, LeagueCriteria>();
            cfg.CreateMap<SportHttpParameter, SportCriteria>();
        }
    }
}