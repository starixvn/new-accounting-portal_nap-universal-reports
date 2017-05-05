using AutoMapper;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public class PlayForFunSummaryProfile : Profile
    {
        public PlayForFunSummaryProfile()
        {
            CreateMap<HttpParameterJson, SummaryCriteria>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ReportModelBase<SummaryExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, SummaryCriteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, PlayForFun.Detail.Model.DetailCriteria>(MemberList.Source);
        }
    }
}