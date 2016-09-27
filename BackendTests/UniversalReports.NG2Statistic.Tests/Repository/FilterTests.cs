using Fanex.Data.Configuration;
using Fanex.Repository;
using NUnit.Framework;
using UniversalReports.Common.BalanceUpServices;
using UniversalReports.NG2Statistic.Filter;

namespace UniversalReports.HouseWinLoss.Tests.Repository
{
    [TestFixture]
    [Category("NG2 Filter")]
    public class FilterTests
    {
        private SimpleRepository repository;
        private BalanceUpRange balance;

        [OneTimeSetUp]
        public void Init()
        {
            DbSettingProviderManager.Current.Start();
            repository = new SimpleRepositoryImp();
            balance = new BalanceUpServiceImp(repository).Query();
        }

        [Test]
        public void TestSportRepository()
        {
            var criteria = new SportCriteria();
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

            var service = new ServiceImp(repository);
            var result = service.QueryUserNames(criteria);
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