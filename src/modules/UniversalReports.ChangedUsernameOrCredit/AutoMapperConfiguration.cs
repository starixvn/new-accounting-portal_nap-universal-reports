using AutoMapper;
using UniversalReports.UpdatedUsernameCredit.Common;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeUpdatedUsernameCredit(this IProfileExpression cfg)
        {
            cfg.CreateMap<BaseMessage, UpdatedCredit.Criteria>();
            cfg.CreateMap<BaseMessage, UpdatedUsername.Criteria>();
            cfg.CreateMap<UpdatedUsernameEntity, UpdatedUsernameModel>();
            cfg.CreateMap<UpdatedCreditModel, UpdatedCreditExcelModel>();
            cfg.CreateMap<UpdatedCreditEntity, UpdatedCreditModel>();
            cfg.CreateMap<UpdatedUsernameModel, UpdatedUsernameExcelModel>();
        }
    }
}
