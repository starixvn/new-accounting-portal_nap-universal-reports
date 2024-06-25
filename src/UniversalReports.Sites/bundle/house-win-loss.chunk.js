webpackJsonp([5],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(207);
	__webpack_require__(208);
	__webpack_require__(247);
	__webpack_require__(209);
	__webpack_require__(210);
	__webpack_require__(211);
	__webpack_require__(212);
	__webpack_require__(213);
	__webpack_require__(214);
	__webpack_require__(215);
	__webpack_require__(248);
	__webpack_require__(249);
	__webpack_require__(223);
	__webpack_require__(224);
	__webpack_require__(250);
	__webpack_require__(225);
	__webpack_require__(226);
	__webpack_require__(227);
	__webpack_require__(228);
	__webpack_require__(251);
	__webpack_require__(252);
	__webpack_require__(229);
	__webpack_require__(230);
	__webpack_require__(231);
	__webpack_require__(232);
	__webpack_require__(233);
	__webpack_require__(234);
	__webpack_require__(235);
	__webpack_require__(236);
	__webpack_require__(237);
	__webpack_require__(238);
	__webpack_require__(239);
	__webpack_require__(240);
	__webpack_require__(241);
	__webpack_require__(242);
	__webpack_require__(243);
	__webpack_require__(244);
	__webpack_require__(253);
	__webpack_require__(245);
	module.exports = __webpack_require__(246);


/***/ },

/***/ 247:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	function _defineProperty(obj, key, value) { if (key in obj) { Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true }); } else { obj[key] = value; } return obj; }
	
	(function (angular) {
	    "use strict";
	
	    var _templateSetting;
	
	    var templateSetting = (_templateSetting = {
	        "Main": {
	            mainView: "product",
	            product: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions },
	                getTitleFunction: "getMainTitle"
	            }
	        },
	        "Soccer": {
	            mainView: "soccerLiveNonLive",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions },
	                getTitleFunction: "getProductBetTypeLiveTitle"
	            },
	            soccerLiveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "SoccerLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/live-nonlive",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getSoccerLiveNonLiveTitle"
	            },
	            soccerMajorMinor: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SoccerMajorMinorController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/major-minor",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-major-minor", mainColumnText: "Major/Minor" },
	                getTitleFunction: "getSoccerMajorMinorTitle"
	            },
	            soccerBetTypeFull: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerBetTypeFullService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270 },
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            soccerBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types" ? 1 : 0;
	                    var isSumBetType = isMajor === 1 && data.isLive === 2;
	                    var isGroupBetType = isMajor === 1 && data.isLive === 0;
	
	                    if (isSumBetType) {
	                        return "api/house-win-loss-by-products/soccer/sum-bettype";
	                    } else if (isGroupBetType) {
	                        return "api/house-win-loss-by-products/soccer/group-bettype";
	                    } else {
	                        return "api/house-win-loss-by-products/soccer/bettype";
	                    }
	                },
	                mainParameters: function mainParameters(data) {
	                    var isMajor = data.betTypeNameMajorMinor.includes('Major') ? 1 : 0;
	                    return {
	                        isMajor: isMajor,
	                        type: "soccer-bet-type",
	                        mainColumnText: "Bet Type",
	                        mainColumnWidth: 210,
	                        sheetName: "House Win Loss by Products"
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
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "sportsbook-site" },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "SABA Soccer": {
	            mainView: "soccerLiveNonLive",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions, isSabaSport: 1 },
	                getTitleFunction: "getProductBetTypeLiveTitle"
	            },
	            soccerLiveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "SoccerLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/live-nonlive",
	                mainParameters: { sheetName: "House Win Loss by Products", isSabaSport: 1 },
	                getTitleFunction: "getSoccerLiveNonLiveTitle"
	            },
	            soccerMajorMinor: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SoccerMajorMinorController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/major-minor",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-major-minor", mainColumnText: "Major/Minor", isSabaSport: 1 },
	                getTitleFunction: "getSoccerMajorMinorTitle"
	            },
	            soccerBetTypeFull: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerBetTypeFullService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270, isSabaSport: 1 },
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            soccerBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "SABA Soccer-Major Bet Types" ? 1 : 0;
	                    var isSumBetType = isMajor === 1 && data.isLive === 2;
	                    var isGroupBetType = isMajor === 1 && data.isLive === 0;
	
	                    if (isSumBetType) {
	                        return "api/house-win-loss-by-products/soccer/sum-bettype";
	                    } else if (isGroupBetType) {
	                        return "api/house-win-loss-by-products/soccer/group-bettype";
	                    } else {
	                        return "api/house-win-loss-by-products/soccer/bettype";
	                    }
	                },
	                mainParameters: function mainParameters(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "SABA Soccer-Major Bet Types" ? 1 : 0;
	                    return {
	                        isMajor: isMajor,
	                        type: "soccer-bet-type",
	                        mainColumnText: "Bet Type",
	                        mainColumnWidth: 210,
	                        sheetName: "House Win Loss by Products",
	                        isSabaSport: 1
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
	                mainParameters: { sheetName: "House Win Loss by Products", isSabaSport: 1 },
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "sportsbook-site", isSabaSport: 1 },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "SABA Soccer PinGoal": {
	            mainView: "soccerLiveNonLive",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions, isSabaSport: 3 },
	                getTitleFunction: "getProductBetTypeLiveTitle"
	            },
	            soccerLiveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "SoccerLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/live-nonlive",
	                mainParameters: { sheetName: "House Win Loss by Products", isSabaSport: 3 },
	                getTitleFunction: "getSoccerLiveNonLiveTitle"
	            },
	            soccerMajorMinor: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SoccerMajorMinorController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/major-minor",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-major-minor", mainColumnText: "Major/Minor", isSabaSport: 3 },
	                getTitleFunction: "getSoccerMajorMinorTitle"
	            },
	            soccerBetTypeFull: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerBetTypeFullService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer/bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "soccer-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270, isSabaSport: 3 },
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            soccerBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "SABA Soccer PinGoal-Major Bet Types" ? 1 : 0;
	                    var isSumBetType = isMajor === 1 && data.isLive === 2;
	                    var isGroupBetType = isMajor === 1 && data.isLive === 0;
	
	                    if (isSumBetType) {
	                        return "api/house-win-loss-by-products/soccer/sum-bettype";
	                    } else if (isGroupBetType) {
	                        return "api/house-win-loss-by-products/soccer/group-bettype";
	                    } else {
	                        return "api/house-win-loss-by-products/soccer/bettype";
	                    }
	                },
	                mainParameters: function mainParameters(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "SABA Soccer PinGoal-Major Bet Types" ? 1 : 0;
	                    return {
	                        isMajor: isMajor,
	                        type: "soccer-bet-type",
	                        mainColumnText: "Bet Type",
	                        mainColumnWidth: 210,
	                        sheetName: "House Win Loss by Products",
	                        isSabaSport: 3
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
	                mainParameters: { sheetName: "House Win Loss by Products", isSabaSport: 3 },
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "sportsbook-site", isSabaSport: 3 },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "Metric Gaming - Superlive": {
	            mainView: "liveNonLive",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions, isSabaSport: 2 },
	                getTitleFunction: "getProductBetTypeTitle"
	            },
	            liveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "MetricGamingLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/live-non-live",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getProductTitleLiveNonLive"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/bet-type",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "metric-gaming-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 220 },
	                getTitleFunction: "getSportsbookBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/metric-gaming-superlive/site",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "metric-gaming-superlive-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Other Sports": {
	            mainView: "liveNonLive",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions },
	                getTitleFunction: "getProductBetTypeLiveTitle"
	            },
	            liveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "OtherSportsLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/other-sports/live-non-live",
	                mainParameters: { sheetName: "House Win Loss by Products", aliasProductID: -4 },
	                getTitleFunction: "getProductTitleLiveNonLive"
	            },
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/other-sports/sport-type",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "other-sports-sport-type", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitleLive"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/other-sports/bet-type",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "other-sports-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportsbookBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/house-win-loss-by-products/sportsbook/outright-match-detail' : 'api/house-win-loss-by-products/sportsbook/match-detail';
	                },
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/sportsbook/site",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "sportsbook-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Parlay": {
	            mainView: "betType",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions, isSabaSport: 2 },
	                getTitleFunction: "getProductBetTypeTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ParlayBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/parlay/bet-type",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "parlay-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/parlay/site",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Live Casino": {
	            mainView: "casinoProduct",
	            casinoProduct: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "CasinoProductController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "3rd Party Product" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getCasinoProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Casino": {
	            mainView: "casinoProduct",
	            casinoProduct: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "CasinoProductController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "3rd Party Product" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getCasinoProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Number Game": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGSportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            league: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGLeagueController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "number-game-drill-down", mainColumnText: "League" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "number-game-drill-down", mainColumnText: "Bet Type" },
	                getTitleFunction: "getLeagueTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "number-game-drill-down" },
	                getTitleFunction: "getSiteTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/number-game/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Virtual Sports": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.sportType >= 181 && data.sportType <= 185 ? "api/house-win-loss-by-products/virtual-sports/racing-match-detail" : "api/house-win-loss-by-products/virtual-sports/sportsbook-match-detail";
	                },
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Bettrade": {
	            mainView: "liveNonLive",
	            liveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "CashOutLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/live-non-live",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2 },
	                getTitleFunction: "getProductTitleLiveNonLive"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "CashOutMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: -201 },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: -201, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Racing": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/racing/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Bingo": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "RNG Keno": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Colossus Bets": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "NG2": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "Fishing World": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Cash Out": {
	            mainView: "liveNonLive",
	            liveNonLive: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "CashOutLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/live-non-live",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2 },
	                getTitleFunction: "getProductTitleLiveNonLive"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "CashOutMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: "api/house-win-loss-by-products/cash-out/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: -25 },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: -25, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Lottery": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Virtual Sports 2": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Lucky 3": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-site" },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        },
	        "Bullfighting": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/bullfighting/match-detail",
	                mainParameters: { sheetName: "House Win Loss by Products" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Exchange": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Poker Games": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Bet Builder": {
	            mainView: "sportType",
	            productBetType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/product-bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", permissions: productPermissions, isSabaSport: 2 },
	                getTitleFunction: "getProductBetTypeTitle"
	            },
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "BetBuilderSportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/bet-builder/sport-type",
	                mainParameters: { sheetName: "House Win Loss by Products", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/bet-builder/bettype",
	                mainParameters: { sheetName: "House Win Loss by Products", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportsbookBetTypeTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/bet-builder/site",
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: 38 },
	                getTitleFunction: "getSiteTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "CashOutMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: 'api/house-win-loss-by-products/bet-builder/match-detail',
	                mainParameters: { sheetName: "House Win Loss by Products", bettype: 38 },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Saba Promotion": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Virtual Games": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Indo 4D": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Togel 4D": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Table Game": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "SABA.games": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", productId: 42, mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Funky Games": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Virtual Sports 3": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Sports Lottery": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Vgaming": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", productId: 66, mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Bitcoin": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "FGG": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        },
	        "Player Tips": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	                mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	                getTitleFunction: "getSiteTitle"
	            }
	        }
	    }, _defineProperty(_templateSetting, "Virtual Sports 3", {
	        mainView: "sportType",
	        sportType: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "SportTypeController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	            getTitleFunction: "getProductTitle"
	        },
	        betType: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "BetTypeController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	            getTitleFunction: "getSportTypeTitle"
	        },
	        matchDetail: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "MatchDetailController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/match-detail",
	            mainParameters: { sheetName: "House Win Loss by Products" },
	            getTitleFunction: "getMatchDetailTitle"
	        },
	        site: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "SiteController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	            getTitleFunction: "getSiteTitle"
	        }
	    }), _defineProperty(_templateSetting, "Virtual Sports 4", {
	        mainView: "sportType",
	        sportType: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "SportTypeController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", type: "universal-second-level", mainColumnText: "Sport Type" },
	            getTitleFunction: "getProductTitle"
	        },
	        betType: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "BetTypeController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-bettype", mainColumnText: "Bet Type" },
	            getTitleFunction: "getSportTypeTitle"
	        },
	        matchDetail: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "MatchDetailController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/virtual-sports-betradar/match-detail",
	            mainParameters: { sheetName: "House Win Loss by Products" },
	            getTitleFunction: "getMatchDetailTitle"
	        },
	        site: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "SiteController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	            getTitleFunction: "getSiteTitle"
	        }
	    }), _defineProperty(_templateSetting, "Saba Coins", {
	        mainView: "betType",
	        betType: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "BetTypeController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-second-level", mainColumnText: "Bet Type" },
	            getTitleFunction: "getProductTitle"
	        },
	        site: {
	            templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	            controller: "SiteController",
	            service: "remoteDataService",
	            serviceBaseUrl: "api/house-win-loss-by-products/simple-site-grid",
	            mainParameters: { sheetName: "House Win Loss by Products", isLive: 2, type: "universal-thirdparty-site" },
	            getTitleFunction: "getSiteTitle"
	        }
	    }), _templateSetting);
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 248:
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
	                casinoProductName: productName
	            });
	
	            data.aliasProductID = productId;
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

/***/ 249:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').directive('napFilter', napFilter);
	
	    function napFilter() {
	        var directive = {
	            restrict: 'EA',
	            scope: {},
	            templateUrl: 'app/house-win-loss/filter/filter.directive.html',
	            replace: true,
	            controller: controller,
	            controllerAs: 'vm',
	            bindToController: true
	        };
	        return directive;
	    }
	
	    controller.$inject = ['$scope', '$rootScope', 'config', 'moment', 'ngDialog'];
	    function controller($scope, $rootScope, config, moment, ngDialog) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.minDate = moment("20110101", "YYYYMMDD");
	        vm.currentLevel = 0;
	        vm.accessDenied = modePermissions.length === 0 || productPermissions.length === 0;
	        vm.normalMode = modePermissions.indexOf("HouseWLByProducts_NormalMode") >= 0;
	        vm.showBothMode = modePermissions.indexOf("HouseWLByProducts_NormalMode") >= 0 && modePermissions.indexOf("HouseWLByProducts_HistoryMode") >= 0;
	        vm.today = config.today;
	        vm.yesterday = config.yesterday;
	        vm.date = config.today;
	        vm.startDate = moment.utc(config.yesterday).startOf('month');
	        vm.endDate = moment.utc(config.yesterday);
	        vm.generate = generate;
	        vm.todayClicked = todayClicked;
	        vm.yesterdayClicked = yesterdayClicked;
	        vm.viewNormalMode = viewNormalMode;
	        vm.viewHistoryMode = viewHistoryMode;
	        vm.getDateRange = getDateRange;
	        vm.updateDateRange = updateDateRange;
	        vm.dataMenuId = 487;
	        vm.legentTitle = 'House Win Loss Legend';
	        vm.turnover = false;
	        vm.permissionProfileID = parseInt(permissionProfileID);
	
	        $scope.$on('nap-filter-date', function (event, data) {
	            updateDateRange(data);
	        });
	
	        function generate() {
	            vm.dateRange = getDateRange();
	            if (validDateRange(vm.dateRange.startDate, vm.dateRange.endDate)) {
	                $rootScope.$broadcast('nap-filter-generate', vm.dateRange);
	            }
	        }
	
	        function todayClicked() {
	            vm.date = vm.today;
	            vm.generate();
	        }
	
	        function yesterdayClicked() {
	            vm.date = vm.yesterday;
	            vm.generate();
	        }
	
	        function viewNormalMode() {
	            vm.normalMode = true;
	
	            $('.filter-note').css('display', 'block');
	            $rootScope.$broadcast('nap-filter-switch');
	        }
	
	        function viewHistoryMode() {
	            vm.normalMode = false;
	
	            $('.filter-note').css('display', 'none');
	            $rootScope.$broadcast('nap-filter-switch');
	        }
	
	        function getDateRange() {
	            if (vm.normalMode) {
	                return {
	                    normalMode: vm.normalMode,
	                    startDate: vm.date,
	                    endDate: vm.date,
	                    isNoDraw: parseInt(vm.turnover) === 1,
	                    permissionProfileID: vm.permissionProfileID
	                };
	            } else {
	                return {
	                    normalMode: vm.normalMode,
	                    startDate: vm.startDate,
	                    endDate: vm.endDate,
	                    isNoDraw: parseInt(vm.turnover) === 1,
	                    permissionProfileID: vm.permissionProfileID
	                };
	            }
	        }
	
	        function updateDateRange(dateRange) {
	            vm.normalMode = dateRange.normalMode;
	            if (vm.normalMode) {
	                vm.date = dateRange.startDate;
	            } else {
	                vm.startDate = dateRange.startDate;
	                vm.endDate = dateRange.endDate;
	            }
	        }
	
	        function validDateRange(fromDate, toDate) {
	            var dateDiff = toDate.diff(fromDate, 'days');
	
	            if (dateDiff < 0) {
	                var contentMsg = "From Date must be less than or equal to To Date!";
	                showErrorMsg(contentMsg);
	                return false;
	            } else {
	                var isValidRange = dateDiff <= 40;
	
	                if (isValidRange) {
	                    return true;
	                } else {
	                    var contentMsg = "Date range should not exceed 40 days!";
	                    showErrorMsg(contentMsg);
	                    return false;
	                }
	            }
	        }
	
	        function showErrorMsg(msg) {
	            ngDialog.open({
	                template: '<div class="errorMsg"><p>' + msg + '</p></div>',
	                plain: true,
	                closeByDocument: true,
	                width: 295,
	                overlay: false,
	                className: 'ngdialog-theme-plain'
	            });
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 250:
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
	                sportTypeName: "Metric Gaming - Superlive Live",
	                isLive: 2
	            });
	            tab.goForward('matchDetail', data);
	        }
	
	        function generateSite(betType, betTypeName, site, isHegde) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                siteType: site,
	                mainColumnText: site,
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

/***/ 251:
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
	        $scope.generateProductBetTypes = generateProductBetTypes;
	        $scope.generateProductLiveNonLiveBetTypes = generateProductLiveNonLiveBetTypes;
	
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
	                var isSabaSport = sportTypeRow.Columns[1].CustomAttr;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportType + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\',' + isSabaSport + ')">' + sportTypeName + '</a>';
	
	                if (sportTypeRow != null && sportTypeRow.SubRows != null) {
	                    for (var j = 0; j < sportTypeRow.SubRows.length; j++) {
	                        var subRow = sportTypeRow.SubRows[j];
	                        var siteType = subRow.Columns[0].Value;
	                        subRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProductBetTypes(' + sportType + ', \'' + sportTypeName.replace(/'/g, "\\'") + '\',' + isSabaSport + ',\'' + siteType + '\')">' + siteType + '</a>';
	                    }
	                }
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
	
	                if (row != null && row.SubRows != null) {
	                    for (var j = 0; j < row.SubRows.length; j++) {
	                        var subRow = row.SubRows[j];
	                        var siteType = subRow.Columns[0].Value;
	                        subRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProductLiveNonLiveBetTypes(' + isLive + ',\'' + name + '\',\'' + siteType + '\')">' + siteType + '</a>';
	                    }
	                }
	            }
	        }
	
	        function generateBetType(sportType, sportTypeName, isSabaSport) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName,
	                isLive: 2,
	                isSabaSport: isSabaSport
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
	
	        function generateProductBetTypes(sportType, sportTypeName, isSabaSport, siteType) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName,
	                isLive: 2,
	                isSabaSport: isSabaSport,
	                siteType: siteType,
	                isDrilldownFromMain: false,
	                nameDrilldown: sportTypeName,
	                isMajor: 2
	            });
	            tab.goForward('productBetType', data);
	        }
	
	        function generateProductLiveNonLiveBetTypes(isLive, name, siteType) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                isLive: isLive,
	                siteType: siteType,
	                isDrilldownFromMain: false,
	                nameDrilldown: name,
	                isMajor: 2,
	                isSabaSport: 2
	            });
	            tab.goForward('productBetType', data);
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 252:
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
	                siteType: site,
	                mainColumnText: site
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

/***/ },

/***/ 253:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector', 'houseWinlossService', 'showHideColumnService'];
	    function napPane($log, $compile, $injector, houseWinlossService, showHideColumnService) {
	        function Pane(viewLevel, data) {
	            this.viewLevel = viewLevel;
	            this.data = data;
	            this.$scope = undefined;
	            this.$element = undefined;
	            this.generate = generate;
	            this.show = show;
	            this.compileAll = compileAll;
	            this.compileLinks = compileLinks;
	            this.compileDrilldown = compileDrilldown;
	            this.getFileName = getFileName;
	
	            if (angular.isUndefined(this.viewLevel) || angular.isUndefined(this.data)) {
	                $log.error('Invalid pane');
	                return;
	            }
	
	            this.viewSetting = houseWinlossService.getViewSetting(data.productName, viewLevel, data);
	            if (this.viewSetting === undefined) {
	                loggerService.logError('Sorry, the configuration is corrupted, please notify the administrators.');
	                throw 'Sorry, the configuration is corrupted, please notify the administrators.';
	            }
	
	            this.templateUrl = this.viewSetting.templateUrl;
	            this.controller = this.viewSetting.controller;
	            this.service = $injector.get(this.viewSetting.service);
	
	            function generate() {
	                this.$scope.generate(this.viewSetting);
	            }
	
	            function show() {
	                var gridElement = this.$element.find('.freegrid');
	                gridElement.fanexGrid('resizeGrid');
	            }
	
	            function getFileName() {
	                return 'House_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
	            }
	
	            function compileAll() {
	                this.compileLinks();
	                var elements = this.$element.find('.nap-component');
	                $compile(elements)(this.$scope);
	            }
	
	            function compileLinks() {
	                var elements = this.$element.find('.drill-down');
	                $compile(elements)(this.$scope);
	                elements = this.$element.find('.breadcrumb');
	                $compile(elements)(this.$scope);
	            }
	
	            function compileDrilldown() {
	                var elements = this.$element.find('.drill-down');
	                $compile(elements)(this.$scope);
	            }
	        }
	
	        return Pane;
	    }
	})(_angular2.default);

/***/ }

});
//# sourceMappingURL=house-win-loss.chunk.js.map