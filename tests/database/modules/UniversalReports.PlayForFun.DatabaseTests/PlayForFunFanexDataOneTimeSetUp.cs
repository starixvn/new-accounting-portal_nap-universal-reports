using NUnit.Framework;
using UniversalReports.DatabaseTestSetup;

[SetUpFixture]
public class PlayForFunFanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        FanexDataSetup.Setup();
    }
}