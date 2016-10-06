using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;

namespace UniversalReports.Core.Tests.BalanceUpServices
{
    public class BalanceUpRepositoryTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        [Category("RepositoryTests")]
        public void Get_Successful()
        {
            var repository = new SimpleRepositoryImp();
            var criteria = new BalanceUpCriteria();
            repository.Get<BalanceUpRange>(criteria);
        }
    }
}