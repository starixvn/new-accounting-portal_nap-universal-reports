using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using UniversalReports.PunterAnalysis.Filter.AvailableDateRange;

namespace UniversalReports.PunterAnalysis.UnitTests.Filter.AvailableDateRange
{
    public class HandlerUnitTests
    {
        public static IEnumerable<DateRange> DateRanges
        {
            get
            {
                yield return new DateRange { MinDate = DateTime.MinValue, MaxDate = DateTime.MaxValue };
                yield return new DateRange { MinDate = DateTime.Today, MaxDate = DateTime.Today };
            }
        }

        [Test]
        [TestCaseSource(typeof(HandlerUnitTests), nameof(DateRanges))]
        public async Task Handle_Always_ReturnsTheValueWhichIsReturnedByRepository(DateRange valueFromRepository)
        {
            // Arrange
            var repository = Substitute.For<IDynamicRepository>();
            repository.GetAsync<DateRange>(Arg.Any<QueryCriteria>()).Returns(valueFromRepository);

            // Act
            var parameter = new HttpParameterJson();
            var handler = new Handler(repository);

            var dateRange = await handler.Handle(parameter, new CancellationToken());

            Assert.That(dateRange, IsDeeplyEqual.To(valueFromRepository));
        }
    }
}