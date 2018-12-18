using System.Collections.Generic;
using AutoMapper;
using UniversalReports.HouseWinLoss.Common.Criteria;

namespace UniversalReports.HouseWinLoss
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeHouseWinLoss(this IProfileExpression cfg)
        {
            cfg.CreateMap<Bullfighting.MatchDetail.QueryModel, Bullfighting.MatchDetail.Criteria>();
            cfg.CreateMap<Common.MatchDetail.RawWinLoss, Common.MatchDetail.WinLoss>();
            cfg.CreateMap<Common.Models.WinLossRaw, Common.Models.WinLoss>();
            cfg.CreateMap<MetricGaming.LiveNonLive.ExcelQueryModel, MetricGamingBetTypeCriteria>();
            cfg.CreateMap<MetricGaming.LiveNonLive.QueryModel, MetricGaming.LiveNonLive.Criteria>();
            cfg.CreateMap<MetricGaming.MatchDetail.ExcelQueryModel, MetricGaming.MatchDetail.Criteria>();
            cfg.CreateMap<MetricGaming.MatchDetail.QueryModel, MetricGaming.MatchDetail.Criteria>();
            cfg.CreateMap<NumberGame.MatchDetail.ExcelQueryModel, NumberGame.MatchDetail.Criteria>();
            cfg.CreateMap<NumberGame.MatchDetail.QueryModel, NumberGame.MatchDetail.Criteria>();
            cfg.CreateMap<OtherSports.LiveNonLive.ExcelQueryModel, OtherSportsSportTypeCriteria>();
            cfg.CreateMap<OtherSports.LiveNonLive.QueryModel, OtherSports.LiveNonLive.Criteria>();
            cfg.CreateMap<OtherSports.NewCricket.ExcelQueryModel, OtherSports.NewCricket.Criteria>();
            cfg.CreateMap<OtherSports.NewCricket.QueryModel, OtherSports.NewCricket.Criteria>();
            cfg.CreateMap<Parlay.Site.ExcelQueryModel, Parlay.Site.Criteria>();
            cfg.CreateMap<Parlay.Site.QueryModel, Parlay.Site.Criteria>();
            cfg.CreateMap<Products.ExcelQueryModel, Products.Criteria>();
            cfg.CreateMap<Products.QueryModel, Products.Criteria>();
            cfg.CreateMap<Racing.MatchDetail.ExcelQueryModel, Racing.MatchDetail.Criteria>();
            cfg.CreateMap<Racing.MatchDetail.QueryModel, Racing.MatchDetail.Criteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, SoccerBetTypeCriteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.GroupBetType.ExcelQueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.GroupBetType.QueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.LiveNonLive.ExcelQueryModel, SoccerMajorMinorCriteria>();
            cfg.CreateMap<Soccer.LiveNonLive.QueryModel, Soccer.LiveNonLive.Criteria>();
            cfg.CreateMap<Soccer.SumBetType.ExcelQueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Soccer.SumBetType.QueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Sportsbook.MatchDetail.ExcelQueryModel, Sportsbook.MatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.MatchDetail.QueryModel, Sportsbook.MatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.OutrightMatchDetail.ExcelQueryModel, Sportsbook.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.OutrightMatchDetail.QueryModel, Sportsbook.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<NG2.BetType.ExcelLiveNonLiveQueryModel, UniversalBetTypeCriteria>();
            cfg.CreateMap<VirtualSports.RacingDetail.ExcelQueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.RacingDetail.QueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.ExcelQueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.QueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.ExcelQueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.QueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.BetType.QueryModel, SoccerMinor2hBetTypeCriteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.BetType.ExcelQueryModel, SoccerMinor2hBetTypeCriteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.MatchDetail.QueryModel, DailyWinLoss2hSoccerMinor.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.MatchDetail.ExcelQueryModel, DailyWinLoss2hSoccerMinor.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.OutrightMatchDetail.QueryModel, DailyWinLoss2hSoccerMinor.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.OutrightMatchDetail.ExcelQueryModel, DailyWinLoss2hSoccerMinor.OutrightMatchDetail.Criteria>();
        }
    }
}
