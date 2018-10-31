using AutoMapper;
using NUnit.Framework;

namespace UniversalReports.PlayForFun.UnitTests
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
                cfg.InitializePlayForFun();
            });
        }
    }
}