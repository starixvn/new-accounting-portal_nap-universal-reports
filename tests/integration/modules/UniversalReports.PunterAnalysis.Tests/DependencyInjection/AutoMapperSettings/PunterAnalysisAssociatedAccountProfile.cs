using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.Tests.DependencyInjection.AutoMapperSettings
{
    public class PunterAnalysisAssociatedAccountProfile : Profile
    {
        public PunterAnalysisAssociatedAccountProfile()
        {
            CreateMap<HttpParameterJson, UserRoleQueryCriteria>(MemberList.Source);
            CreateMap<ReportModelBase<UserRoleModel>, ViewModelJson>(MemberList.Source);
        }
    }
}
