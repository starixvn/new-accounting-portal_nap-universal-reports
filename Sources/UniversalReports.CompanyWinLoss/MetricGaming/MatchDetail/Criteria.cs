using System.ComponentModel.DataAnnotations;
using UniversalReports.CompanyWinLoss.Common;
using UniversalReports.CompanyWinLoss.Common.Criteria;

namespace UniversalReports.CompanyWinLoss.MetricGaming.MatchDetail
{
    public class Criteria : WinLossCriteria
    {
        [Required]
        public int BetType { get; set; }

        public int IsLive { get; set; } = Constants.LiveDefault;

        public override string GetSettingKey()
        {
            return $"CompanyWinLoss-MetricGaming-MatchDetail-{Source}";
        }
    }
}