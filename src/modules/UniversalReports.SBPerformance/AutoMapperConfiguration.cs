using AutoMapper;
using UniversalReports.SBPerformance.Main;
using UniversalReports.SBPerformance.Site;

namespace UniversalReports.SBPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSBPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<HttpParameter, Criteria>();
            cfg.CreateMap<SiteHttpParameter, SiteCriteria>();
        }
    }
}