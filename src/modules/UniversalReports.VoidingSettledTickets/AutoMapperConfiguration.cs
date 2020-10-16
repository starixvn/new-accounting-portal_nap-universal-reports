using AutoMapper;
using UniversalReports.VoidingSettledTickets.Criteria;
using UniversalReports.VoidingSettledTickets.Requests;

namespace UniversalReports.VoidingSettledTickets
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeVoidingSettledTickets(this IProfileExpression cfg)
        {
            cfg.CreateMap<ProductRequest, ProductCriteria>();
        }
    }
}