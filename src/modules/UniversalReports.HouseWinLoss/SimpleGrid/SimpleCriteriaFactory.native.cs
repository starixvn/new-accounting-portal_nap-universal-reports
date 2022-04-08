using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.Common.Models;

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
            { "universal-second-level", typeof(UniversalSecondLevelCriteria)},
            { "number-game-drill-down", typeof(NumberGameDrilldownCriteria)},
            { "universal-thirdparty-bettype", typeof(UniversalThirdPartyBetTypeCriteria)},
            { "universal-thirdparty-site", typeof(UniversalThirdPartySiteCriteria)},
            { "universal-thirdparty-matchdetail", typeof(UniversalThirdPartyMatchDetailCriteria)}
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