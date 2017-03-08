using AutoMapper;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.MediatorInjector.PunterAnalysis
{
    public class SportTypeProfile : Profile
    {
        public SportTypeProfile()
        {
            CreateMap<HttpParameterJson, Criteria>();
            CreateMap<ModelBase<SportTypeModel>, ViewModelJson>();
        }
    }
}
