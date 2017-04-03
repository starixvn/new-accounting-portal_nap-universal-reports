using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SportTypeModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<SportTypeModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SportTypeModel, SportTypeExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}