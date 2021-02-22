using AutoMapper;
using UniversalReports.SBCustomerPerformanceByDanger.Filter;
using UniversalReports.SBCustomerPerformanceByDanger.Report;

namespace UniversalReports.SBCustomerPerformanceByDanger
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSBCustomerPerformanceByDanger(this IProfileExpression cfg)
        {
            cfg.CreateMap<SportQueryHttpParameter, SportQueryCriteria>();
            cfg.CreateMap<LeagueGroupQueryHttpParameter, LeagueGroupQueryCriteria>();
            cfg.CreateMap<LeagueQueryHttpParameter, LeagueQueryCriteria>();
            cfg.CreateMap<DivisionQueryHttpParameter, DivisionQueryCriteria>();
            cfg.CreateMap<CustomerPerformanceByDangerQueryHttpParameter, CustomerPerformanceByDangerQueryCriteria>();
        }
    }
}