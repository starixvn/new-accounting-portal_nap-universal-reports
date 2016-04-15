using Fanex.Data.Configuration;
using NUnit.Framework;

namespace UniversalReports.CompanyWinLoss.Tests
{
    [SetUpFixture]
    public class CompanyWinLossSetUpFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbSettingProviderManager.Current.Start();
        }
    }
}
