using AutoMapper;
using UniversalReports.NG2Statistics.BaseServices;
using UniversalReports.NG2Statistics.Bettype;
using UniversalReports.NG2Statistics.Daily;
using UniversalReports.NG2Statistics.GrandTotal;
using UniversalReports.NG2Statistics.UserName;

namespace UniversalReports.NG2Statistics
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeNG2Statistics(this IProfileExpression cfg)
        {
            cfg.CreateMap<QueryModel, BettypeCriteria>();
            cfg.CreateMap<QueryModel, DailyCriteria>();
            cfg.CreateMap<QueryModel, GrandTotalCriteria>();
            cfg.CreateMap<QueryModel, UserNameCriteria>();
        }
    }
}