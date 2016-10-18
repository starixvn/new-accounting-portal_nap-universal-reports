using System;
using NSubstitute;
using NUnit.Asserts.Compare;
using NUnit.Framework;
using UniversalReports.Core.BalanceUpServices;
using UniversalReports.Core.TestUtility;
using UniversalReports.NG2Statistic.BaseServices;
using UniversalReports.NG2Statistic.Bettype;

namespace UniversalReports.NG2Statistic.UnitTests.Bettype
{
    [TestFixture]
    [Category("NG2 Bettype Unit Tests")]
    public class BettypeServiceUnittests
    {
        [Test]
        public void Query_AnQueryModel_ReturnRightReportByBettype()
        {
            //// Arrange
            var balance = Substitute.For<BalanceUpService>();
            balance.Query().Returns(new BalanceUpRange
            {
                BalanceUpDate = new DateTime(2016, 10, 01),
                MoveBetsDate = new DateTime(2016, 10, 12)
            });

            var fakeData = TestDataProvider.Load<BettypeModel>("BettypeService", "fakeData");
            var repository = Substitute.For<Repository>();
            repository.QueryRawData(Arg.Any<BettypeCriteria>()).Returns(fakeData);
            var expected = TestDataProvider.Load<BettypeModel>("BettypeService", "expectedData");
            var service = new BettypeServiceImp(balance, repository);

            //// Act
            var result = service.Query(Arg.Any<QueryModel>());

            //// Assert
            Assert.That(result, Compares.To(expected));
        }
    }
}