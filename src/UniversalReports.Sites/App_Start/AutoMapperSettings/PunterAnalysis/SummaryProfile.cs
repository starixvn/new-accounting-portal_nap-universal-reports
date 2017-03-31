using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.Summary.Model;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public class SummaryProfile : Profile
    {
        public SummaryProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}