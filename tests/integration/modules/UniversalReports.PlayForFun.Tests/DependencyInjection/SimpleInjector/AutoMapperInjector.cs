using AutoMapper;
using SimpleInjector;
using UniversalReports.PlayForFun.Tests.DependencyInjection.AutoMapperSettings;

namespace UniversalReports.PlayForFun.Tests.DependencyInjection.SimpleInjector
{
    public static class AutoMapperInjector
    {
        public static Container RegisterAutoMapper(this Container container)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PlayForFunSummaryProfile>();
                cfg.AddProfile<PlayForFunDetailProfile>();
                cfg.AddProfile<PlayForFunFilterProfile>();
            });

            container.Register(() => Mapper.Instance);

            return container;
        }
    }
}
