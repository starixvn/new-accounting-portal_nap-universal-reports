using Fanex.Data.Repository;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniversalReports.PlayForFun.Detail.Model;
using UniversalReports.PlayForFun.Filter.Product;
using UniversalReports.PlayForFun.Summary.Model;
using DetailCriteria = UniversalReports.PlayForFun.Detail.Model.Criteria;
using ProductQueryCriteria = UniversalReports.PlayForFun.Filter.Product.Criteria;
using SummaryCriteria = UniversalReports.PlayForFun.Summary.Model.Criteria;

namespace UniversalReports.PlayForFun.DatabaseTests
{
    public class DynamicRepositoryTests
    {
        [Test]
        public async Task SummarySp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new SummaryCriteria
            {
                FromDate = DateTime.Today.AddYears(-2),
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
        public async Task DetailSp_Test_ColumnIsMapCorrectly()
        {
            // Arrange
            var criteria = new DetailCriteria
            {
                FromDate = DateTime.Today.AddYears(-2),
                ToDate = DateTime.Today.AddDays(1),
                ExcludeTest = false,
                ProductId = 6,
                StatusId = 2,
                Username = string.Empty
            };

            // Act
            var repository = new DynamicRepository();
            var models = await repository.FetchAsync<DetailModel>(criteria);
            var firstModel = models.First();

            // Assert
            Assert.That(firstModel.BetCount, Is.Not.Zero);
            Assert.That(firstModel.WinLoss, Is.Not.Zero);
            Assert.That(firstModel.Turnover, Is.Not.Zero);
            Assert.That(firstModel.Date, Is.GreaterThan(DateTime.MinValue));
            Assert.That(firstModel.Currency, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.Site, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.Username, Is.Not.Null.And.Not.Empty);
            Assert.That(firstModel.CustId, Is.Not.Zero);
            Assert.That(firstModel.Product, Is.Not.Null.And.Not.Empty);
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