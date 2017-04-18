using AutoMapper;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings
{
    public static class PlayForFunAutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PlayForFunSummaryProfile>();
                cfg.AddProfile<PlayForFunDetailProfile>();
                cfg.AddProfile<PlayForFunFilterProfile>();
            });
        }
    }
}