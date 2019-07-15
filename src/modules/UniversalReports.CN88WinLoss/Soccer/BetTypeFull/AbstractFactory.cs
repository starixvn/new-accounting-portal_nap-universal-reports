using UniversalReports.CN88WinLoss.Common.BasicWinLoss;
using UniversalReports.CN88WinLoss.Common.ColumnDecorators;
using UniversalReports.CN88WinLoss.Configuration;
using UniversalReports.CN88WinLoss.Soccer.GroupBetType;
using UniversalReports.CN88WinLoss.Soccer.SumBetType;

namespace UniversalReports.CN88WinLoss.Soccer.BetTypeFull
{
    public interface AbstractFactory
    {
        GridOptionFactory CreateGridOptionFactory(bool isMajor, int isLive);
    }

    public class AbstractFactoryImp : AbstractFactory
    {
        private readonly SumBetTypeWinLossService sumBetTypeWinLossService;

        private readonly SumBetTypeGridOptionsBuilder sumBetTypeGridOptionsBuilder;

        private readonly GroupBetTypeWinLossService groupBetTypeWinLossService;

        private readonly GroupBetTypeGridOptionsBuilder groupBetTypeGridOptionsBuilder;

        private readonly BasicWinLossService basicWinLossService;

        private readonly BasicGridOptionsBuilder basicGridOptionsBuilder;

        private readonly GridOptionColumnDecorator decorator;

        public AbstractFactoryImp(
            SumBetTypeWinLossService sumBetTypeWinLossService,
            SumBetTypeGridOptionsBuilder sumBetTypeGridOptionsBuilder,
            GroupBetTypeWinLossService groupBetTypeWinLossService,
            GroupBetTypeGridOptionsBuilder groupBetTypeGridOptionsBuilder,
            BasicWinLossService basicWinLossService,
            BasicGridOptionsBuilder basicGridOptionsBuilder,
            GridOptionColumnDecoratorFull decorator)
        {
            this.sumBetTypeWinLossService = sumBetTypeWinLossService;
            this.sumBetTypeGridOptionsBuilder = sumBetTypeGridOptionsBuilder;
            this.groupBetTypeWinLossService = groupBetTypeWinLossService;
            this.groupBetTypeGridOptionsBuilder = groupBetTypeGridOptionsBuilder;
            this.basicWinLossService = basicWinLossService;
            this.basicGridOptionsBuilder = basicGridOptionsBuilder;
            this.decorator = decorator;
        }

        public GridOptionFactory CreateGridOptionFactory(bool isMajor, int isLive)
        {
            if (isMajor && isLive == Constants.LiveDefault)
            {
                return new GridOptionFactorySumBetType(sumBetTypeWinLossService, sumBetTypeGridOptionsBuilder, decorator);
            }

            if (isMajor && isLive == 0)
            {
                return new GridOptionFactoryGroupBetType(groupBetTypeWinLossService, groupBetTypeGridOptionsBuilder, decorator);
            }
            else
            {
                return new GridOptionFactoryBetType(basicWinLossService, basicGridOptionsBuilder, decorator);
            }
        }
    }
}
