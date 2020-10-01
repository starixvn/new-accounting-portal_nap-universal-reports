using AutoMapper;
using System.Collections.Generic;
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
            cfg.CreateMap<LicenseeHttpParameterExcel, LicenseeQueryCriteria>();
            cfg.CreateMap<MemberHttpParameter, MemberQueryCriteria>();
            cfg.CreateMap<MemberHttpParameterExcel, MemberQueryCriteria>();
            cfg.CreateMap<LicenseeItemModel, LicenseeExcelModel>();
            cfg.CreateMap<MemberItemModel, MemberExcelModel>();
        }
    }
}