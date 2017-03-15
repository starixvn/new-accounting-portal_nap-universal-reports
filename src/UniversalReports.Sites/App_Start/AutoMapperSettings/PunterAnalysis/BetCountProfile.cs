using AutoMapper;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public class BetCountProfile : Profile
    {
        public BetCountProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<BetCountModel>, ViewModelJson>(MemberList.Source);
        }
    }
}