webpackJsonp([2],[
/* 0 */
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(56);
	__webpack_require__(57);
	__webpack_require__(58);
	__webpack_require__(59);
	__webpack_require__(60);
	__webpack_require__(61);
	__webpack_require__(62);
	__webpack_require__(63);
	__webpack_require__(64);
	__webpack_require__(65);
	__webpack_require__(66);
	__webpack_require__(67);
	__webpack_require__(68);
	__webpack_require__(69);
	__webpack_require__(70);
	__webpack_require__(71);
	__webpack_require__(72);
	__webpack_require__(73);
	__webpack_require__(74);
	module.exports = __webpack_require__(75);


/***/ },
/* 1 */,
/* 2 */,
/* 3 */,
/* 4 */,
/* 5 */,
/* 6 */,
/* 7 */,
/* 8 */,
/* 9 */,
/* 10 */,
/* 11 */,
/* 12 */,
/* 13 */,
/* 14 */,
/* 15 */,
/* 16 */,
/* 17 */,
/* 18 */,
/* 19 */,
/* 20 */,
/* 21 */,
/* 22 */,
/* 23 */,
/* 24 */,
/* 25 */,
/* 26 */,
/* 27 */,
/* 28 */,
/* 29 */,
/* 30 */,
/* 31 */,
/* 32 */,
/* 33 */,
/* 34 */,
/* 35 */,
/* 36 */,
/* 37 */,
/* 38 */,
/* 39 */,
/* 40 */,
/* 41 */,
/* 42 */,
/* 43 */,
/* 44 */,
/* 45 */,
/* 46 */,
/* 47 */,
/* 48 */,
/* 49 */,
/* 50 */,
/* 51 */,
/* 52 */,
/* 53 */,
/* 54 */,
/* 55 */,
/* 56 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.core').config(config);
	
	    config.$inject = ['$routeProvider'];
	    function config($routeProvider) {
	        configRouting();
	
	        function configRouting() {
	            $routeProvider.when('/', {
	                templateUrl: 'app/house-win-loss/house-win-loss.html',
	                controller: 'HouseWinlossController',
	                controllerAs: 'vm'
	            }).when('/about', {
	                templateUrl: 'app/about/about.html',
	                controller: 'AboutController',
	                controllerAs: 'vm'
	            }).otherwise({
	                redirectTo: '/'
	            });
	        }
	    }
	})(_angular2.default);

/***/ },
/* 57 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp', ['app.core']);
	})(_angular2.default);

/***/ },
/* 58 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
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
	                controller: "BetTypeController",
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
	                controller: "NumberGameBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/number-game/bet-type",
	                mainParameters: {},
	                getTitleFunction: "getNumberGameBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/number-game/match-detail",
	                mainParameters: {},
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/number-game/site",
	                mainParameters: {},
	                getTitleFunction: "getSiteTitleLive"
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
	                getTitleFunction: ""
	            }
	        },
	        "Bingo": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/bet-type",
	                mainParameters: { productId: 7 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 7 },
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
	                mainParameters: { productId: 8 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 8 },
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
	                mainParameters: { productId: 15 },
	                getTitleFunction: "getProductTitle"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/universal/site",
	                mainParameters: { productId: 15 },
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
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
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
	                getTitleFunction: "getSiteTitle"
	            }
	        }
	    };
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },
/* 59 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('HouseWinlossController', HouseWinlossController);
	
	    HouseWinlossController.$inject = [];
	    function HouseWinlossController() {
	        var vm = this;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },
/* 60 */
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').service('houseWinlossService', houseWinlossService);
	
	    houseWinlossService.$inject = ['templateSetting'];
	    function houseWinlossService(templateSetting) {
	        var service = {
	            getViewSetting: getViewSetting,
	            getMainView: getMainView
	        };
	        return service;
	
	        function getMainView(productName) {
	            var productSetting = templateSetting[productName];
	            var isSettingCorrupted = angular.isUndefined(productSetting) || angular.isUndefined(productSetting["mainView"]);
	
	            return isSettingCorrupted ? undefined : productSetting["mainView"];
	        }
	
	        function getViewSetting(productName, viewType, data) {
	
	            var productSetting = templateSetting[productName];
	            var isSettingCorrupted = angular.isUndefined(productSetting) || angular.isUndefined(productSetting[viewType]);
	
	            if (isSettingCorrupted) {
	                return undefined;
	            }
	
	            var viewSetting = productSetting[viewType];
	
	            return compileSetting(viewSetting, data);
	        }
	
	        function compileSetting(setting, data) {
	            var compiledSetting = {};
	            for (var property in setting) {
	                if (setting.hasOwnProperty(property)) {
	                    compiledSetting[property] = resolveFunction(setting[property], data);
	                }
	            }
	
	            return compiledSetting;
	        }
	
	        function resolveFunction(func, data) {
	            return angular.isFunction(func) ? func(data) : func;
	        }
	    }
	})(angular, undefined);

/***/ },
/* 61 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('breadcrumbService', breadcrumbService);
	
	    breadcrumbService.$inject = [];
	    function breadcrumbService() {
	        var service = {
	            generateHtml: generateHtml,
	            generateText: generateText
	        };
	        return service;
	
	        function generateHtml(list) {
	            var html = '<ol class="breadcrumb">';
	            for (var i = 0; i < list.length; i++) {
	                var title = list[i];
	                var isLast = i === list.length - 1;
	                if (isLast) {
	                    html += '<li class="active">' + title + '</li>';
	                } else {
	                    html += '<li><a href data-ng-click="tab.goBack(' + i + ')">' + title + '</a></li>';
	                }
	            }
	
	            return html;
	        }
	
	        function generateText(list) {
	            return list.join(' > ');
	        }
	    }
	})(_angular2.default);

/***/ },
/* 62 */
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('titleService', titleService);
	
	    titleService.$inject = ['soccerConstants'];
	    function titleService(soccerConstants) {
	
	        var service = {
	            getMainTitle: getMainTitle,
	            getProductTitle: getProductTitle,
	            getProductTitleLiveNonLive: getProductTitleLiveNonLive,
	            getProductTitleLive: getProductTitleLive,
	            getSoccerLiveNonLiveTitle: getSoccerLiveNonLiveTitle,
	            getSoccerMajorMinorTitle: getSoccerMajorMinorTitle,
	            getSoccerBetTypeTitle: getSoccerBetTypeTitle,
	            getSportsbookBetTypeTitle: getSportsbookBetTypeTitle,
	            getNumberGameBetTypeTitle: getNumberGameBetTypeTitle,
	            getCasinoProductTitle: getCasinoProductTitle,
	            getSportTypeTitle: getSportTypeTitle,
	            getSportTypeTitleLive: getSportTypeTitleLive,
	            getSiteTitle: getSiteTitle,
	            getSiteTitleLive: getSiteTitleLive,
	            getMatchDetailTitle: getMatchDetailTitle,
	            getMatchDetailTitleLive: getMatchDetailTitleLive
	        };
	        return service;
	
	        function getMainTitle(data) {
	            return 'Main';
	        }
	
	        function getProductTitle(data) {
	            return data.productName;
	        }
	
	        function getProductTitleLiveNonLive(data, isLast) {
	            return isLast ? data.productName + ' Live/Non-Live ' : data.productName;
	        }
	
	        function getProductTitleLive(data) {
	            return data.productName + getLiveText(data.isLive);
	        }
	
	        function getSoccerLiveNonLiveTitle(data, isLast) {
	            return isLast ? ' SOCCER LIVE/NON-LIVE' : "SOCCER";
	        }
	
	        function getSoccerMajorMinorTitle(data) {
	            if (data.isLive === soccerConstants.LiveNonLive) {
	                return data.productName + ' ' + "MAJOR/MINOR";
	            } else {
	                var liveNonLive = data.isLive === soccerConstants.Live ? "LIVE" : "NON-LIVE";
	                return data.productName + ' ' + liveNonLive;
	            }
	        }
	
	        function getSoccerBetTypeTitle(data) {
	            var majorMinor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types" ? "-MAJOR" : "-MINOR";
	            if (data.isLive === soccerConstants.LiveNonLive) {
	                return data.productName + majorMinor + ' BET TYPES';
	            } else {
	                var liveNonLive = data.isLive === soccerConstants.Live ? '"LIVE"' : '"NON-LIVE"';
	                return data.productName + majorMinor + " BET TYPES " + liveNonLive;
	            }
	        }
	
	        function getSportsbookBetTypeTitle(data) {
	            var sportType = getSportTypeTitle(data);
	            var product = getProductTitleLive(data);
	            var viewingFromSportType = sportType !== undefined;
	            return viewingFromSportType ? sportType : product;
	        }
	
	        function getNumberGameBetTypeTitle(data) {
	            return data.isLive === undefined ? data.productName : data.productName + getLiveText(data.isLive);
	        }
	
	        function getCasinoProductTitle(data) {
	            return data.casinoProductName;
	        }
	
	        function getSportTypeTitle(data) {
	            return data.sportTypeName;
	        }
	
	        function getSportTypeTitleLive(data) {
	            return data.sportTypeName + getLiveText(data.isLive);
	        }
	
	        function getSiteTitle(data) {
	            var site = data.site === undefined ? "ALL" : data.site;
	            return data.betTypeName + ' | ' + site + ' Site';
	        }
	
	        function getSiteTitleLive(data) {
	            return data.betTypeName + getLiveText(data.isLive) + '| ' + data.site + ' Site';
	        }
	
	        function getMatchDetailTitle(data) {
	            return data.betTypeName;
	        }
	
	        function getMatchDetailTitleLive(data) {
	            return data.betTypeName + getLiveText(data.isLive);
	        }
	
	        function getLiveText(isLive) {
	            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
	        }
	    }
	})(angular);

/***/ },
/* 63 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
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
	            var data = {
	                casinoProductId: productId,
	                casinoProductName: productName
	            };
	            angular.extend(data, pane.data);
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
/* 64 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('BetTypeController', BetTypeController);
	
	    BetTypeController.$inject = ['$scope', '$element', 'houseWinlossService', 'fanexGridService', 'showHideColumnService'];
	    function BetTypeController($scope, $element, houseWinlossService, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateSite = generateSite;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	
	                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
	                    createLinks(data);
	                    if (pane.data.sportType === 50) {
	                        createLinkChargeCom(data.footerRows);
	                    }
	                }
	
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function generateSite(betType, betTypeName, site) {
	            var data = {
	                betType: betType,
	                betTypeName: betTypeName,
	                site: site,
	                isHedge: betTypeName && betTypeName.indexOf("(hedge)") > -1
	            };
	            angular.extend(data, pane.data);
	            tab.goForward('site', data);
	        }
	
	        function generateMatchDetail(betType, betTypeName) {
	            var data = {
	                betType: betType,
	                betTypeName: betTypeName
	            };
	            angular.extend(data, pane.data);
	            data.isHedge = getHedgeParameters(data.sportType, betTypeName);
	
	            tab.goForward('matchDetail', data);
	
	            function getHedgeParameters(sportType, betTypeName) {
	                if (sportType && sportType > 1) {
	                    return 2;
	                }
	
	                return betTypeName && betTypeName.indexOf("(hedge)") > -1 ? 1 : 0;
	            }
	        }
	
	        function isDateRangeInThreeDays(startDate, endDate) {
	            return endDate.diff(startDate, 'days') < 3;
	        }
	
	        function createLinkChargeCom(data) {
	            for (var i = 0; i < data.length; i++) {
	                if (data[i].Columns[0].Value === "Charge Commission") {
	                    createLink(data[i]);
	                }
	            }
	        }
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                createLink(data.bodyRows[i]);
	            }
	        }
	
	        function createLink(betTypeRow) {
	            var template = houseWinlossService.getViewSetting(pane.data.productName, 'matchDetail', pane.data);
	            var hasDetailDrilldown = angular.isDefined(template);
	            var betTypeName = betTypeRow.Columns[0].Value;
	            var betTypeId = betTypeRow.Columns[0].CustomAttr;
	
	            if (betTypeRow.SubRows && hasDetailDrilldown) {
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\')">' + betTypeName + '</a>';
	            }
	            if (betTypeRow.SubRows) {
	                for (var i = 0; i < betTypeRow.SubRows.length; i++) {
	                    var siteRow = betTypeRow.SubRows[i];
	                    var siteName = siteRow.Columns[0].Value;
	                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',\'' + siteName.replace(/'/g, "\\'") + '\')">' + siteName + '</a>';
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
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },
/* 65 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('MatchDetailController', MatchDetailController);
	
	    MatchDetailController.$inject = ['$scope', '$element', 'fanexGridService'];
	    function MatchDetailController($scope, $element, fanexGridService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showExcelButton: true,
	                exportExcelFunction: exportExcel
	            };
	
	            data.titleInfo = titleInfo;
	            data.showPager = true;
	            data.pagerOption = {
	                itemsPerPage: 50,
	                currentPage: 0,
	                itemsPerPageArray: [50, 100, 200, 500],
	                totalItem: data.bodyRows.length
	            };
	
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.headerColumnHeight = 10;
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },
/* 66 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('remoteDataService', remoteDataService);
	
	    remoteDataService.$inject = ['$http', 'httpResponseService', 'houseWinlossService'];
	    function remoteDataService($http, httpResponseService, houseWinlossService) {
	        var service = {
	            getData: getData,
	            exportExcelForSingleGrid: exportExcelForSingleGrid,
	            exportExcel: exportExcel
	        };
	        return service;
	
	        function getData(viewSetting, data) {
	            var httpData = {};
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	
	            return $http.post(viewSetting.serviceBaseUrl, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcelForSingleGrid(viewSetting, tab, pane) {
	            var title = tab.generateBreadcrumbText();
	            var httpData = {};
	            angular.extend(httpData, pane.data);
	            angular.extend(httpData, { title: title });
	
	            exportExcel(viewSetting, httpData, pane.getFileName());
	        }
	
	        function exportExcel(viewSetting, data, fileName) {
	            var httpData = {};
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	
	            var url = viewSetting.serviceBaseUrl + '/excel';
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },
/* 67 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('SiteController', SiteController);
	
	    SiteController.$inject = ['$injector', '$scope', '$element', 'fanexGridService'];
	    function SiteController($injector, $scope, $element, fanexGridService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showExcelButton: true,
	                exportExcelFunction: exportExcel
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
/* 68 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('SportTypeController', SportTypeController);
	
	    SportTypeController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function SportTypeController($injector, $scope, $element, fanexGridService, showHideColumnService) {
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
	
	        function generateBetType(sportType, sportTypeName, isLive) {
	            var data = {
	                sportType: sportType,
	                sportTypeName: sportTypeName,
	                isLive: isLive
	            };
	            angular.extend(data, pane.data);
	            tab.goForward('betType', data);
	        }
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var sportTypeRow = data.bodyRows[i];
	                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
	                var sportTypeName = sportTypeRow.Columns[0].Value;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\')">' + sportTypeName + '</a>';
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
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },
/* 69 */
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
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
	
	    controller.$inject = ['$scope', '$rootScope', 'config', 'moment'];
	    function controller($scope, $rootScope, config, moment) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.minDate = moment("20110101", "YYYYMMDD");
	        vm.currentLevel = 0;
	        vm.normalMode = true;
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
	        $scope.$on('nap-filter-date', function (event, data) {
	            updateDateRange(data);
	        });
	
	        function generate() {
	            vm.dateRange = getDateRange();
	            $rootScope.$broadcast('nap-filter-generate', vm.dateRange);
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
	                    endDate: vm.date
	                };
	            } else {
	                return {
	                    normalMode: vm.normalMode,
	                    startDate: vm.startDate,
	                    endDate: vm.endDate
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
	    }
	})(_angular2.default);

/***/ },
/* 70 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').service('productShowHideColumnService', productShowHideColumnService);
	
	    productShowHideColumnService.$inject = ['$log', '$timeout'];
	    function productShowHideColumnService($log, $timeout) {
	        var service = {
	            defaultCollapseAllGroups: true,
	            Builder: Builder
	        };
	        return service;
	
	        function Builder(pane) {
	            var defaultCollapseAllGroups = service.defaultCollapseAllGroups;
	            var hiddenColumns = [1, 2];
	            this.getButtonHtml = getButtonHtml;
	            this.build = build;
	            this.toggle = toggle;
	
	            function toggle() {
	                if (defaultCollapseAllGroups !== service.defaultCollapseAllGroups) {
	                    var customButton = pane.$element.find('.btExpand').first();
	                    $timeout(function () {
	                        customButton.trigger('click');
	                    });
	                }
	            }
	
	            function getButtonHtml() {
	                var buttonClass = !defaultCollapseAllGroups ? 'expanded' : 'collapsed';
	                return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
	            }
	
	            function build(listOfGridElements, listOfGridOptions) {
	                if (!angular.isArray(listOfGridElements)) {
	                    listOfGridElements = [listOfGridElements];
	                }
	                if (!angular.isArray(listOfGridOptions)) {
	                    listOfGridOptions = [listOfGridOptions];
	                }
	                if (listOfGridElements.length !== listOfGridOptions.length) {
	                    $log.error('Invalid parameters');
	                    return;
	                }
	
	                pane.$scope.showHideColumns = showHideColumns;
	                for (var i = 0; i < listOfGridOptions.length; i++) {
	                    var gridOptions = listOfGridOptions[i];
	                    gridOptions.hiddenColumns = hiddenColumns;
	                    gridOptions.enableHiddenColumns = !defaultCollapseAllGroups;
	                    gridOptions.defaultCollapseAllGroups = defaultCollapseAllGroups;
	                }
	
	                function showHideColumns($event) {
	                    defaultCollapseAllGroups = !defaultCollapseAllGroups;
	                    service.defaultCollapseAllGroups = defaultCollapseAllGroups;
	                    for (var i = 0; i < listOfGridOptions.length; i++) {
	                        var gridElement = listOfGridElements[i];
	                        var gridOptions = listOfGridOptions[i];
	                        gridOptions.enableHiddenColumns = defaultCollapseAllGroups;
	                        gridOptions.defaultCollapseAllGroups = true;
	                        if (gridOptions.enableHiddenColumns) {
	                            gridElement.fanexGrid("hideColumns", gridOptions, hiddenColumns);
	                        } else {
	                            gridElement.fanexGrid("hideColumns", gridOptions, []);
	                        }
	                    }
	
	                    pane.compileDrilldown();
	                    var target = angular.element($event.target);
	                    if (!defaultCollapseAllGroups) {
	                        target.removeClass('collapsed').addClass('expanded');
	                    } else {
	                        target.removeClass('expanded').addClass('collapsed');
	                    }
	                }
	            }
	        }
	    }
	})(_angular2.default);

/***/ },
/* 71 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('showHideColumnService', showHideColumnService);
	
	    showHideColumnService.$inject = ['$log', '$timeout', 'productShowHideColumnService'];
	    function showHideColumnService($log, $timeout, productShowHideColumnService) {
	        function Builder(pane) {
	            var defaultCollapseAllGroups = productShowHideColumnService.defaultCollapseAllGroups;
	            this.getButtonHtml = getButtonHtml;
	            this.build = build;
	            this.toggle = toggle;
	
	            function raiseDefaultClick() {
	                var buttons = pane.$element.find('.btExpand');
	                var customButton = buttons.first();
	                if (!defaultCollapseAllGroups) {
	                    customButton.removeClass('collapsed').addClass('expanded');
	                } else {
	                    customButton.removeClass('expanded').addClass('collapsed');
	                }
	
	                var defaultButtons = buttons.not(':eq(0)');
	                $timeout(function () {
	                    defaultButtons.trigger('click');
	                });
	            }
	
	            function toggle() {
	                if (defaultCollapseAllGroups != productShowHideColumnService.defaultCollapseAllGroups) {
	                    defaultCollapseAllGroups = productShowHideColumnService.defaultCollapseAllGroups;
	                    raiseDefaultClick();
	                }
	            }
	
	            function getButtonHtml() {
	                var buttonClass = !defaultCollapseAllGroups ? 'expanded' : 'collapsed';
	                return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
	            }
	
	            function build(listOfGridElements, listOfGridOptions) {
	                if (!angular.isArray(listOfGridElements)) {
	                    listOfGridElements = [listOfGridElements];
	                }
	                if (!angular.isArray(listOfGridOptions)) {
	                    listOfGridOptions = [listOfGridOptions];
	                }
	                if (listOfGridElements.length !== listOfGridOptions.length) {
	                    $log.error('Invalid parameters');
	                    return;
	                }
	
	                pane.$scope.showHideColumns = showHideColumns;
	                for (var i = 0; i < listOfGridOptions.length; i++) {
	                    var gridOptions = listOfGridOptions[i];
	                    gridOptions.defaultCollapseAllGroups = defaultCollapseAllGroups;
	                }
	
	                function showHideColumns($event) {
	                    defaultCollapseAllGroups = !defaultCollapseAllGroups;
	                    productShowHideColumnService.defaultCollapseAllGroups = defaultCollapseAllGroups;
	                    raiseDefaultClick();
	                }
	            }
	        };
	
	        return Builder;
	    }
	})(_angular2.default);

/***/ },
/* 72 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
	    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingLiveNonLiveService', 'showHideColumnService', 'titleService'];
	
	    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, metricGamingLiveNonLiveService, showHideColumnService, titleService) {
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
	            pane.service.getBetTypeData(viewSetting, pane.data).then(function (data) {
	                betTypeGridOptions = data;
	                renderAll();
	            });
	
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                liveNonLiveGridOptions = data;
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(betTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([betTypeGridElement, liveNonLiveGridElement], [betTypeGridOptions, liveNonLiveGridOptions]);
	                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
	                    createLinksForBetType(betTypeGridOptions);
	                }
	
	                renderGridForBetType(betTypeGridOptions);
	                createLinksForLiveNonLive(liveNonLiveGridOptions);
	                renderGridForLiveNonLive(liveNonLiveGridOptions);
	                pane.compileAll();
	            }
	        }
	
	        function generateBetType(isLive) {
	            var data = {
	                isLive: isLive,
	                sportTypeName: "Metric Gaming - Superlive Live"
	            };
	            angular.extend(data, pane.data);
	            tab.goForward('betType', data);
	        }
	
	        function generateMatchDetail(betType, betTypeName) {
	            var data = {
	                betType: betType,
	                betTypeName: betTypeName,
	                sportTypeName: "Metric Gaming - Superlive Live"
	            };
	            angular.extend(data, pane.data);
	            tab.goForward('matchDetail', data);
	        }
	
	        function generateSite(betType, betTypeName, site, isHegde) {
	            var data = {
	                betType: betType,
	                betTypeName: betTypeName,
	                site: site,
	                isHegde: isHegde
	            };
	            angular.extend(data, pane.data);
	            tab.goForward('site', data);
	        }
	
	        function renderGridForBetType(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithLastItemReplacement("Metric Gaming - Superlive"),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            betTypeGridElement.fanexGrid(data);
	        }
	
	        function isDateRangeInThreeDays(startDate, endDate) {
	            return endDate.diff(startDate, 'days') < 3;
	        }
	
	        function renderGridForLiveNonLive(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithLastItemReplacement("Metric Gaming - Superlive Live/Non-Live"),
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
	            var betTypeTitle = tab.generateBreadcrumbTextWithLastItemReplacement("Metric Gaming - Superlive");
	            var liveNonLiveTitle = tab.generateBreadcrumbTextWithLastItemReplacement("Metric Gaming - Superlive Live/Non-Live");
	
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
/* 73 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);
	
	    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'houseWinlossService', 'titleService', 'remoteDataService'];
	    function metricGamingLiveNonLiveService($http, httpResponseService, houseWinlossService, titleService, remoteDataService) {
	        var service = {
	            getTitle: titleService.getProductLiveNonLiveTitle,
	            getData: remoteDataService.getData,
	            getBetTypeData: getBetTypeData,
	            exportExcel: remoteDataService.exportExcel
	        };
	        return service;
	
	        function getBetTypeData(viewSetting, data) {
	            var httpData = {};
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	
	            var url = 'api/house-win-loss-by-products/metric-gaming-superlive/bet-type';
	            return $http.post(url, data).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },
/* 74 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    var soccerConstants = {
	        NonLive: 0,
	        Live: 1,
	        LiveNonLive: 2,
	        SoccerSportType: 1
	    };
	
	    angular.module('app.houseWinlossApp').constant('soccerConstants', soccerConstants);
	})(_angular2.default);

/***/ },
/* 75 */
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').directive('napPane', napPane);
	
	    napPane.$inject = ['$templateRequest', '$compile', '$controller'];
	    function napPane($templateRequest, $compile, $controller) {
	        var directive = {
	            restrict: 'EA',
	            require: '^^napTab',
	            scope: {
	                pane: '='
	            },
	            link: link
	        };
	        return directive;
	
	        function link(scope, element, attrs, tabCtrl) {
	            var pane = scope.pane;
	            scope.tab = tabCtrl.tab;
	            $templateRequest(pane.templateUrl, true).then(function (response) {
	                var templateScope = scope.$new(false);
	                var templateElement = element.html(response);
	                var grids = templateElement.find('.freegrid');
	                angular.forEach(grids, function (grid, key) {
	                    var id = 'grid_' + templateScope.$id + '_' + key;
	                    $(grid).attr('id', id);
	                });
	                var templateCtrl = $controller(pane.controller, {
	                    $scope: templateScope,
	                    $element: templateElement
	                });
	
	                templateElement.data('$ngControllerController', templateCtrl);
	                $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
	                    // save $scope & $element into pane
	                    pane.$scope = scope;
	                    pane.$element = templateElement;
	                    pane.generate();
	                });
	            });
	        }
	    }
	})(_angular2.default);

/***/ }
]);
//# sourceMappingURL=house-win-loss.chunk.js.map