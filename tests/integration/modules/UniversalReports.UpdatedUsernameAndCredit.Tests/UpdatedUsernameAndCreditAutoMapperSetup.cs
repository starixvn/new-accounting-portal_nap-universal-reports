using AutoMapper;
using NUnit.Framework;

[SetUpFixture]
public class UpdatedUsernameAndCreditAutoMapperSetup
{
    [OneTimeSetUp]
    public void UpdatedUsernameAndCreditOneTimeSetUp()
    {
        Mapper.Initialize(cfg => cfg.CreateMissingTypeMaps = true);
    }
}