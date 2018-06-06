using AutoMapper;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeExchange(this IProfileExpression cfg)
        {

            cfg.CreateMap<HttpParameterJson, Criteria>();

        }
    }
}
