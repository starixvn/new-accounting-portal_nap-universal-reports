using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using NUnit.Framework;

[SetUpFixture]
public class FanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        DbSettingProviderManager
       .StartNewSession()
       .Use(new OldConnectionStringProvider())
       .UseDefaultDbSettingProvider(
         resourcePath: $"~/App_Data/LOCAL",
         ignoreRedundantParameters: false,
         enableWatching: true)
       .Run();
    }
}
