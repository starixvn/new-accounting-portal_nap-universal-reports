using AutoMapper;
using NUnit.Framework;
using UniversalReports.HouseWinLoss;

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