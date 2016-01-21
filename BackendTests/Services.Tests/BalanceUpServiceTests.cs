using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NAP.Reports.CompanyWinLoss.Models;
using NAP.Reports.CompanyWinLoss.Services;
using NAP.Reports.CompanyWinLoss.Services.Criteria;
using NSubstitute;
using NUnit.Framework;

namespace NAP.Reports.Services.Tests
{
    public class BalanceUpServiceTests
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }

        [Test]
        public void QueryBalanceUp_Successful()
        {
            // Arrange
            var dynamicRepository = new DynamicRepository();
            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);

            // Act
            balanceUpService.Query();
        }

        [Test]
        public void QueryBalanceUp_Twice_CallDynamicRepository_One_BecauseOfCaching()
        {
            // Arrange
            var emptyBalanceUpRange = new BalanceUpRange();
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            dynamicRepository.Get<BalanceUpRange>(Arg.Any<BalanceUpCriteria>()).Returns(emptyBalanceUpRange);

            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            balanceUpService.ClearCache();

            // Act
            balanceUpService.Query();
            balanceUpService.Query();

            // Assert
            dynamicRepository.Received(1).Get<BalanceUpRange>(Arg.Any<BalanceUpCriteria>());
        }

        [Test]
        public void QueryBalanceUp_Twice_ReturnValidValue()
        {
            // Arrange
            var emptyBalanceUpRange = new BalanceUpRange();
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            dynamicRepository.Get<BalanceUpRange>(Arg.Any<BalanceUpCriteria>()).Returns(emptyBalanceUpRange);

            var balanceUpService = new BalanceUpServiceImp(dynamicRepository);
            balanceUpService.ClearCache();

            // Act
            balanceUpService.Query();
            balanceUpService.Query();

            // Assert
            dynamicRepository.Received(1).Get<BalanceUpRange>(Arg.Any<BalanceUpCriteria>());

            // Clean 
            balanceUpService.ClearCache();
        }
    }
}
