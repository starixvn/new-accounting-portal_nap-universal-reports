using NUnit.Framework;
using UniversalReports.DatabaseTestSetup;

[SetUpFixture]
public class FanexDataSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        FanexDataSetup.Setup();
    }
}