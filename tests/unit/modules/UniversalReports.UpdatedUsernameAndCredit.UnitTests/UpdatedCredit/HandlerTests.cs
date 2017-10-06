using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;
using UniversalReports.UpdatedUsernameCredit.UpdatedCredit;

namespace UniversalReports.UpdatedUsernameCredit.UnitTests.UpdatedCredit
{
    [TestFixture]
    public class HandlerTests
    {
        private readonly Fixture fixture = new Fixture();

        [Test]
        public async Task Handle_WithAnyMessage_ReturnRightUpdatedCreditList()
        {
            // Arrange
            var updatedCreditModel = fixture.Create<IEnumerable<UpdatedCreditModel>>();

            var service = Substitute.For<UpdatedCreditService>();
            service.GetUpdatedCredit(Arg.Any<Message>()).Returns(updatedCreditModel);

            var handler = new Handler(service);

            // Act
            var model = await handler.Handle(new Message());

            // Assert
            Assert.That(model, IsDeeplyEqual.To(updatedCreditModel));
        }
    }
}