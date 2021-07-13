using Fanex.Data.Repository;
using NSubstitute;
using NUnit.CompareNetObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalReports.SMAWinLoss.Summary;

namespace UniversalReports.SMAWinLoss.UnitTests.Summary
{
    [Category("SMAWinLoss")]
    public class WinLossServiceTests
    {
        [Test]
        public async Task GetSMAWinLoss_WithSubtituteReposity_ReturnRightModel()
        {
            // Arrange
            var fakeData = ValueTuple.Create<IEnumerable<WinLossEntity>, IEnumerable<WinLossEntity>, IEnumerable<int>>(
                new List<WinLossEntity>
                {
                    new WinLossEntity {
                        RptDate = new DateTime(2020, 1, 1),
                        CustId = 1,
                        Username ="Username 1",
                        VirtualRate = string.Empty, Currency ="US$",
                        BetCount = 2,
                        RealTurnover = 20m,
                        RealIncome = 10m,
                        LevelTurnover = 10m,
                        MemberTurnover = 10m
                    },
                   new WinLossEntity {
                        RptDate = new DateTime(2020, 3, 1),
                        CustId = 1,
                        Username ="Username 1",
                        VirtualRate = string.Empty, Currency ="US$",
                        BetCount = 2,
                        RealTurnover = 20m,
                        RealIncome = 10m,
                        LevelTurnover = 10m,
                        MemberTurnover = 10m
                    }
                },
                new List<WinLossEntity>
                {
                    new WinLossEntity {
                        RptDate = new DateTime(2020, 1, 1),
                        CustId = -1,
                        Username ="Total",
                        VirtualRate = string.Empty, Currency ="RM",
                        BetCount = 2,
                        RealTurnover = 20m,
                        RealIncome = 10m,
                        LevelTurnover = 10m,
                        MemberTurnover = 10m
                    },
                   new WinLossEntity {
                        RptDate = new DateTime(2020, 3, 1),
                        CustId = -1,
                        Username ="Total",
                        VirtualRate = string.Empty, Currency ="RM",
                        BetCount = 2,
                        RealTurnover = 20m,
                        RealIncome = 10m,
                        LevelTurnover = 10m,
                        MemberTurnover = 10m
                    }
                },
                new List<int> { 1 });

            const string InputFileName = "SMAWinLoss-Summary-expected.json";

            var expectedWinLosses = TestDataLoader.Load<WinLossModel>(InputFileName);

            var repository = Substitute.For<IDynamicRepository>();
            repository.FetchMultipleAsync<WinLossEntity, WinLossEntity, int>(Arg.Compat.Any<WinLossCriteria>()).Returns(fakeData);

            var service = new WinLossServiceImp(repository);

            // Act
            var model = await service.GetSMAWinLoss(new WinLossHttpParameter { Year = 2020 });

            // Assert
            Assert.That(model, IsDeeplyEqual.To(expectedWinLosses));
        }
    }
}