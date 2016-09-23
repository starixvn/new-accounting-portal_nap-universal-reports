using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.NG2Statistic.Filter;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    [TestFixture]
    [Category("NG2 Filter")]
    public class FilterTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void TestSportRepository()
        {
            var criteria = new SportCriteria();
            var repository = new SimpleRepositoryImp();
            var service = new ServiceImp(repository);
            var result = service.QuerySports(criteria);
        }

        [Test]
        public void TestUserNameSuggestionRepository()
        {
            var criteria = new UserSearchCriteria()
            {
                CustId = 8,
                UserName = "iti"
            };
            var repository = new SimpleRepositoryImp();
            var service = new ServiceImp(repository);
            var result = service.QueryUserNames(criteria);
        }

        [Test]
        public void TestCurrenciesRepository()
        {
            var criteria = new CurrencyCriteria();            
            var repository = new SimpleRepositoryImp();
            var service = new ServiceImp(repository);
            var result = service.QueryCurrency(criteria);
        }
    }
}