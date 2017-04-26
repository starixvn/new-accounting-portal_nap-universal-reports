using NUnit.Framework;
using UniversalReports.DatabaseTestSetup;

[SetUpFixture]
public class CoreFanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        FanexDataSetup.Setup();
    }
}