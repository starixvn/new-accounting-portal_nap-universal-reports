using AutoMapper;
using NUnit.Framework;

[SetUpFixture]
public class PlayForFunAutoMapperSetup
{
    [OneTimeSetUp]
    public void PlayForFunOneTimeSetUp()
    {
        Mapper.Initialize(cfg => cfg.CreateMissingTypeMaps = true);
    }
}