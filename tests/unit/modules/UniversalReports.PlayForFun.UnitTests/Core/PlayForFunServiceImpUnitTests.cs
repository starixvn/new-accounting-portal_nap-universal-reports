using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Core;
using UniversalReports.PlayForFun.Summary.Model;

namespace UniversalReports.PlayForFun.UnitTests.Core
{
    public class PlayForFunServiceImpUnitTests
    {
        [Test]
        public async Task Query_RepositoryReturnsEmptySummaryModelList_ReturnsEmptyModelBaseWithSummaryModel()
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SummaryModel>(Arg.Any<ICriteria>()).Returns(new List<SummaryModel>());

            // Act
            var PlayForFunService = new PlayForFunServiceImp(repository);
            var modelBase = await PlayForFunService.Query<SummaryModel>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateEmptyModelBaseWithTypeModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private ReportModelBase<SummaryModel> CreateEmptyModelBaseWithTypeModel()
        {
            return new ReportModelBase<SummaryModel>
            {
                Entities = new List<SummaryModel>(),
                Total = new SummaryModel()
            };
        }

        [Test]
        public async Task Query_RepositoryReturnsNonEmptySummaryModelList_ReturnsNonEmptyModelBaseWithSummaryModel()
        {
            // Arrange
            var nonEmptySummaryModelList = CreateNonEmptySummaryModelList();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<SummaryModel>(Arg.Any<ICriteria>()).Returns(nonEmptySummaryModelList);

            // Act
            var PlayForFunService = new PlayForFunServiceImp(repository);
            var modelBase = await PlayForFunService.Query<SummaryModel>(Arg.Any<ICriteria>());

            // Assert
            var expected = CreateNonEmptyModelBaseWithSummaryModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private List<SummaryModel> CreateNonEmptySummaryModelList()
        {
            return new List<SummaryModel>
            {
                CreateSummaryModel()
            };
        }

        private SummaryModel CreateSummaryModel()
        {
            return new SummaryModel
            {
                BetCount = 1,
                PlayerCount = 1,
                Turnover = 100,
                WinLoss = 100,
            };
        }

        private ReportModelBase<SummaryModel> CreateNonEmptyModelBaseWithSummaryModel()
        {
            return new ReportModelBase<SummaryModel>
            {
                Entities = CreateNonEmptySummaryModelList(),
                Total = CreateSummaryModel()
            };
        }
    }
}