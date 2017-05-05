using AutoMapper;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunDetailProfile : Profile
    {
        public PlayForFunDetailProfile()
        {
            CreateMap<HttpParameterJson, DetailCriteria>(MemberList.Source);
            CreateMap<ReportModelBase<DetailModel>, ReportModelBase<DetailExcelModel>>(MemberList.Source);
            CreateMap<DetailModel, DetailExcelModel>(MemberList.Source);
        }
    }
}