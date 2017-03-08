using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.BetCount.Model;
using UniversalReports.PunterAnalysis.Core;

namespace UniversalReports.PunterAnalysis.UnitTests.Core
{
    public class PunterAnalysisServiceImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptyBetCountModelList_ReturnsEmptyModelBaseWithBetCountModel()
        {
            // Arrange
            var emptyBetCountModelList = new List<BetCountModel>();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<BetCountModel>(Arg.Any<ICriteria>()).Returns(emptyBetCountModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetCountModel>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateEmptyModelBaseWithTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private ModelBase<BetCountModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ModelBase<BetCountModel>
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
            repository.FetchAsync<BetCountModel>(Arg.Any<ICriteria>()).Returns(nonEmptyBetCountModelList);

            // Act
            var punterAnalysisService = new PunterAnalysisServiceImp(repository);
            var modelBase = await punterAnalysisService.Query<BetCountModel>(Arg.Any<ICriteria>());

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
                Date = DateTime.MinValue
            };
        }

        private ModelBase<BetCountModel> CreateNonEmptyModelBaseWithBetCountModel()
        {
            return new ModelBase<BetCountModel>
            {
                Entities = CreateNonEmptyBetCountModelList(),
                Total = CreateBetCountModel()
            };
        }
    }
}
