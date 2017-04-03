using AutoMapper;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public class BetTypeProfile : Profile
    {
        public BetTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<BetTypeModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<BetTypeModel>, ExcelViewModel>();
            CreateMap<ReportModelBase<BetTypeModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<BetTypeModel, BetTypeExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, ExcelSetting>(MemberList.Source);
        }
    }
}