using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.MediatorInjector.PunterAnalysis
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
