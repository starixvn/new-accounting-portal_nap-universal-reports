using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunSummaryProfile : Profile
    {
        public PlayForFunSummaryProfile()
        {
            CreateMap<HttpParameterJson, SummaryCriteria>(MemberList.Source);
            CreateMap<SummaryEntity<SummaryModel>, SummaryEntity<SummaryExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, SummaryCriteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, PlayForFun.Detail.Model.DetailCriteria>(MemberList.Source);
        }
    }
}