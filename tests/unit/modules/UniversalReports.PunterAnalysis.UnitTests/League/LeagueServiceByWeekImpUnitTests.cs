using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueServiceByWeekImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptyLeagueRawModelList_ReturnsEmptyReportModel()
        {
            // Arrange
            var emptyReportModel = new ReportModel();

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(new List<LeagueRawModel>());

            // Act
            var service = new LeagueServiceByMonth(repository);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(emptyReportModel));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForOneYearOneWeek_ReturnsReportModelWithOneYearOneWeekAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByWeek\\ExpectedReportModelWithOneYearOneWeekAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByWeek\\LeagueRawModelForOneYearOneWeek.json";

            var expectedReportModelWithOneYearOneWeekAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForOneYearOneWeek = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForOneYearOneWeek);

            var dateTimeService = new DateTimeServiceImp();

            // Act
            var service = new LeagueServiceByWeek(repository, dateTimeService);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithOneYearOneWeekAndGrandTotal));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForOneYearTwoWeeks_ReturnsReportModelWithOneYearTwoWeeksAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByWeek\\ExpectedReportModelWithOneYearTwoWeeksAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByWeek\\LeagueRawModelForOneYearTwoWeeks.json";

            var expectedReportModelWithOneYearTwoWeeksAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForOneYearTwoWeeks = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForOneYearTwoWeeks);

            var dateTimeService = new DateTimeServiceImp();

            // Act
            var service = new LeagueServiceByWeek(repository, dateTimeService);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithOneYearTwoWeeksAndGrandTotal));
        }

        [Test]
        public async Task Query_RepositoryReturnsLeagueRawModelForTwoYearsTwoWeeks_ReturnsReportModelWithTwoYearsTwoWeeksAndGrandTotal()
        {
            // Arrange
            const string ExpectedFileName = "LeagueServiceByWeek\\ExpectedReportModelWithTwoYearsTwoWeeksAndGrandTotal.json";
            const string InputFileName = "LeagueServiceByWeek\\LeagueRawModelForTwoYearsTwoWeeks.json";

            var expectedReportModelWithTwoYearsTwoWeeksAndGrandTotal = TestDataLoader.Load<ReportModel>(ExpectedFileName);
            var leagueRawModelForTwoYearsTwoWeeks = TestDataLoader.Load<List<LeagueRawModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<LeagueRawModel>(Arg.Any<ICriteria>()).Returns(leagueRawModelForTwoYearsTwoWeeks);

            var dateTimeService = new DateTimeServiceImp();

            // Act
            var service = new LeagueServiceByWeek(repository, dateTimeService);
            var reportModel = await service.Query(Arg.Any<ICriteria>());

            // Assert
            Assert.That(reportModel, IsDeeplyEqual.To(expectedReportModelWithTwoYearsTwoWeeksAndGrandTotal));
        }

        [Test]
        public void GetGroupNames_EmptyGroup_ReturnEmptyGroupNames()
        {
            // Arrange
            var emptyGroup = new Dictionary<int, List<int>>();

            var emptyGroupNames = new List<string>();

            // Act
            var groupNames = GetGroupNamesAct(emptyGroup);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(emptyGroupNames));
        }

        [Test]
        public void GetGroupNames_TwoYearsTwoWeeks_ReturnCorrectGroupNames()
        {
            // Arrange
            var weekGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 52 } },
                { 2017, new List<int> { 1 } }
            };

            var expected = new List<string>
            {
                "Year 2016",
                "Week 52 (Dec 26, 2016)",
                "Year 2017",
                "Week 1 (Jan 02, 2017)",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(weekGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void GetGroupNames_OneYearTwoWeeks_ReturnCorrectGroupNames()
        {
            // Arrange
            var weekGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 51, 52 } }
            };

            var expected = new List<string>
            {
                "Year 2016",
                "Week 51 (Dec 19, 2016)",
                "Week 52 (Dec 26, 2016)",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(weekGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        [Test]
        public void GetGroupNames_OneYearOneWeek_ReturnCorrectGroupNames()
        {
            // Arrange
            var weekGroups = new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 52 } }
            };

            var expected = new List<string>
            {
                "Year 2016",
                "Week 52 (Dec 26, 2016)",
                "Grand Total"
            };

            // Act
            var groupNames = GetGroupNamesAct(weekGroups);

            // Assert
            Assert.That(groupNames, IsDeeplyEqual.To(expected));
        }

        private List<string> GetGroupNamesAct(Dictionary<int, List<int>> weekGroups)
        {
            var repository = Substitute.For<IDynamicRepository>();
            var dateTimeService = new DateTimeServiceImp();

            // Act
            var service = new LeagueServiceByWeek(repository, dateTimeService);

            return service.GetGroupNames(weekGroups).ToList();
        }
    }
}