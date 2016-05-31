using Fanex.Data.Repository;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UniversalReports.CompanyWinLoss.Common.Criteria;
using UniversalReports.CompanyWinLoss.Common.MatchDetail;
using BalanceUp = UniversalReports.CompanyWinLoss.Common.BalanceUpServices;
using Utility = UniversalReports.CompanyWinLoss.UnitTests.TestUtility;

namespace UniversalReports.CompanyWinLoss.UnitTests.Common.MatchDetail
{
    [TestFixture]
    [Category("CompanyWinLossUnitTests")]
    public class RawWinLossServiceUnitTests
    {
        [Test]
        public void Query_BalanceUpSourceChooserReturnsTwoSources_DynamicRepositoryCallTwice()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var fakeSources = Utility.TestDataLoader.Load<List<BalanceUp.BalanceUpSource>>("data-1-fakeSources");
            var balanceUpSourceChooser = Substitute.For<BalanceUp.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(fakeSources);

            var service = new RawWinLossServiceImp(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);

            // Act
            var criteria = new Utility.FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            dynamicRepository.Received(2).Fetch<RawWinLoss>(Arg.Any<WinLossCriteria>());
        }

        [Test]
        public void Query_TwoSources_CallCalculationServiceWithTwoDimensionArray()
        {
            // Arrange
            var dynamicRepository = Substitute.For<IDynamicRepository>();
            var balanceUpSummationService = Substitute.For<BalanceUpSummationService>();

            var fakeSources = Utility.TestDataLoader.Load<List<BalanceUp.BalanceUpSource>>("data-1-fakeSources");
            var balanceUpSourceChooser = Substitute.For<BalanceUp.BalanceUpSourceChooser>();
            balanceUpSourceChooser.Determine(DateTime.Today, DateTime.Today).Returns(fakeSources);

            var service = Substitute.ForPartsOf<RawWinLossServiceImp>(dynamicRepository, balanceUpSummationService, balanceUpSourceChooser);
            var fakeData = Utility.TestDataLoader.Load<List<RawWinLoss>>("data-1-fakeData");
            service.QueryBySource(Arg.Any<BalanceUp.BalanceUpSource>(), Arg.Any<WinLossCriteria>()).Returns(fakeData);

            // Act
            var criteria = new Utility.FakeWinLossCriteria { StartDate = DateTime.Today, EndDate = DateTime.Today };
            service.Query(criteria);

            // Assert
            balanceUpSummationService.Received().CalculateSum(Arg.Is<IEnumerable<IEnumerable<RawWinLoss>>>(x => x.Count() == 2));
        }        
    }
}
