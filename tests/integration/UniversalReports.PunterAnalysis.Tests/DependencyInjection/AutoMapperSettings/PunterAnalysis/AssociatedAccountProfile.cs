using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings.PunterAnalysis
{
    public class AssociatedAccountProfile : Profile
    {
        public AssociatedAccountProfile()
        {
            CreateMap<HttpParameterJson, Criteria>();
            CreateMap<ModelBase<AssociatedAccountModel>, ViewModelJson>();
        }
    }
}
