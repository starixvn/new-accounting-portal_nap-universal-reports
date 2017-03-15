using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.HouseWinLoss.UnitTests;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueServiceByMonthImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptyLeagueRawModelList_ReturnsEmptyReportModel()
        {
            // Arrange
            var emptyReportModel = new ReportModel();
            var emptyLeagueRawModelList = new List<LeagueRawModel>();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(emptyLeagueRawModelList);

            // Act
            var service = new LeagueServiceByMonth(repository);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(emptyReportModel));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForOneYearOneMonth_ReturnsReportModelWithOneYearOneMonthAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByMonth\\ExpectedReportModelWithOneYearOneMonthAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByMonth\\LeagueRawModelForOneYearOneMonth.json";

            var expectedReportModelWithOneYearOneMonthAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForOneYearOneMonth = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForOneYearOneMonth);

            // Act
            var service = new LeagueServiceByMonth(repository);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithOneYearOneMonthAndGrandTotal));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForOneYearTwoMonths_ReturnsReportModelWithOneYearTwoMonthsAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByMonth\\ExpectedReportModelWithOneYearTwoMonthsAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByMonth\\LeagueRawModelForOneYearTwoMonths.json";

            var expectedReportModelWithOneYearTwoMonthsAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForOneYearTwoMonths = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForOneYearTwoMonths);

            // Act
            var service = new LeagueServiceByMonth(repository);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithOneYearTwoMonthsAndGrandTotal));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForTwoYearsTwoMonths_ReturnsReportModelWithTwoYearsTwoMonthsAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByMonth\\ExpectedReportModelWithTwoYearsTwoMonthsAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByMonth\\LeagueRawModelForTwoYearsTwoMonths.json";

            var expectedReportModelWithTwoYearsTwoMonthsAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForTwoYearsTwoMonths = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForTwoYearsTwoMonths);

            // Act
            var service = new LeagueServiceByMonth(repository);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithTwoYearsTwoMonthsAndGrandTotal));
        }

        [Test]
        public void GetGroupNames_EmptyGroup_ReturnEmptyGroupNames()
        {
            // Arrange
            var emptyGroup = new Dictionary<int, List<int>>
            {
            };

            var emptyGroupNames = new List<string>();

            // Act
            var groupNames = GetGroupNamesAct(emptyGroup);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(emptyGroupNames));
        }

        [Test]
        public void GetGroupNames_TwoYearsTwoMonths_ReturnCorrectGroupNames()
        {
            // Arrange
            var monthGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 12 } },
                { 2017, new List<int> { 1 } },
            };

            var expected = new List<string>
            {
                "Year 2016",
                "December",
                "Year 2017",
                "January",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(monthGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void GetGroupNames_OneYearTwoMonths_ReturnCorrectGroupNames()
        {
            // Arrange
            var monthGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 11, 12 } }
            };

            var expected = new List<string>
            {
                "Year 2016",
                "November",
                "December",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(monthGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void GetGroupNames_OneYearOneMonth_ReturnCorrectGroupNames()
        {
            // Arrange
            var monthGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 11 } }
            };

            var expected = new List<string>
            {
                "Year 2016",
                "November",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(monthGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        private List<string> GetGroupNamesAct(Dictionary<int, List<int>> monthGroups)
        {
            var repository = Substitute.For<IDynamicRepository>();

            // Act
            var service = new LeagueServiceByMonth(repository);

            return service.GetGroupNames(monthGroups).ToList();
        }
    }
}
