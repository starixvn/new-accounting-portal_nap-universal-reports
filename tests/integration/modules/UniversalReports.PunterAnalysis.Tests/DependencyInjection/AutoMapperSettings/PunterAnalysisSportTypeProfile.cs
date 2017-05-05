using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisSportTypeProfile : Profile
    {
        public PunterAnalysisSportTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SportTypeModel>, ReportModelBase<SportTypeModel>>(MemberList.Source);
            CreateMap<ReportModelBase<SportTypeModel>, ReportModelBase<SportTypeExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SportTypeModel, SportTypeExcelModel>(MemberList.Source)
                .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Turnover == 0 ? "N/A" : (object)src.Margin));
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}
