using AutoMapper;
using UniversalReports.PunterAnalysis.AssociatedAccount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.Sites.AutoMapperSettings.PunterAnalysis
{
    public class AssociatedAccountProfile : Profile
    {
        public AssociatedAccountProfile()
        {
            CreateMap<HttpParameterJson, UserRoleQueryCriteria>(MemberList.Source);
            CreateMap<ReportModelBase<UserRoleModel>, ViewModelJson>(MemberList.Source);
        }
    }
}