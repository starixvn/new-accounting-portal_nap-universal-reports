using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PlayForFun.Detail.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunDetailProfile : Profile
    {
        public PlayForFunDetailProfile()
        {
            CreateMap<HttpParameterJson, DetailCriteria>(MemberList.Source);
            CreateMap<SummaryEntity<DetailModel>, SummaryEntity<DetailExcelModel>>(MemberList.Source);
            CreateMap<DetailModel, DetailExcelModel>(MemberList.Source);
        }
    }
}