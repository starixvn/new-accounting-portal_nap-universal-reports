using NUnit.Framework;
using UniversalReports.DatabaseTestSetup;

[SetUpFixture]
public class HouseWinLossFanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        FanexDataSetup.Setup();
    }
}