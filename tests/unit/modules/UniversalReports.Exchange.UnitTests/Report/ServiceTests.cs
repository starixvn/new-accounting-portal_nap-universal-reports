using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using Linq.DynamicSum;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using AutoFixture;
using UniversalReports.Exchange.Report;

namespace UniversalReports.Exchange.UnitTests.Report
{
    [TestFixture]
    public class ServiceTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Query_RepositoryReturnEmpty_ReturnRightSummaryEntity()
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<ExchangeEntity>(Arg.Any<Criteria>()).Returns(new List<ExchangeEntity>());

            var exchangeModel = CreateEmptyModelBaseWithTypeModel();

            var service = new ServiceImp(repository);

            // Act
            var model = await service.Query(Arg.Any<HttpParameterJson>());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(exchangeModel));
        }


        private SummaryEntity<ExchangeEntity> CreateEmptyModelBaseWithTypeModel()
        {
            return new SummaryEntity<ExchangeEntity>
            {
                Entities = new List<ExchangeEntity>(),
                Total = new ExchangeEntity()
            };
        }

        [Test]
        public async Task Query_RepositoryReturnsNonEmptySummaryModelList_ReturnsNonEmptyModelBaseWithSummaryModel()
        {
            // Arrange
            var nonEmptySummaryModelList = CreateNonEmptySummaryModelList();
            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<ExchangeEntity>(Arg.Any<Criteria>()).Returns(nonEmptySummaryModelList);

            var service = new ServiceImp(repository);

            // Act
            var modelBase = await service.Query(Arg.Any<HttpParameterJson>());

            // Assert
            var expected = CreateNonEmptyModelBaseWithSummaryModel();
            Assert.That(modelBase, IsDeeplyEqual.To(expected));
        }

        private List<ExchangeEntity> CreateNonEmptySummaryModelList()
        {
            return new List<ExchangeEntity>
            {
                CreateSummaryModel()
            };
        }

        private ExchangeEntity CreateSummaryModel()
        {
            return new ExchangeEntity
            {
                LicenseeName = "Any name",
                MemberCount = 1,
                BetCount = 1,
                TurnOver = 20,
                MemberWinLoss = 2,
                MemberCommission = 1,
                MemberTotal = 3,
                LicenseeWinLoss = 5,
                LicenseeCommission = 1,
                LicenseeTotal = 6,
                CompanyCommission = 10,
                CompanyWinLoss = 1,
                PayToSupplier = 1,
                CompanyNetIncome = 12
            };
        }

        private SummaryEntity<ExchangeEntity> CreateNonEmptyModelBaseWithSummaryModel()
        {
            return new SummaryEntity<ExchangeEntity>
            {
                Entities = CreateNonEmptySummaryModelList(),
                Total = CreateSummaryModel()
            };
        }
    }
}
