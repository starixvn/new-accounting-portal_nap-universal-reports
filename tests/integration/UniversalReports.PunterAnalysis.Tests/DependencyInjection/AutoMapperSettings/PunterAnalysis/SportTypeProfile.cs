using AutoMapper;
using UniversalReports.PunterAnalysis.SportType.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
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
