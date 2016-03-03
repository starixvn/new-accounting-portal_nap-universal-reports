using Fanex.Data.Configuration;
using NUnit.Framework;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    public abstract class BaseSetupServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }
    }
}
