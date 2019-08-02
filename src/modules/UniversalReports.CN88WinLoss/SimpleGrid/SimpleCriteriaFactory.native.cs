using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using UniversalReports.CN88WinLoss.Common.Criteria;
using UniversalReports.CN88WinLoss.Common.Models;
using UniversalReports.CN88WinLoss.SimpleGrid.SimpleCriteria;

namespace UniversalReports.CN88WinLoss.SimpleGrid
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
            { "number-game-league", typeof(NumberGameLeagueCriteria)},
            { "number-game-bet-type", typeof(NumberGameBetTypeCriteria)},
            { "number-game-site", typeof(NumberGameSiteCriteria)},
            { "universal-bet-type", typeof(UniversalBetTypeCriteria)},
            { "universal-site", typeof(UniversalSiteCriteria)},
            { "universal-sport-type", typeof(UniversalSportTypeCriteria)},
            { "virtual-sports-betradar-bet-type", typeof(VirtualSportsBetradarBetTypeCriteria)},
            { "virtual-sports-betradar-site", typeof(VirtualSportsBetradarSiteCriteria)},
            { "virtual-sports-betradar-sport-type", typeof(VirtualSportsBetradarSportTypeCriteria)},
            { "virtual-sports-bet-type", typeof(VirtualSportsBetTypeCriteria)},
            { "virtual-sports-site", typeof(VirtualSportsSiteCriteria)},
            { "virtual-sports-sport-type", typeof(VirtualSportsSportTypeCriteria)}
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