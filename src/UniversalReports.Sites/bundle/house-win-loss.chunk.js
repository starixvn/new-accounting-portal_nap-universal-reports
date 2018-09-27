webpackJsonp([3],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(170);
	__webpack_require__(171);
	__webpack_require__(202);
	__webpack_require__(173);
	__webpack_require__(174);
	__webpack_require__(203);
	__webpack_require__(204);
	__webpack_require__(205);
	__webpack_require__(206);
	__webpack_require__(182);
	__webpack_require__(185);
	__webpack_require__(186);
	__webpack_require__(187);
	__webpack_require__(188);
	__webpack_require__(189);
	__webpack_require__(190);
	__webpack_require__(183);
	__webpack_require__(184);
	__webpack_require__(175);
	__webpack_require__(176);
	__webpack_require__(177);
	__webpack_require__(191);
	__webpack_require__(192);
	__webpack_require__(193);
	__webpack_require__(194);
	__webpack_require__(195);
	__webpack_require__(178);
	__webpack_require__(179);
	__webpack_require__(180);
	__webpack_require__(181);
	__webpack_require__(196);
	__webpack_require__(197);
	__webpack_require__(198);
	module.exports = __webpack_require__(199);


/***/ },

/***/ 202:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
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
	                mainParameters: { permissions: productPermissions },
	                getTitleFunction: "getMainTitle"
	            }
	        },
	        "Soccer": {
	            mainView: "soccerLiveNonLive",
	            soccerLiveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "SoccerLiveNonLiveController",
	                service: "remoteDataService",
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
	            soccerBetTypeFull: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerBetTypeFullService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/bettype",
	                mainParameters: {},
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            soccerBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
	                    var isSumBetType = isMajor && data.isLive === 2;
	                    var isGroupBetType = isMajor && data.isLive === 0;
	
	                    if (isSumBetType) {
	                        return "api/house-win-loss-by-products/soccer/sum-bettype";
	                    } else if (isGroupBetType) {
	                        return "api/house-win-loss-by-products/soccer/group-bettype";
	                    } else {
	                        return "api/house-win-loss-by-products/soccer/bettype";
	                    }
	                },
	                mainParameters: function mainParameters(data) {
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
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail' : 'api/house-win-loss-by-products/sportsbook/match-detail';
	                },
	                mainParameters: {},
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: {},
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "Metric Gaming - Superlive": {
	            mainView: "liveNonLive",
	            liveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "MetricGamingLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/live-non-live",
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
	                service: "remoteDataService",
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
	                controller: function controller(data) {
	                    return data.sportType === cricketProductId ? 'BetTypeNewCricketController' : 'BetTypeController';
	                },
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.sportType === cricketProductId ? 'api/house-win-loss-by-products/other-sports/new-cricket/bet-type' : 'api/house-win-loss-by-products/other-sports/bet-type';
	                },
	                mainParameters: {},
	                getTitleFunction: "getSportsbookBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail' : 'api/house-win-loss-by-products/sportsbook/match-detail';
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
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.sportType >= 181 && data.sportType <= 185 ? "api/house-win-loss-by-products/virtual-sports/racing-match-detail" : "api/house-win-loss-by-products/virtual-sports/sportsbook-match-detail";
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
	                serviceBaseUrl: "api/house-win-loss-by-products/colossusbet/bet-type",
	                mainParameters: {},
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/colossusbet/site",
	                mainParameters: {},
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
	                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/match-detail",
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
	        },
	        "Lucky 3": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
	                mainParameters: { productId: 26, isLive: 2 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 26, isLive: 2 },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "Bullfighting": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
	                mainParameters: { productId: 30, sportType: 207, isLive: 2 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 30, isLive: 2 },
	                getTitleFunction: "getSiteTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/bullfighting/match-detail",
	                mainParameters: { sportType: 207 },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Exchange": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
	                mainParameters: { productId: 31, isLive: 2 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 31, isLive: 2 },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Poker Games": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/poker-games/bet-type",
	                mainParameters: { productId: 33, isLive: 2 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/poker-games/site",
	                mainParameters: { productId: 33, isLive: 2 },
	                getTitleFunction: "getSiteTitle"
	            }
	        }
	    };
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 203:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('CasinoProductController', CasinoProductController);
	
	    CasinoProductController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function CasinoProductController($scope, $element, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateBetType = generateBetType;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function generateBetType(productId, productName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                casinoProductId: productId,
	                casinoProductName: productName
	            });
	            tab.goForward('betType', data);
	        }
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var productColumn = data.bodyRows[i].Columns[0];
	                var productId = productColumn.CustomAttr;
	                var productName = productColumn.Value;
	                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace(/'/g, "\\'") + '\')">' + productName + '</a>';
	            }
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showExcelButton: true,
	                showCollapseExpandButton: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 204:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
	    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'titleService'];
	
	    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, showHideColumnService, titleService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var betTypeGridElement = angular.element(gridElements[0]);
	        var liveNonLiveGridElement = angular.element(gridElements[1]);
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateBetType = generateBetType;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.generateSite = generateSite;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            var betTypeGridOptions, liveNonLiveGridOptions;
	
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                betTypeGridOptions = data[0];
	                liveNonLiveGridOptions = data[1];
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(betTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([betTypeGridElement, liveNonLiveGridElement], [betTypeGridOptions, liveNonLiveGridOptions]);
	
	                createLinksForBetType(betTypeGridOptions);
	                renderGridForBetType(betTypeGridOptions);
	                createLinksForLiveNonLive(liveNonLiveGridOptions);
	                renderGridForLiveNonLive(liveNonLiveGridOptions);
	                pane.compileAll();
	            }
	        }
	
	        function generateBetType(isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                isLive: isLive,
	                sportTypeName: "Metric Gaming - Superlive Live"
	            });
	            tab.goForward('betType', data);
	        }
	
	        function generateMatchDetail(betType, betTypeName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                sportTypeName: "Metric Gaming - Superlive Live"
	            });
	            tab.goForward('matchDetail', data);
	        }
	
	        function generateSite(betType, betTypeName, site, isHegde) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                site: site,
	                isHegde: isHegde
	            });
	            tab.goForward('site', data);
	        }
	
	        function renderGridForBetType(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(""),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                showButtonsWhenNoData: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            betTypeGridElement.fanexGrid(data);
	        }
	
	        function renderGridForLiveNonLive(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" Live/Non-Live"),
	                showCollapseExpandButton: true,
	                showExcelButton: false
	            };
	
	            data.titleInfo = titleInfo;
	            liveNonLiveGridElement.fanexGrid(data);
	        }
	
	        function createLinksForBetType(data) {
	            var betTypeId;
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var betTypeRow = data.bodyRows[i];
	                var betTypeName = betTypeRow.Columns[0].Value;
	                var isHegde = betTypeName.match("hegde") ? true : false;
	                betTypeId = betTypeRow.Columns[0].CustomAttr;
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\')">' + betTypeName + '</a>';
	                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
	                    var siteRow = data.bodyRows[i].SubRows[j];
	                    var siteName = siteRow.Columns[0].Value;
	                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',\'' + siteName.replace(/'/g, "\\'") + '\',' + isHegde + ')">' + siteName + '</a>';
	                }
	            }
	        }
	
	        function createLinksForLiveNonLive(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var row = data.bodyRows[i];
	                var name = row.Columns[0].Value;
	                var isLive = parseInt(row.Columns[0].CustomAttr);
	                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + isLive + ')">' + name + '</a>';
	            }
	        }
	
	        function exportExcel() {
	            var betTypeTitle = tab.generateBreadcrumbTextWithSuffix("");
	            var liveNonLiveTitle = tab.generateBreadcrumbTextWithSuffix(" Live/Non-Live");
	
	            var httpData = {};
	            angular.extend(httpData, pane.data);
	            angular.extend(httpData, {
	                betTypeTitle: betTypeTitle,
	                liveNonLiveTitle: liveNonLiveTitle
	            });
	
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 205:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('OtherSportsLiveNonLiveController', OtherSportsLiveNonLiveController);
	
	    OtherSportsLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function OtherSportsLiveNonLiveController($scope, $element, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var sportTypeGridElement = angular.element(gridElements[0]);
	        var liveNonLiveGridElement = angular.element(gridElements[1]);
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateBetType = generateBetType;
	        $scope.generateSportType = generateSportType;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            var sportTypeGridOptions, liveNonLiveGridOptions;
	
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                sportTypeGridOptions = data[0];
	                liveNonLiveGridOptions = data[1];
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(sportTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([sportTypeGridElement, liveNonLiveGridElement], [sportTypeGridOptions, liveNonLiveGridOptions]);
	                createLinksForSportType(sportTypeGridOptions);
	                renderGridForSportType(sportTypeGridOptions);
	                createLinksForLiveNonLive(liveNonLiveGridOptions);
	                renderGridForLiveNonLive(liveNonLiveGridOptions);
	                pane.compileAll();
	            }
	        }
	
	        function renderGridForSportType(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(""),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                showButtonsWhenNoData: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            sportTypeGridElement.fanexGrid(data);
	        }
	
	        function createLinksForSportType(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var sportTypeRow = data.bodyRows[i];
	                var sportTypeName = sportTypeRow.Columns[0].Value;
	                var sportType = sportTypeRow.Columns[0].CustomAttr;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportType + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\')">' + sportTypeName + '</a>';
	            }
	        }
	
	        function renderGridForLiveNonLive(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" Live/Non-Live"),
	                showCollapseExpandButton: true,
	                showExcelButton: false
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            liveNonLiveGridElement.fanexGrid(data);
	        }
	
	        function createLinksForLiveNonLive(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var row = data.bodyRows[i];
	                var name = row.Columns[0].Value;
	                var isLive = parseInt(row.Columns[0].CustomAttr);
	                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSportType(' + isLive + ')">' + name + '</a>';
	            }
	        }
	
	        function generateBetType(sportType, sportTypeName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName
	            });
	            tab.goForward('betType', data);
	        }
	
	        function generateSportType(isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                isLive: isLive
	            });
	            tab.goForward('sportType', data);
	        }
	
	        function exportExcel() {
	            var sportTypeTitle = tab.generateBreadcrumbTextWithSuffix("");
	            var liveNonLiveTitle = tab.generateBreadcrumbTextWithSuffix(" Live/Non-Live");
	            var httpData = {};
	
	            angular.extend(httpData, pane.data);
	            angular.extend(httpData, {
	                sportTypeTitle: sportTypeTitle,
	                liveNonLiveTitle: liveNonLiveTitle
	            });
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 206:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('ParlayBetTypeController', ParlayBetTypeController);
	
	    ParlayBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'legacyService'];
	    function ParlayBetTypeController($scope, $element, fanexGridService, showHideColumnService, legacyService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var parlaySportType = 9;
	        var systemParlayBetType = 29;
	        var mixParlayBetType = 9;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateSite = generateSite;
	        $scope.viewMixParlayWindow = viewMixParlayWindow;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function generateSite(betType, betTypeName, site) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                site: site
	            });
	            tab.goForward('site', data);
	        }
	
	        function viewMixParlayWindow() {
	            var url = '/WinLoss/DailyMixParlayWinLoss_2hLink/Index?startDate=' + pane.data.startDate.format('MM/DD/YYYY') + '&endDate=' + pane.data.endDate.format('MM/DD/YYYY') + '&SportId=' + parlaySportType + '&IsRedirect=true&BetType=' + mixParlayBetType;
	            url = legacyService.resolveUrl(url);
	            location.href = url;
	        }
	
	        function checkvalidLinks() {
	            var balanceday = (0, _moment2.default)(napConfig.BalanceUp);
	            return pane.data.startDate.isSameOrAfter(balanceday);
	        }
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var betTypeRow = data.bodyRows[i];
	                var betTypeName = betTypeRow.Columns[0].Value;
	                var betTypeId = parseInt(betTypeRow.Columns[0].CustomAttr);
	                var isEnableLink = checkvalidLinks();
	                if (betTypeId === systemParlayBetType && isEnableLink === true && pane.data.normalMode === true) {
	                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'ALL\')">' + betTypeName + '</a>';
	                    for (var j = 0; j < betTypeRow.SubRows.length; j++) {
	                        var siteRow = data.bodyRows[i].SubRows[j];
	                        var siteName = siteRow.Columns[0].Value;
	                        siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'' + siteName + '\')">' + siteName + '</a>';
	                    }
	                } else if (betTypeId === mixParlayBetType) {
	                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMixParlayWindow()">' + betTypeName + '</a>';
	                }
	            }
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            var httpData = {};
	            angular.extend(httpData, pane.data);
	            angular.extend(httpData, { title: title });
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default);

/***/ }

});
//# sourceMappingURL=house-win-loss.chunk.js.map