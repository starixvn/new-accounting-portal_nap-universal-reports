using AutoMapper;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunDetailProfile : Profile
    {
        public PlayForFunDetailProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<DetailModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<DetailModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<DetailModel, DetailExcelModel>(MemberList.Source);
        }
    }
}