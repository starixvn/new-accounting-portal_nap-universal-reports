using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.UpdatedUsernameAndCredit.UpdatedCredit;

namespace UniversalReports.UpdatedUsernameAndCredit.UnitTests.UpdatedCredit
{
    [TestFixture]
    public class UpdatedCreditServiceTests
    {
        [Test]
        public async Task GetUpdatedCredit_WithAnyMessage_ReturnRightCreditList()
        {
            // Arrange
            var fakeRawDataFileName = "UpdatedCredit/FakeRawData.json";
            var expectedCreditListDataFileName = "UpdatedCredit/ExpectedUpdatedCreditList.json";

            var fakeUpdatedCreditRawData = TestDataLoader.Load<IEnumerable<UpdatedCreditEntity>>(fakeRawDataFileName);
            var expectedUpdatedCreditModel = TestDataLoader.Load<IEnumerable<UpdatedCreditModel>>(expectedCreditListDataFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<UpdatedCreditEntity>(Arg.Any<Criteria>()).Returns(fakeUpdatedCreditRawData);

            var service = new UpdatedCreditServiceImp(repository);

            // Act
            var model = await service.GetUpdatedCredit(new Message());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedUpdatedCreditModel));
        }
    }
}
