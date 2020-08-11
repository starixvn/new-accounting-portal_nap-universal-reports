using AutoMapper;
using UniversalReports.SMAWinLoss.Summary;
using UniversalReports.SMAWinLoss.VirtualRate;

namespace UniversalReports.SMAWinLoss
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeSMAWinLoss(this IProfileExpression cfg)
        {
            cfg.CreateMap<WinLossHttpParameter, WinLossCriteria>();
            cfg.CreateMap<VirtualRateHttpParameter, VirtualRateCriteria>();
        }
    }
}