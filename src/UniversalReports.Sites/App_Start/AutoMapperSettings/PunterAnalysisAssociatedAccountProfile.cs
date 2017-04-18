using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.AutoMapperSettings
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