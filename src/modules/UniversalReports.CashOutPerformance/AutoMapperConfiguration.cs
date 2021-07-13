using AutoMapper;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Requests;
using UniversalReports.CashOutPerformance.ViewModels;

namespace UniversalReports.CashOutPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeCashOutPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<SportRequest, SportCriteria>();
            cfg.CreateMap<LicenseeRequest, LicenseeCriteria>();
            cfg.CreateMap<LeagueRequest, LeagueCriteria>();
            cfg.CreateMap<TicketRequest, TicketCriteria>();
            cfg.CreateMap<TicketExcelRequest, TicketCriteria>();
            cfg.CreateMap<TicketViewModel, TicketViewExcelModel>();
        }
    }
}