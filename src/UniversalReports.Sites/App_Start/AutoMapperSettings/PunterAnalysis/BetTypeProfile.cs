using AutoMapper;
using UniversalReports.PunterAnalysis.BetType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.MediatorInjector.PunterAnalysis
{
    public class BetTypeProfile : Profile
    {
        public BetTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<BetTypeModel>, ViewModelJson>(MemberList.Source);
            CreateMap<ModelBase<BetTypeModel>, ExcelViewModel>();
        }
    }
}
