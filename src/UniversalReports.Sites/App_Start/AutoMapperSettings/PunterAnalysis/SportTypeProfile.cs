using AutoMapper;
using UniversalReports.PunterAnalysis.Core;
using UniversalReports.PunterAnalysis.SportType.Model;

namespace UniversalReports.Sites.MediatorInjector.PunterAnalysis
{
    public class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>(MemberList.Source);
            CreateMap<ReportModelBase<SportTypeModel>, ViewModelJson>(MemberList.Source);
        }
    }
}
