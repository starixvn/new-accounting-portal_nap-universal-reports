using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.SBPerformance.Common;
using UniversalReports.SBPerformance.Main;

namespace UniversalReports.SBPerformance.UnitTests.Main
{
    [TestFixture]
    [Category("SBPerformance")]
    public class MainServiceTests
    {
        private List<Entity> fakeEntities = new List<Entity>
        {
            new Entity {Id = 1, Name = "Name 1", BetCount = 10, RealIncome = 10, RealTurnover = 20 },
            new Entity {Id = 2, Name = "Name 2", BetCount = 5, RealIncome = 5, RealTurnover = 10 }
        };

        [Test]
        public async Task Query_WithIsShowFullColumn_ReturnRighSummaryItemModel()
        {
            // Arrange
            var expected = new SummaryEntity<ItemModel>
            {
                Entities = new List<ItemModel>
                {
                    new ItemModel {Id = 1, Name = "Name 1", BetCount = 10, RealIncome = 10, RealTurnover = 20, RealMargin = 0.5m },
                    new ItemModel {Id = 2, Name = "Name 2", BetCount = 5, RealIncome = 5, RealTurnover = 10, RealMargin = 0.5m }
                },
                Total = new ItemModel { Id = 0, Name = "Total", BetCount = 15, RealIncome = 15, RealTurnover = 30, RealMargin = 0.5m },
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Entity>(Arg.Compat.Any<Criteria>()).Returns(fakeEntities);

            var dataSourceChooser = Substitute.For<DataSourceChooser>();
            dataSourceChooser.GetSource(Arg.Compat.Any<int>()).Returns("bettrans");

            var service = new MainServiceImp(repository, dataSourceChooser);

            // Act
            var result = await service.Query(new HttpParameter
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                IsShowCust = true,
                IsShowSite = false,
                IsShowLeague = false,
                IsShowSport = false,
                Margin = 0,
                TimeRange = -1,
                Top = 50,
                IsShowFullColumn = true
            });

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expected));
        }

        [Test]
        public async Task Query_WithIsNotShowFullColumn_ReturnRighSummaryItemModel()
        {
            // Arrange
            var expected = new SummaryEntity<ItemModel>
            {
                Entities = new List<ItemModel>
                {
                    new ItemModel {Id = 1, Name = "Name 1", BetCount = 10, RealIncome = 0, RealTurnover = 0, RealMargin = 0.5m },
                    new ItemModel {Id = 2, Name = "Name 2", BetCount = 5, RealIncome = 0, RealTurnover = 0, RealMargin = 0.5m }
                },
                Total = new ItemModel { Id = 0, Name = "Total", BetCount = 15, RealIncome = 0, RealTurnover = 0, RealMargin = 0.5m },
            };

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<Entity>(Arg.Compat.Any<Criteria>()).Returns(fakeEntities);

            var dataSourceChooser = Substitute.For<DataSourceChooser>();
            dataSourceChooser.GetSource(Arg.Compat.Any<int>()).Returns("bettrans");

            var service = new MainServiceImp(repository, dataSourceChooser);

            // Act
            var result = await service.Query(new HttpParameter
            {
                FromDate = DateTime.Now,
                ToDate = DateTime.Now,
                IsShowCust = true,
                IsShowSite = false,
                IsShowLeague = false,
                IsShowSport = false,
                Margin = 0,
                TimeRange = -1,
                Top = 50,
                IsShowFullColumn = false
            });

            // Assert
            Assert.That(result, IsDeeplyEqual.To(expected));
        }
    }
}