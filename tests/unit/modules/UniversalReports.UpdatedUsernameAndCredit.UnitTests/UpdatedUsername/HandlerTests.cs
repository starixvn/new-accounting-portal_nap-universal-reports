using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.UpdatedUsernameCredit.UpdatedUsername;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedUsername
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightUpdatedUsernameList()
        {
            // Arrange
            var updatedUsernameModel = fixture.Create<List<UpdatedUsernameModel>>();

            var service = Substitute.For<UpdatedUsernameService>();
            service.GetUpdatedUsername(Arg.Any<Message>()).Returns(updatedUsernameModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new Message());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(updatedUsernameModel));
        }
    }
}