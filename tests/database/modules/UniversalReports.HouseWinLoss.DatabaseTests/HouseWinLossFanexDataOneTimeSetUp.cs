using NUnit.Framework;
using UniversalReports.DatabaseTestSetup;

[SetUpFixture]
public class PunterAnalysisFanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        FanexDataSetup.Setup();
    }
}