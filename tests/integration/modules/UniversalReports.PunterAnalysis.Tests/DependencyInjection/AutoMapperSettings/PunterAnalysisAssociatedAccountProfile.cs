using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisAssociatedAccountProfile : Profile
    {
        public PunterAnalysisAssociatedAccountProfile()
        {
            CreateMap<HttpParameterJson, UserRoleQueryCriteria>(MemberList.Source);
        }
    }
}
