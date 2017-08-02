import angular from "angular";
import moment from "moment";
(function (angular) {
    "use strict";

    var cricketProductId = 50;

    var templateSetting = {
        "Main": {
            mainView: "product",
            product: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "ProductController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/product",
                mainParameters: {},
                getTitleFunction: "getMainTitle"
            }
        },
        "Soccer": {
            mainView: "soccerLiveNonLive",
            soccerLiveNonLive: {
                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
                controller: "SoccerLiveNonLiveController",
                service: "soccerLiveNonLiveService",
                serviceBaseUrl: "api/house-win-loss-by-products/soccer/live-nonlive",
                mainParameters: {},
                getTitleFunction: "getSoccerLiveNonLiveTitle"
            },
            soccerMajorMinor: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SoccerMajorMinorController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/soccer/major-minor",
                mainParameters: {},
                getTitleFunction: "getSoccerMajorMinorTitle"
            },
            soccerBetType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: function (data) {
                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
                    var isSumBetType = isMajor && data.isLive === 2;
                    var isGroupBetType = isMajor && data.isLive === 0;

                    if (isSumBetType) {
                        return "api/house-win-loss-by-products/soccer/sum-bettype";
                    }
                    else if (isGroupBetType) {
                        return "api/house-win-loss-by-products/soccer/group-bettype";
                    }
                    else {
                        return "api/house-win-loss-by-products/soccer/bettype";
                    }
                },
                mainParameters: function (data) {
                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
                    return {
                        isMajor: isMajor
                    };
                },
                getTitleFunction: "getSoccerBetTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportsbookMatchDetailController",
                service: "sportsbookMatchDetailService",
                serviceBaseUrl: function (data) {
                    return data.betType === 10
                        ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail'
                        : 'api/house-win-loss-by-products/sportsbook/match-detail';
                },
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Metric Gaming - Superlive": {
            mainView: "liveNonLive",
            liveNonLive: {
                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
                controller: "MetricGamingLiveNonLiveController",
                service: "metricGamingLiveNonLiveService",
                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/live-none-live",
                mainParameters: {},
                getTitleFunction: "getProductTitleLiveNonLive"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/bet-type",
                mainParameters: {},
                getTitleFunction: "getSportsbookBetTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportsbookMatchDetailController",
                service: "sportsbookMatchDetailService",
                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/match-detail",
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Other Sports": {
            mainView: "liveNonLive",
            liveNonLive: {
                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
                controller: "OtherSportsLiveNonLiveController",
                service: "otherSportsLiveNonLiveService",
                serviceBaseUrl: "api/house-win-loss-by-products/other-sports/live-non-live",
                mainParameters: {},
                getTitleFunction: "getProductTitleLiveNonLive"
            },
            sportType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/other-sports/sport-type",
                mainParameters: {},
                getTitleFunction: "getProductTitleLive"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: function (data) {
                    return data.sportType === cricketProductId
                    ? 'BetTypeNewCricketController'
                    : 'BetTypeController';
                },
                service: "remoteDataService",
                serviceBaseUrl: function (data) {
                    return data.sportType === cricketProductId
                    ? 'api/house-win-loss-by-products/other-sports/new-cricket/bet-type'
                    : 'api/house-win-loss-by-products/other-sports/bet-type';
                },
                mainParameters: {},
                getTitleFunction: "getSportsbookBetTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportsbookMatchDetailController",
                service: "sportsbookMatchDetailService",
                serviceBaseUrl: function (data) {
                    return data.betType === 10
                        ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail'
                        : 'api/house-win-loss-by-products/sportsbook/match-detail';
                },
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Parlay": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "ParlayBetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/parlay/bet-type",
                mainParameters: {},
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/parlay/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Live Casino": {
            mainView: "casinoProduct",
            casinoProduct: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "CasinoProductController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/product",
                mainParameters: { casinoType: 2 },
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/bet-type",
                mainParameters: { casinoType: 2 },
                getTitleFunction: "getCasinoProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/site",
                mainParameters: { casinoType: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Casino": {
            mainView: "casinoProduct",
            casinoProduct: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "CasinoProductController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/product",
                mainParameters: { casinoType: 1 },
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/bet-type",
                mainParameters: { casinoType: 1 },
                getTitleFunction: "getCasinoProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/casino/site",
                mainParameters: { casinoType: 1 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Number Game": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
                controller: "BetTypeLiveNonLiveController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 3 },
                getTitleFunction: "getBetTypeLiveNonLiveTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 3 },
                getTitleFunction: "getSiteTitleLive"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "MatchDetailController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/number-game/match-detail",
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitleLive"
            }
        },
        "Virtual Sports": {
            mainView: "sportType",
            sportType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports/sport-type",
                mainParameters: {},
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports/bet-type",
                mainParameters: {},
                getTitleFunction: "getSportTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "MatchDetailController",
                service: "remoteDataService",
                serviceBaseUrl: function (data) {
                    return data.sportType >= 181 && data.sportType <= 185
                           ? "api/house-win-loss-by-products/virtual-sports/racing-match-detail"
                           : "api/house-win-loss-by-products/virtual-sports/sportsbook-match-detail";
                },
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Bettrade": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/bettrade/bet-type",
                mainParameters: {},
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/bettrade/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Racing": {
            mainView: "sportType",
            sportType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/racing/sport-type",
                mainParameters: {},
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/racing/bet-type",
                mainParameters: {},
                getTitleFunction: "getSportTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "MatchDetailController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/racing/match-detail",
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/racing/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        },
        "Bingo": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 7, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 7, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Keno": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 8, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 8, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Colossus Bets": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 15, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 15, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "NG2": {
            mainView: "sportType",
            sportType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/sport-type",
                mainParameters: { productId: 23 },
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
                controller: "BetTypeLiveNonLiveController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 23 },
                getTitleFunction: "getSportTypeTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 23 },
                getTitleFunction: "getSiteTitleLive"
            }
        },
        "Fishing World": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/fishing-world/bet-type",
                mainParameters: { productId: 24, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/fishing-world/site",
                mainParameters: { productId: 24, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Cash Out": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/bet-type",
                mainParameters: { productId: 25, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/site",
                mainParameters: { productId: 25, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Lottery": {
            mainView: "betType",
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
                mainParameters: { productId: 28, isLive: 2 },
                getTitleFunction: "getProductTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
                mainParameters: { productId: 28, isLive: 2 },
                getTitleFunction: "getSiteTitle"
            }
        },
        "Virtual Sports 2": {
            mainView: "sportType",
            sportType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SportTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/sport-type",
                mainParameters: { productId: 27 },
                getTitleFunction: "getProductTitle"
            },
            betType: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "BetTypeController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/bet-type",
                mainParameters: { productId: 27 },
                getTitleFunction: "getSportTypeTitle"
            },
            matchDetail: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "MatchDetailController",
                service: "remoteDataService",
                serviceBaseUrl:  "api/house-win-loss-by-products/virtual-sports-betradar/match-detail",
                mainParameters: {},
                getTitleFunction: "getMatchDetailTitle"
            },
            site: {
                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
                controller: "SiteController",
                service: "remoteDataService",
                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/site",
                mainParameters: {},
                getTitleFunction: "getSiteTitle"
            }
        }
    };
    angular
        .module("app.houseWinlossApp")
        .constant("templateSetting", templateSetting);
})(angular);