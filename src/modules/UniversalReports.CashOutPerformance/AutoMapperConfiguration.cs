using AutoMapper;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
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
            cfg.CreateMap<TicketRequest<TicketModel>, TicketCriteria>();
            cfg.CreateMap<TicketRequest<SportLevelModel>, SportLevelCriteria>();
            cfg.CreateMap<TicketRequest<EventStatusLevelModel>, EventStatusLevelCriteria>();
            cfg.CreateMap<TicketRequest<BetTypeLevelModel>, BetTypeLevelCriteria>();
            cfg.CreateMap<TicketRequest<MatchDetailLevelModel>, MatchDetailLevelCriteria>();
            cfg.CreateMap<TicketExcelRequest, TicketCriteria>();
            cfg.CreateMap<TicketViewModel<TicketModel>, TicketViewExcelModel>();
            cfg.CreateMap<LeagueGroupRequest, LeagueGroupCriteria>();
        }
    }
}