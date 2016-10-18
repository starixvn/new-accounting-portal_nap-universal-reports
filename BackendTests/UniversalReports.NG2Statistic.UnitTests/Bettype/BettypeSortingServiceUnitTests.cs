using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Bettype;

namespace UniversalReports.NG2Statistic.UnitTests.Bettype
{
    [TestFixture]
    public class BettypeSortingServiceUnitTests
    {
        [Test]
        public void SortBettype_SortColumnNameIsTotalBetsAndDirectionIsAscending_ReturnRightBettypeModel()
        {
            var sortQueryModel = TestDataProvider.Load<QueryModel>("SortingService", "sortQueryModel");
            var sortFakeData = TestDataProvider.Load<BettypeModel>("SortingService", "sortFakeData");
            var sortExpectedData = TestDataProvider.Load<BettypeModel>("SortingService", "sortExpectedData");
            var service = new SortingServiceImp();

            service.SortingData(sortFakeData, sortQueryModel);

            Assert.That(sortFakeData, Compares.To(sortExpectedData));
        }
    }
}