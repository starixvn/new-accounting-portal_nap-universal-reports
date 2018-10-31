using AutoMapper;
using NUnit.Framework;

namespace UniversalReports.HouseWinLoss.UnitTests
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