using AutoMapper;
using UniversalReports.SMAWinLoss.Summary;

namespace UniversalReports.SMAWinLoss
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSMAWinLoss(this IProfileExpression cfg)
        {
            cfg.CreateMap<WinLossHttpParameter, WinLossCriteria>();
        }
    }
}