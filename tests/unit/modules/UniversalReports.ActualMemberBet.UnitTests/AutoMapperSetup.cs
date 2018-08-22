using AutoMapper;
using NUnit.Framework;
using UniversalReports.ActualMemberBet;

[SetUpFixture]
public class AutoMapperSetup
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.InitializeActualMemberBet();
        });
    }
}