using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using Fanex.Data.Repository;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Core.Tests.BalanceUpServices
{
    public class BalanceUpRepositoryTests
    {
        [OneTimeSetUp]
        public void Init()
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

        [Test]
        [Category("RepositoryTests")]
        public void Get_Successful()
        {
            var repository = new DynamicRepository();
            var criteria = new BalanceUpCriteria();
            repository.Get<BalanceUpRange>(criteria);
        }
    }
}