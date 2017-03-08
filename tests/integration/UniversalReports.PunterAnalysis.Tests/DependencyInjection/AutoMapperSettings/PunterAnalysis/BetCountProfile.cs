using AutoMapper;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
{
    public class BetCountProfile : Profile
    {
        public BetCountProfile()
        {
            CreateMap<HttpParameterJson, Criteria>();
            CreateMap<ModelBase<BetCountModel>, ViewModelJson>();
        }
    }
}
