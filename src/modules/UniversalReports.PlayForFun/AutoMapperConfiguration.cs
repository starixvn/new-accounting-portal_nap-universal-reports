using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun
{
    public static class AutoMapperConfiguration
    {
        public static void InitializePlayForFun(this IProfileExpression cfg)
        {
            cfg.CreateMap<Detail.Model.HttpParameterJson, DetailCriteria>();
            cfg.CreateMap<Summary.Model.HttpParameterJson, SummaryCriteria>();
            cfg.CreateMap<HttpParameterExcel, DetailCriteria>();
            cfg.CreateMap<HttpParameterExcel, SummaryCriteria>();
            cfg.CreateMap<SummaryEntity<SummaryModel>, SummaryEntity<SummaryExcelModel>>();
            cfg.CreateMap<SummaryEntity<DetailModel>, SummaryEntity<DetailExcelModel>>();
        }
    }
}
