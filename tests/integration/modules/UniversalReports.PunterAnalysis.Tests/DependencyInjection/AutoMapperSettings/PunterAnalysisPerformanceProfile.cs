using AutoMapper;
using UniversalReports.PunterAnalysis.Performance.Sportsbook;
using UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria;
using UniversalReports.PunterAnalysis.Performance.Summary;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;
using SportsbookSportCriteria = UniversalReports.PunterAnalysis.Performance.Sportsbook.Criteria.SportCriteria;
using SummarySportCriteria = UniversalReports.PunterAnalysis.Performance.Summary.Criteria.SportCriteria;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisPerformanceProfile : Profile
    {
        public PunterAnalysisPerformanceProfile()
        {
            CreateMap<SummaryHttpParameterJson, MonthCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, ProductTurnoverCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, SummarySportCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, BetTypeCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, EventCriteria>(MemberList.Source);

            CreateMap<SportsbookHttpParameterJson, BetCountCriteria>(MemberList.Source);
            CreateMap<SportsbookHttpParameterJson, SportsbookSportCriteria>(MemberList.Source);
        }
    }
}
