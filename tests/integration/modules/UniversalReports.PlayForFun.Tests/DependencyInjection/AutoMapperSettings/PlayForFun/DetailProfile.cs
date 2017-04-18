using AutoMapper;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings.PlayForFun
{
    public class DetailProfile : Profile
    {
        public DetailProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<DetailModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<DetailModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<DetailModel, DetailExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}