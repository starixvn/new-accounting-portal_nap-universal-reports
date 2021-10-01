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
            cfg.CreateMap<TicketRequest<SportLevelModel>, SportLevelCriteria>();
            cfg.CreateMap<TicketRequest<EventStatusLevelModel>, EventStatusLevelCriteria>();
            cfg.CreateMap<TicketRequest<BetTypeLevelModel>, BetTypeLevelCriteria>();
            cfg.CreateMap<TicketRequest<MatchDetailLevelModel>, MatchDetailLevelCriteria>();
            cfg.CreateMap<TicketExcelRequest<SportLevelModel>, SportLevelCriteria>();
            cfg.CreateMap<TicketExcelRequest<EventStatusLevelModel>, EventStatusLevelCriteria>();
            cfg.CreateMap<TicketExcelRequest<BetTypeLevelModel>, BetTypeLevelCriteria>();
            cfg.CreateMap<TicketExcelRequest<MatchDetailLevelModel>, MatchDetailLevelCriteria>();
            cfg.CreateMap<TicketViewModel<SportLevelModel>, TicketViewExcelModel<SportLevelExcelModel>>();
            cfg.CreateMap<TicketViewModel<EventStatusLevelModel>, TicketViewExcelModel<EventStatusLevelExcelModel>>();
            cfg.CreateMap<TicketViewModel<BetTypeLevelModel>, TicketViewExcelModel<BetTypeLevelExcelModel>>();
            cfg.CreateMap<TicketViewModel<MatchDetailLevelModel>, TicketViewExcelModel<MatchDetailLevelExcelModel>>();
            cfg.CreateMap<LeagueGroupRequest, LeagueGroupCriteria>();
        }
    }
}