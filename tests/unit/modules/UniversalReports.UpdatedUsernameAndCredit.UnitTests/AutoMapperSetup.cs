using AutoMapper;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameCredit;

[SetUpFixture]
public class AutoMapperSetup
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMissingTypeMaps = true;
            cfg.InitializeUpdatedUsernameCredit();
        });
    }
}