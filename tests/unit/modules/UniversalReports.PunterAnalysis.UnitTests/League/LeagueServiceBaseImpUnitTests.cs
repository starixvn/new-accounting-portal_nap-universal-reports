using System.Collections.Generic;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.League;
using UniversalReports.PunterAnalysis.League.Model;

namespace UniversalReports.PunterAnalysis.UnitTests.League
{
    public class LeagueServiceBaseImpUnitTests
    {
        [Test]
        public void GetMappingGroups_EmptyLeagueMappingModelList_ReturnsEmptyGroup()
        {
            // Arrange
            var emptyGroup = new Dictionary<int, List<int>>();
            var repository = Substitute.For<IDynamicRepository>();

            // Act
            var service = new LeagueServiceByMonth(repository);
            var mappingGroups = service.GetMappingGroups(new List<LeagueMappingModel>());

            Assert.That(mappingGroups, IsDeeplyEqual.To(emptyGroup));
        }

        [Test]
        public void GetMappingGroups_LeagueMappingModelListWithYearAndMonthUnordered_ReturnsGroupWithYearAndMonthOrderedAsc()
        {
            // Arrange
            const string InputFileName = "LeagueServiceBase\\LeagueMappingModelListWithYearAndMonthUnordered.json";

            var mappingGroupsWithYearAndMonthOrderedAsc = CreateMappingGroupsWithYearAndMonthOrderedAsc();
            var leagueMappingModelListWithYearAndMonthUnordered = TestDataLoader.Load<List<LeagueMappingModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();

            // Act
            var service = new LeagueServiceByMonth(repository);
            var mappingGroups = service.GetMappingGroups(leagueMappingModelListWithYearAndMonthUnordered);

            Assert.That(mappingGroups, IsDeeplyEqual.To(mappingGroupsWithYearAndMonthOrderedAsc));
        }

        [Test]
        public void GetMappingGroups_LeagueMappingModelListWithYearAndMonthOrderedDesc_ReturnsGroupWithYearAndMonthOrderedAsc()
        {
            // Arrange
            const string InputFileName = "LeagueServiceBase\\LeagueMappingModelListWithYearAndMonthOrderedDesc.json";

            var mappingGroupsWithYearAndMonthOrderedAsc = CreateMappingGroupsWithYearAndMonthOrderedAsc();
            var leagueMappingModelListWithYearAndMonthUnordered = TestDataLoader.Load<List<LeagueMappingModel>>(InputFileName);
            var repository = Substitute.For<IDynamicRepository>();

            // Act
            var service = new LeagueServiceByMonth(repository);
            var mappingGroups = service.GetMappingGroups(leagueMappingModelListWithYearAndMonthUnordered);

            Assert.That(mappingGroups, IsDeeplyEqual.To(mappingGroupsWithYearAndMonthOrderedAsc));
        }

        [Test]
        public void GetMappingGroups_LeagueMappingModelListWithYearAndMonthOrderedAsc_ReturnsGroupWithYearAndMonthOrderedAsc()
        {
            // Arrange
            const string InputFileName = "LeagueServiceBase\\LeagueMappingModelListWithYearAndMonthOrderedAsc.json";

            var mappingGroupsWithYearAndMonthOrderedAsc = CreateMappingGroupsWithYearAndMonthOrderedAsc();
            var leagueMappingModelListWithYearAndMonthUnordered = TestDataLoader.Load<List<LeagueMappingModel>>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();

            // Act
            var service = new LeagueServiceByMonth(repository);
            var mappingGroups = service.GetMappingGroups(leagueMappingModelListWithYearAndMonthUnordered);

            Assert.That(mappingGroups, IsDeeplyEqual.To(mappingGroupsWithYearAndMonthOrderedAsc));
        }

        private Dictionary<int, List<int>> CreateMappingGroupsWithYearAndMonthOrderedAsc()
        {
            return new Dictionary<int, List<int>>
            {
                { 2016, new List<int> { 11, 12 } },
                { 2017, new List<int> { 1, 2 } }
            };
        }
    }
}