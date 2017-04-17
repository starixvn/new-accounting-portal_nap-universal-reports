using AutoMapper;

namespace UniversalReports.Sites.AutoMapperSettings.PlayForFun
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