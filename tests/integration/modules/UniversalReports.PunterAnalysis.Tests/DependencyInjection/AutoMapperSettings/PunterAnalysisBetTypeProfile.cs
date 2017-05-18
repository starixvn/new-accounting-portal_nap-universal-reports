using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisBetTypeProfile : Profile
    {
        public PunterAnalysisBetTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<SummaryEntity<BetTypeModel>, SummaryEntity<BetTypeExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<BetTypeModel, BetTypeExcelModel>(MemberList.Source)
                .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Turnover == 0 ? "N/A" : (object)src.Margin))
                .ForMember(dest => dest.LiveMargin, opt => opt.MapFrom(src => src.LiveTurnover == 0 ? "N/A" : (object)src.Margin))
                .ForMember(dest => dest.NonLiveMargin, opt => opt.MapFrom(src => src.NonLiveTurnover == 0 ? "N/A" : (object)src.Margin));
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}
