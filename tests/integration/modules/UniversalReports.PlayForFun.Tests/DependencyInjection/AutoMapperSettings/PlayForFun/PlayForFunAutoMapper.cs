using AutoMapper;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings.PlayForFun
{
    public static class PlayForFunAutoMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SummaryProfile>();
                cfg.AddProfile<DetailProfile>();
                cfg.AddProfile<FilterProfile>();
            });
        }
    }
}