using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PunterAnalysisSummaryProfile : Profile
    {
        public PunterAnalysisSummaryProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source)
                 .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Turnover == 0 ? "N/A" : (object)src.Margin));
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}