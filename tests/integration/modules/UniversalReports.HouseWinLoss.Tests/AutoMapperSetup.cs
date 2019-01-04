using AutoMapper;
using NUnit.Framework;

namespace UniversalReports.HouseWinLoss.Tests
{
    [SetUpFixture]
    public class AutoMapperSetup
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.InitializeHouseWinLoss();
            });
        }
    }
}