using AutoMapper;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PlayForFunSummaryProfile : Profile
    {
        public PlayForFunSummaryProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ReportModelBase<SummaryModel>, ExcelViewModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<SummaryModel, SummaryExcelModel>(MemberList.Source);
        }
    }
}