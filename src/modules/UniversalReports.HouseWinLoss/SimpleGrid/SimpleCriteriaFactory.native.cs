using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;
using UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria;

namespace UniversalReports.HouseWinLoss.SimpleGrid
{
    public interface SimpleCriteriaFactory
    {
        WinLossCriteria CreateCriteria(Dictionary<string, object> queryModel);

        GridDecorationModel CreateGridDecorationModel(Dictionary<string, object> queryModel);
    }

    public class SimpleCriteriaFactoryImp : SimpleCriteriaFactory
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

        private static readonly Dictionary<string, Type> CriteriaTypes = new Dictionary<string, Type>
        {
            { "bettrade-bet-type", typeof(BetTradeBetTypeCriteria)},
            { "bettrade-site", typeof(BetTradeSiteCriteria)},
            { "cash-out-site", typeof(CashOutSiteCriteria)},
            { "casino-bet-type", typeof(CasinoBetTypeCriteria)},
            { "casino-product", typeof(CasinoProductCriteria)},
            { "casino-site", typeof(CasinoSiteCriteria)},
            { "colossusbet-bet-type", typeof(ColossusBetTypeCriteria)},
            { "colossusbet-site", typeof(ColossusSiteCriteria)},
            { "fishing-world-bet-type", typeof(FishingWorldBetTypeCriteria)},
            { "fishing-world-site", typeof(FishingWorldSiteCriteria)},
            { "number-game-league", typeof(NumberGameLeagueCriteria)},
            { "number-game-bet-type", typeof(NumberGameBetTypeCriteria)},
            { "number-game-site", typeof(NumberGameSiteCriteria)},
            { "poker-games-bet-type", typeof(PokerGamesBetTypeCriteria)},
            { "poker-games-site", typeof(PokerGameSiteCriteria)},
            { "racing-bet-type", typeof(RacingBetTypeCriteria)},
            { "racing-site", typeof(RacingSiteCriteria)},
            { "racing-sport-type", typeof(RacingSportTypeCriteria)},
            { "universal-bet-type", typeof(UniversalBetTypeCriteria)},
            { "universal-site", typeof(UniversalSiteCriteria)},
            { "universal-sport-type", typeof(UniversalSportTypeCriteria)},
            { "virtual-sports-betradar-bet-type", typeof(VirtualSportsBetradarBetTypeCriteria)},
            { "virtual-sports-betradar-site", typeof(VirtualSportsBetradarSiteCriteria)},
            { "virtual-sports-betradar-sport-type", typeof(VirtualSportsBetradarSportTypeCriteria)},
            { "virtual-sports-bet-type", typeof(VirtualSportsBetTypeCriteria)},
            { "virtual-sports-site", typeof(VirtualSportsSiteCriteria)},
            { "virtual-sports-sport-type", typeof(VirtualSportsSportTypeCriteria)},
            { "non-sports-rng-sport-type", typeof(NonSportsRNGSportTypeCriteria)},
            { "non-sports-rng-bet-type", typeof(NonSportsRNGBetTypeCriteria)}
        };

        public WinLossCriteria CreateCriteria(Dictionary<string, object> queryModel)
        {
            var criteriaType = queryModel["type"].ToString();

            if (!CriteriaTypes.ContainsKey(criteriaType))
            {
                throw new ArgumentException("queryModel[\"type\"]");
            }

            var targetType = CriteriaTypes[criteriaType];
            var criteria = serializer.Deserialize(serializer.Serialize(queryModel), targetType);

            return (WinLossCriteria)criteria;
        }

        public GridDecorationModel CreateGridDecorationModel(Dictionary<string, object> queryModel)
        {
            return serializer.Deserialize<GridDecorationModel>(serializer.Serialize(queryModel));
        }
    }
}