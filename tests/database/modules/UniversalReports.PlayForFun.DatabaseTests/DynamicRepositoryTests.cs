//using Fanex.Data.Repository;
//using NUnit.Framework;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using BetCountCriteria = UniversalReports.PlayForFun.BetCount.Model.Criteria;
//using ProductSportBetTypeFilter = UniversalReports.PlayForFun.Filter.ProductSportBetType;
//using SummaryCriteria = UniversalReports.PlayForFun.Summary.Model.Criteria;

//namespace UniversalReports.PlayForFun.DatabaseTests
//{
//    public class DynamicRepositoryTests
//    {
//        [Test]
//        public async Task DetailSp_Test_ColumnIsMapCorrectly()
//        {
//            // Arrange
//            var criteria = new BetCountCriteria
//            {
//                PeriodType = 3,
//                FromDate = new DateTime(2016, 8, 1),
//                ToDate = new DateTime(2016, 12, 1),
//                CustId = 19575728,
//                ListCombinationId = "21802681,21802682,21802683,21901011",
//                SportId = 1,
//                BetTypeId = 1,
//                LiveStatusId = 1
//            };

//            // Act
//            var repository = new DynamicRepository();
//            var models = await repository.FetchAsync<BetCountModel>(criteria);
//            var firstModel = models.First();

//            // Assert
//            Assert.That(firstModel.BetCount, Is.Not.Zero);
//            Assert.That(firstModel.WinLoss, Is.Not.Zero);
//            Assert.That(firstModel.WinCount, Is.Not.Zero);
//            Assert.That(firstModel.DrawCount, Is.Not.Zero);
//            Assert.That(firstModel.Date, Is.Not.Empty);
//        }

//        [Test]
//        public async Task SummarySp_Test_ColumnIsMapCorrectly()
//        {
//            // Arrange
//            var criteria = new SummaryCriteria
//            {
//                TopRow = 10,
//                OrderBy = 1,
//                SortBy = 2,
//                PeriodType = 3,
//                FromDate = new DateTime(2016, 8, 1),
//                ToDate = new DateTime(2016, 12, 1),
//                Depth = 1,
//                ListCombinationId = "21802681,21802682,21802683,21901011",
//            };

//            // Act
//            var repository = new DynamicRepository();
//            var models = await repository.FetchAsync<SummaryModel>(criteria);
//            var firstModel = models.First();

//            // Assert
//            Assert.That(firstModel.BetCount, Is.Not.Zero);
//            Assert.That(firstModel.WinLoss, Is.Not.Zero);
//            Assert.That(firstModel.Turnover, Is.Not.Zero);
//            Assert.That(firstModel.CustId, Is.Not.Zero);
//            Assert.That(firstModel.Username, Is.Not.Null.And.Not.Empty);
//        }

//        [Test]
//        public async Task ProductQuerySp_Test_ColumnIsMapCorrectly()
//        {
//            // Arrange
//            var criteria = new ProductSportBetTypeFilter.QueryCriteria();

//            // Act
//            var repository = new DynamicRepository();
//            var models = await repository.FetchAsync<ProductSportBetTypeFilter.ProductSportBetTypeEntity>(criteria);
//            var firstModel = models.First();

//            // Assert
//            Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
//            Assert.That(firstModel.SportGroup, Is.Not.Null.And.Not.Empty);
//            Assert.That(firstModel.SportName, Is.Not.Null.And.Not.Empty);
//            Assert.That(firstModel.BetTypeName, Is.Not.Null.And.Not.Empty);
//            Assert.That(firstModel.Value, Is.Not.Zero);
//            Assert.That(firstModel.RenderType, Is.GreaterThanOrEqualTo(1));
//        }
//    }
//}