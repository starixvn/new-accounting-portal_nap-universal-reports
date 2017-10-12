using System.Collections.Generic;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedUsername
{
    [TestFixture]
    public class UpdatedUsernameServiceTests
    {
        [Test]
        public void GetUpdatedUsernameItem_WithItemRawData_ReturnRightUpdatedUsernameModel()
        {
            // Arrange
            var updatedUsernameEntity = TestDataLoader.Load<UpdatedUsernameEntity>("UpdatedUsername/FakeUpdatedUsernameEntityRawData.json");
            var expectedUpdatedUsernameModel = TestDataLoader.Load<UpdatedUsernameModel>("UpdatedUsername/ExpectedUsernameModel.json");

            var repository = Substitute.For<IDynamicRepository>();

            var logParseService = Substitute.For<LogParseService>();
            logParseService.GetUsernameLog(Arg.Any<string>()).Returns(new UsernameLogModel { FromName = "From Username", ToName = "To Username" });

            var service = new UpdatedUsernameServiceImp(repository, logParseService);

            // Act
            var model = service.GetUpdatedUsernameItem(updatedUsernameEntity);

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedUpdatedUsernameModel));
        }

        [Test]
        public async Task GetUpdatedUsername_WithAnyMessage_ReturnRightUpdatedUsernameList()
        {
            // Arrange
            var fakeRawData = TestDataLoader.Load<IEnumerable<UpdatedUsernameEntity>>("UpdatedUsername/FakeUpdatedUsernameRawData.json");
            var expectedUpdatedUsernameList = TestDataLoader.Load<List<UpdatedUsernameModel>>("UpdatedUsername/ExpectedUsernameList.json");

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<UpdatedUsernameEntity>(Arg.Any<Criteria>()).Returns(fakeRawData);

            var logParseService = new LogParseServiceImp();

            var service = new UpdatedUsernameServiceImp(repository, logParseService);

            // Act
            var model = await service.GetUpdatedUsername(new Message());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedUpdatedUsernameList));
        }
    }
}