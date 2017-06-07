using AutoMapper;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Web.Session;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.UsernameSuggestion;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.UsernameSuggestion
{
    public class HandlerUnitTests
    {
        public static IEnumerable<IEnumerable<string>> UsernameTestCases
        {
            get
            {
                yield return new List<string>();
                yield return new List<string> { "Any Username" };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(UsernameTestCases))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(IEnumerable<string> valueFromRepository)
        {
            // Arrange
            const int CurrentUserId = 1;
            var currentSession = Substitute.For<ICurrentSession>();
            currentSession.UserId.Returns(CurrentUserId);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchAsync<string>(Arg.Is<QueryCriteria>(x => x.CustId == CurrentUserId && x.RoleId == 1 && x.Username == "Any Username"))
                .Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson { RoleId = 1, Username = "Any Username" };
            var handler = new Handler(currentSession, repository);

            var usernames = await handler.Handle(parameter);

            Assert.That(usernames, IsDeeplyEqual.To(valueFromRepository));
        }
    }
}