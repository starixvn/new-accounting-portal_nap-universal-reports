using AutoMapper;
using NUnit.Framework;

namespace UniversalReports.CashOutPerformance.UnitTests
{
    [SetUpFixture]
    public class AutoMapperSetup
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.InitializeCashOutPerformance();
            });
        }
    }
}