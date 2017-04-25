using AutoMapper;
using UniversalReports.PunterAnalysis.Performance.Summary;
using UniversalReports.PunterAnalysis.Performance.Summary.Criteria;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PunterAnalysisPerformanceProfile : Profile
    {
        public PunterAnalysisPerformanceProfile()
        {
            CreateMap<SummaryHttpParameterJson, MonthCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, ProductTurnoverCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, SportCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, BetTypeCriteria>(MemberList.Source);
            CreateMap<SummaryHttpParameterJson, EventCriteria>(MemberList.Source);
        }
    }
}
