using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.PunterAnalysis.Filter.AvailableDateRange;

namespace UniversalReports.PunterAnalysis.UnitTests.AvailableDateRange
{
    public class HandlerUnitTests
    {
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

            var dateRange = await handler.Handle(parameter);

            Assert.That(dateRange, IsDeeplyEqual.To(valueFromRepository));
        }

        public static IEnumerable<DateRange> DateRanges
        {
            get
            {
                yield return new DateRange { MinDate = DateTime.MinValue, MaxDate = DateTime.MaxValue };
                yield return new DateRange { MinDate = DateTime.Today, MaxDate = DateTime.Today };
            }
        }
    }
}