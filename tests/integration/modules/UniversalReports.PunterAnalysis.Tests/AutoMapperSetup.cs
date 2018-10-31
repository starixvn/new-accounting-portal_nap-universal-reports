using AutoMapper;
using NUnit.Framework;

namespace UniversalReports.PunterAnalysis.Tests
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
                cfg.InitializePunterAnalysis();
            });
        }
    }
}