using Fanex.Data.Configuration;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.Models;
using UniversalReports.CompanyWinLoss.Common.Services;

namespace UniversalReports.CompanyWinLoss.Tests.Common
{
    [TestFixture]
    [Category("CompanyWinLossIntegrationTests")]
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
        [Category("CompanyWinLossUnitTests")]
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
        [Category("CompanyWinLossUnitTests")]
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
