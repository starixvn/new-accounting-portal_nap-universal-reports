using AutoMapper;

namespace UniversalReports.CN88WinLoss
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeCN88WinLoss(this IProfileExpression cfg)
        {
            cfg.CreateMap<Common.MatchDetail.RawWinLoss, Common.MatchDetail.WinLoss>();
            cfg.CreateMap<Common.Models.WinLossRaw, Common.Models.WinLoss>();
            cfg.CreateMap<NumberGame.MatchDetail.ExcelQueryModel, NumberGame.MatchDetail.Criteria>();
            cfg.CreateMap<NumberGame.MatchDetail.QueryModel, NumberGame.MatchDetail.Criteria>();
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
            cfg.CreateMap<Products.ExcelQueryModel, Products.Criteria>();
            cfg.CreateMap<Products.QueryModel, Products.Criteria>();
            cfg.CreateMap<Soccer.BetType.ExcelQueryModel, Soccer.BetType.BetTypeCriteria>();
            cfg.CreateMap<Soccer.BetType.QueryModel, Soccer.BetType.BetTypeCriteria>();
            cfg.CreateMap<Soccer.BetType.ExcelQueryModel, Soccer.BetType.BetBuilderBetTypeCriteria>();
            cfg.CreateMap<Soccer.BetType.QueryModel, Soccer.BetType.BetBuilderBetTypeCriteria>();
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

            cfg.CreateMap<VirtualSports.RacingDetail.ExcelQueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.RacingDetail.QueryModel, VirtualSports.RacingDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.ExcelQueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSports.SportsbookDetail.QueryModel, VirtualSports.SportsbookDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.ExcelQueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
            cfg.CreateMap<VirtualSportsBetradar.MatchDetail.QueryModel, VirtualSportsBetradar.MatchDetail.Criteria>();
        }
    }
}