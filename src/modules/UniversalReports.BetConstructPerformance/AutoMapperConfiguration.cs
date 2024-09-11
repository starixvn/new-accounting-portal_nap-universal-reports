using AutoMapper;
using UniversalReports.BetConstructPerformance.Criteria;
using UniversalReports.BetConstructPerformance.Models;
using UniversalReports.BetConstructPerformance.Requests;

namespace UniversalReports.BetConstructPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeBetConstructPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<SportRequest, SportCriteria>();
            cfg.CreateMap<SportModel, SportDetailExcelModel>();
            cfg.CreateMap<SportModel, SportExcelModel>();
            cfg.CreateMap<SportExcelRequest, SportCriteria>();
        }
    }
}
