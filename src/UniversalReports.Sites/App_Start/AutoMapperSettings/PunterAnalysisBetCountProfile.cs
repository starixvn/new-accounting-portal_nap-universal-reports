using AutoMapper;
using Linq.DynamicSum;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.AutoMapperSettings
{
    public class PunterAnalysisBetCountProfile : Profile
    {
        public PunterAnalysisBetCountProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<SummaryEntity<BetCountModel>, SummaryEntity<BetCountExcelModel>>(MemberList.Source);
            CreateMap<HttpParameterExcel, Criteria>(MemberList.Source);
            CreateMap<BetCountModel, BetCountExcelModel>(MemberList.Source);
            CreateMap<HttpParameterExcel, ExcelSettingParams>(MemberList.Source);
        }
    }
}