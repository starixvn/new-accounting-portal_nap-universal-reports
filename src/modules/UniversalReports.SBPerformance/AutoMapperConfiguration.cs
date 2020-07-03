using AutoMapper;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.SBPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSBPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<HttpParameter, Criteria>();
        }
    }
}