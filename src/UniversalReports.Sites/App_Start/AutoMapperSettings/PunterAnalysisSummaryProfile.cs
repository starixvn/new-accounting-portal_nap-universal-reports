using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PunterAnalysisSummaryProfile : Profile
    {
        public PunterAnalysisSummaryProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<SummaryEntity<SummaryModel>, SummaryEntity<SummaryExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source)
                 .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Turnover == 0 ? "N/A" : (object)src.Margin));
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}