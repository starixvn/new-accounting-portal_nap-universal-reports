using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.NG2Statistic.Filter;

namespace UniversalReports.NG2Statistic.Tests.Filter
{
    [TestFixture]
    [Category("NG2 Filter")]
    public class FilterTests
    {
        private SimpleRepository repository;

        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
            repository = new SimpleRepositoryImp();
        }

        [Test]
        public void TestSportRepository()
        {
            var criteria = new SportCriteria();
            var service = new ServiceImp(repository);
            service.QuerySports(criteria);
        }

        [Test]
        public void TestUserNameSuggestionRepository()
        {
            var criteria = new UserSearchCriteria
            {
                CustId = 8,
                UserName = "iti"
            };

            var service = new ServiceImp(repository);
            service.QueryUserNames(criteria);
        }

        [Test]
        public void TestCurrenciesRepository()
        {
            var criteria = new CurrencyCriteria();
            var service = new ServiceImp(repository);
            var result = service.QueryCurrency(criteria);
        }
    }
}