using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss.PokerGames.BetType
{
    public class Criteria : WinLossCriteria
    {
        public int ProductId { get; set; }

        public int SportType { get; set; }

        public int IsLive { get; set; } = 2;

        public override string GetSettingKey() => $"HouseWinLoss-PokerGames-BetType-{Source}";

        public Criteria Clone()
        {
            return new Criteria
            {
                ProductId = ProductId,
                SportType = SportType,
                IsLive = IsLive,
                StartDate = StartDate,
                EndDate = EndDate,
                NormalMode = NormalMode,
                Source = Source
            };
        }
    }
}