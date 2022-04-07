using AutoMapper;
using UniversalReports.HouseWinLoss.Common.Criteria;
using UniversalReports.HouseWinLoss.SimpleGrid.SimpleCriteria;

namespace UniversalReports.HouseWinLoss
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeHouseWinLoss(this IProfileExpression cfg)
        {
            cfg.CreateMap<Bullfighting.MatchDetail.QueryModel, Bullfighting.MatchDetail.Criteria>();
            cfg.CreateMap<Common.MatchDetail.RawWinLoss, Common.MatchDetail.WinLoss>();
            cfg.CreateMap<Common.Models.WinLossRaw, Common.Models.WinLoss>();
            cfg.CreateMap<MetricGaming.BetType.ExcelQueryModel, MetricGaming.BetType.Criteria>();
            cfg.CreateMap<MetricGaming.BetType.QueryModel, MetricGaming.BetType.Criteria>();
            cfg.CreateMap<MetricGaming.LiveNonLive.ExcelQueryModel, MetricGaming.BetType.Criteria>();
            cfg.CreateMap<MetricGaming.LiveNonLive.QueryModel, MetricGaming.LiveNonLive.Criteria>();
            cfg.CreateMap<MetricGaming.MatchDetail.ExcelQueryModel, MetricGaming.MatchDetail.Criteria>();
            cfg.CreateMap<MetricGaming.MatchDetail.QueryModel, MetricGaming.MatchDetail.Criteria>();
            cfg.CreateMap<MetricGaming.Site.ExcelQueryModel, MetricGaming.Site.Criteria>();
            cfg.CreateMap<MetricGaming.Site.QueryModel, MetricGaming.Site.Criteria>();
            cfg.CreateMap<NumberGame.MatchDetail.ExcelQueryModel, NumberGameDrilldownCriteria>();
            cfg.CreateMap<NumberGame.MatchDetail.QueryModel, NumberGameDrilldownCriteria>();
            cfg.CreateMap<OtherSports.BetType.ExcelQueryModel, OtherSports.BetType.Criteria>();
            cfg.CreateMap<OtherSports.BetType.QueryModel, OtherSports.BetType.Criteria>();
            cfg.CreateMap<OtherSports.LiveNonLive.ExcelQueryModel, OtherSports.SportType.Criteria>();
            cfg.CreateMap<OtherSports.LiveNonLive.QueryModel, OtherSports.LiveNonLive.Criteria>();
            cfg.CreateMap<OtherSports.NewCricket.ExcelQueryModel, OtherSports.NewCricket.Criteria>();
            cfg.CreateMap<OtherSports.NewCricket.QueryModel, OtherSports.NewCricket.Criteria>();
            cfg.CreateMap<OtherSports.SportType.ExcelQueryModel, OtherSports.SportType.Criteria>();
            cfg.CreateMap<OtherSports.SportType.QueryModel, OtherSports.SportType.Criteria>();
            cfg.CreateMap<Parlay.BetType.ExcelQueryModel, Parlay.BetType.Criteria>();
            cfg.CreateMap<Parlay.BetType.QueryModel, Parlay.BetType.Criteria>();
            cfg.CreateMap<Parlay.Site.ExcelQueryModel, Parlay.Site.Criteria>();
            cfg.CreateMap<Parlay.Site.QueryModel, Parlay.Site.Criteria>();
            cfg.CreateMap<Products.ExcelQueryModel, Products.Criteria>();
            cfg.CreateMap<Products.QueryModel, Products.Criteria>();
            cfg.CreateMap<Racing.MatchDetail.ExcelQueryModel, Racing.MatchDetail.Criteria>();
            cfg.CreateMap<Racing.MatchDetail.QueryModel, Racing.MatchDetail.Criteria>();
            cfg.CreateMap<Soccer.BetType.ExcelQueryModel, Soccer.BetType.BetTypeCriteria>();
            cfg.CreateMap<Soccer.BetType.QueryModel, Soccer.BetType.BetTypeCriteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, Soccer.BetType.BetTypeCriteria>();
            cfg.CreateMap<Soccer.BetTypeFull.ExcelQueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.GroupBetType.ExcelQueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.GroupBetType.QueryModel, Soccer.GroupBetType.GroupBetTypeCriteria>();
            cfg.CreateMap<Soccer.LiveNonLive.ExcelQueryModel, Soccer.MajorMinor.Criteria>();
            cfg.CreateMap<Soccer.LiveNonLive.QueryModel, Soccer.LiveNonLive.Criteria>();
            cfg.CreateMap<Soccer.MajorMinor.ExcelQueryModel, Soccer.MajorMinor.Criteria>();
            cfg.CreateMap<Soccer.MajorMinor.QueryModel, Soccer.MajorMinor.Criteria>();
            cfg.CreateMap<Soccer.SumBetType.ExcelQueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Soccer.SumBetType.QueryModel, Soccer.SumBetType.SumBetTypeCriteria>();
            cfg.CreateMap<Sportsbook.MatchDetail.ExcelQueryModel, Sportsbook.MatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.MatchDetail.QueryModel, Sportsbook.MatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.OutrightMatchDetail.ExcelQueryModel, Sportsbook.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.OutrightMatchDetail.QueryModel, Sportsbook.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<Sportsbook.Site.ExcelQueryModel, Sportsbook.Site.Criteria>();
            cfg.CreateMap<Sportsbook.Site.QueryModel, Sportsbook.Site.Criteria>();

            cfg.CreateMap<NG2.BetType.ExcelLiveNonLiveQueryModel, UniversalBetTypeCriteria>();
            cfg.CreateMap<VirtualSports.RacingDetail.ExcelQueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.RacingDetail.QueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.ExcelQueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.QueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.ExcelQueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.QueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.SportType.QueryModel, DailyWinLoss2hSoccerMinor.SportType.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.SportType.ExcelQueryModel, DailyWinLoss2hSoccerMinor.SportType.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.BetType.QueryModel, DailyWinLoss2hSoccerMinor.BetType.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.BetType.ExcelQueryModel, DailyWinLoss2hSoccerMinor.BetType.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.MatchDetail.QueryModel, DailyWinLoss2hSoccerMinor.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.MatchDetail.ExcelQueryModel, DailyWinLoss2hSoccerMinor.MatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.OutrightMatchDetail.QueryModel, DailyWinLoss2hSoccerMinor.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.OutrightMatchDetail.ExcelQueryModel, DailyWinLoss2hSoccerMinor.OutrightMatchDetail.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.Site.QueryModel, DailyWinLoss2hSoccerMinor.Site.Criteria>();
            cfg.CreateMap<DailyWinLoss2hSoccerMinor.Site.ExcelQueryModel, DailyWinLoss2hSoccerMinor.Site.Criteria>();

            cfg.CreateMap<CashOut.LiveNonLive.ExcelQueryModel, CashOut.LiveNonLive.Criteria>();
            cfg.CreateMap<CashOut.LiveNonLive.QueryModel, CashOut.LiveNonLive.Criteria>();
            cfg.CreateMap<CashOut.MatchDetail.ExcelQueryModel, CashOut.MatchDetail.Criteria>();
            cfg.CreateMap<CashOut.MatchDetail.QueryModel, CashOut.MatchDetail.Criteria>();
            cfg.CreateMap<BetBuilder.SportType.ExcelQueryModel, BetBuilder.SportType.Criteria>();
            cfg.CreateMap<BetBuilder.SportType.QueryModel, BetBuilder.SportType.Criteria>();
            cfg.CreateMap<BetBuilder.BetType.ExcelQueryModel, BetBuilder.BetType.BetBuilderBetTypeCriteria>();
            cfg.CreateMap<BetBuilder.BetType.QueryModel, BetBuilder.BetType.BetBuilderBetTypeCriteria>();
        }
    }
}