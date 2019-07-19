using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Shared;

namespace UniversalReports.PunterAnalysis.UnitTests.Shared
{
    public class PunterAnalysisServiceImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptyBetCountModelList_ReturnsEmptyModelBaseWithBetCountModel()
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Compat.Any<ICriteria>()).Returns(new List<BetCountModel>());

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetCountModel>(Arg.Compat.Any<ICriteria>());

            // Assert
            var expected = CreateEmptyModelBaseWithTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private SummaryEntity<BetCountModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new SummaryEntity<BetCountModel>
            {
                Entities = new List<BetCountModel>(),
                Total = new BetCountModel()
            };
        }

        [Test]
        public async Task Query_RepositoryReturnsNonEmptyBetCountModelList_ReturnsNonEmptyModelBaseWithBetCountModel()
        {
            // Arrange
            var nonEmptyBetCountModelList = CreateNonEmptyBetCountModelList();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Compat.Any<ICriteria>()).Returns(nonEmptyBetCountModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetCountModel>(new Criteria());

            // Assert
            var expected = CreateNonEmptyModelBaseWithBetCountModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private List<BetCountModel> CreateNonEmptyBetCountModelList()
        {
            return new List<BetCountModel>
            {
                CreateBetCountModel()
            };
        }

        private BetCountModel CreateBetCountModel()
        {
            return new BetCountModel
            {
                BetCount = 1,
                DrawCount = 1,
                WinCount = 1,
                WinLoss = 100,
                Date = DateTime.MinValue.ToShortDateString()
            };
        }

        private SummaryEntity<BetCountModel> CreateNonEmptyModelBaseWithBetCountModel()
        {
            return new SummaryEntity<BetCountModel>
            {
                Entities = CreateNonEmptyBetCountModelList(),
                Total = CreateBetCountModel()
            };
        }
    }
}