using AutoMapper;
using UniversalReports.SBPerformance.Main;
using UniversalReports.SBPerformance.MarginBySite;
using UniversalReports.SBPerformance.MarginBySport;

namespace UniversalReports.SBPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSBPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<HttpParameter, Criteria>();
            cfg.CreateMap<MarginBySiteHttpParameter, MarginBySiteCriteria>();
            cfg.CreateMap<MarginBySportHttpParameter, MarginBySportCriteria>();
        }
    }
}