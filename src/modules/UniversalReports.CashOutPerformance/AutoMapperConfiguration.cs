using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.CashOutPerformance.Criteria;
using UniversalReports.CashOutPerformance.Models;
using UniversalReports.CashOutPerformance.Requests;

namespace UniversalReports.CashOutPerformance
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeCashOutPerformance(this IProfileExpression cfg)
        {
            cfg.CreateMap<SportRequest, SportCriteria>();
            cfg.CreateMap<LicenseeRequest, LicenseeCriteria>();
            cfg.CreateMap<TicketRequest, TicketCriteria>();
            cfg.CreateMap<TicketExcelRequest, TicketCriteria>();
            cfg.CreateMap<SummaryEntity<TicketModel>, SummaryEntity<TicketExcelModel>>();
        }
    }
}
