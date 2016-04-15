using Fanex.Data.Repository;
using NSubstitute;
using NUnit.Framework;
using UniversalReports.CompanyWinLoss.Common.BalanceUpServices;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.Services
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class CommonBalanceUpServiceTests
    {       
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
