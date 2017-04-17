using Fanex.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Filter.Product;
using UniversalReports.PlayForFun.Summary.Model;
using ProductQueryCriteria = UniversalReports.PlayForFun.Filter.Product.Criteria;
using SummaryCriteria = UniversalReports.PlayForFun.Summary.Model.Criteria;

namespace UniversalReports.PlayForFun.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        //[Test]
        //public async Task DetailSp_Test_ColumnIsMapCorrectly()
        //{
        //    // Arrange
        //    var criteria = new BetCountCriteria
        //    {
        //        PeriodType = 3,
        //        FromDate = new DateTime(2016, 8, 1),
        //        ToDate = new DateTime(2016, 12, 1),
        //        CustId = 19575728,
        //        ListCombinationId = "21802681,21802682,21802683,21901011",
        //        SportId = 1,
        //        BetTypeId = 1,
        //        LiveStatusId = 1
        //    };

        //    // Act
        //    var repository = new DynamicRepository();
        //    var models = await repository.FetchAsync<BetCountModel>(criteria);
        //    var firstModel = models.First();

        //    // Assert
        //    Assert.That(firstModel.BetCount, Is.Not.Zero);
        //    Assert.That(firstModel.WinLoss, Is.Not.Zero);
        //    Assert.That(firstModel.WinCount, Is.Not.Zero);
        //    Assert.That(firstModel.DrawCount, Is.Not.Zero);
        //    Assert.That(firstModel.Date, Is.Not.Empty);
        //}

        [Test]
        public async Task SummarySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new SummaryCriteria
            {
                FromDate = DateTime.Today.AddMonths(-2),
                ToDate = DateTime.Today.AddDays(1),
                ExcludeTest = false,
                ProductId = 6,
                StatusId = 2,
                Username = string.Empty
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<SummaryModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.PlayerCount, Is.Not.Zero);
            Assert.That(firstModel.Date, Is.GreaterThan(DateTime.MinValue));
        }

        [Test]
        public async Task ProductQuerySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new ProductQueryCriteria();

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<ProductEntity>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.ProductName, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.ProductId, Is.Not.Zero);
        }
    }
}