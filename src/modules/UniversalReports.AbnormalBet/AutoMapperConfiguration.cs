using AutoMapper;
using UniversalReports.AbnormalBet.Criteria;
using UniversalReports.AbnormalBet.HttpParameter;
using UniversalReports.AbnormalBet.Model;

namespace UniversalReports.AbnormalBet
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAbnormalBet(this IProfileExpression cfg)
        {

            cfg.CreateMap<LicenseeHttpParameter, LicenseeQueryCriteria>();
            cfg.CreateMap<MemberHttpParameter, MemberQueryCriteria>();
            cfg.CreateMap<LicenseeModel, LicenseeExcelModel>();
            cfg.CreateMap<MemberModel, MemberExcelModel>();
        }
    }
}
