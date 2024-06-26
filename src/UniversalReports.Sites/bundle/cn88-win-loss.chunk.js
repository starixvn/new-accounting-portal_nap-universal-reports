webpackJsonp([2],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(172);
	__webpack_require__(173);
	__webpack_require__(174);
	__webpack_require__(175);
	__webpack_require__(176);
	__webpack_require__(177);
	__webpack_require__(178);
	__webpack_require__(179);
	__webpack_require__(180);
	__webpack_require__(181);
	__webpack_require__(182);
	__webpack_require__(183);
	__webpack_require__(184);
	__webpack_require__(185);
	__webpack_require__(186);
	__webpack_require__(187);
	__webpack_require__(188);
	__webpack_require__(189);
	__webpack_require__(190);
	__webpack_require__(191);
	__webpack_require__(192);
	__webpack_require__(193);
	__webpack_require__(194);
	__webpack_require__(195);
	__webpack_require__(196);
	__webpack_require__(197);
	__webpack_require__(198);
	__webpack_require__(199);
	__webpack_require__(200);
	__webpack_require__(201);
	__webpack_require__(202);
	__webpack_require__(203);
	__webpack_require__(204);
	module.exports = __webpack_require__(205);


/***/ },

/***/ 172:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
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
	                templateUrl: 'app/cn88-win-loss/cn88-win-loss.html',
	                controller: 'CN88WinlossController',
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

/***/ 173:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp', ['app.core']);
	})(_angular2.default);

/***/ },

/***/ 174:
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
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ProductController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/product",
	                mainParameters: { sheetName: "CN88 WinLoss", permissions: productPermissions },
	                getTitleFunction: "getMainTitle"
	            }
	        },
	        "Soccer": {
	            mainView: "soccerLiveNonLive",
	            soccerLiveNonLive: {
	                templateUrl: "app/cn88-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "SoccerLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/soccer/live-nonlive",
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getSoccerLiveNonLiveTitle"
	            },
	            soccerMajorMinor: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SoccerMajorMinorController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/soccer/major-minor",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "soccer-major-minor", mainColumnText: "Major/Minor" },
	                getTitleFunction: "getSoccerMajorMinorTitle"
	            },
	            soccerBetTypeFull: {
	                templateUrl: "app/cn88-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerBetTypeFullService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/soccer/bettype",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "soccer-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270 },
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            soccerBetType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
	                    var isSumBetType = isMajor && data.isLive === 2;
	                    var isGroupBetType = isMajor && data.isLive === 0;
	
	                    if (isSumBetType) {
	                        return "api/cn88-win-loss-by-products/soccer/sum-bettype";
	                    } else if (isGroupBetType) {
	                        return "api/cn88-win-loss-by-products/soccer/group-bettype";
	                    } else {
	                        return "api/cn88-win-loss-by-products/soccer/bettype";
	                    }
	                },
	                mainParameters: function mainParameters(data) {
	                    var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
	                    return {
	                        isMajor: isMajor,
	                        type: "soccer-bet-type",
	                        mainColumnText: "Bet Type",
	                        mainColumnWidth: 210,
	                        sheetName: "CN88 WinLoss"
	                    };
	                },
	                getTitleFunction: "getSoccerBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/cn88-win-loss-by-products/sportsbook/outright-match-detail' : 'api/cn88-win-loss-by-products/sportsbook/match-detail';
	                },
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getMatchDetailTitleLive"
	            }
	        },
	        "Other Sports": {
	            mainView: "liveNonLive",
	            liveNonLive: {
	                templateUrl: "app/cn88-win-loss/shared/two-fanex-grid-with-title.html",
	                controller: "OtherSportsLiveNonLiveController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/other-sports/live-non-live",
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getProductTitleLiveNonLive"
	            },
	            sportType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/other-sports/sport-type",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "other-sports-sport-type", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitleLive"
	            },
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: function controller(data) {
	                    return data.sportType === cricketProductId ? 'BetTypeNewCricketController' : 'BetTypeController';
	                },
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.sportType === cricketProductId ? 'api/cn88-win-loss-by-products/other-sports/new-cricket/bet-type' : 'api/cn88-win-loss-by-products/other-sports/bet-type';
	                },
	                mainParameters: { sheetName: "CN88 WinLoss", type: "other-sports-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportsbookBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/cn88-win-loss-by-products/sportsbook/outright-match-detail' : 'api/cn88-win-loss-by-products/sportsbook/match-detail';
	                },
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Parlay": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "ParlayBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/parlay/bet-type",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "parlay-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            }
	        },
	        "Number Game": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGSportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 3, type: "universal-sport-type", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            league: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGLeagueController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 3, type: "number-game-league", mainColumnText: "League" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "NGBetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 3, type: "number-game-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getLeagueTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/number-game/match-detail",
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Virtual Sports": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "virtual-sports-sport-type", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", type: "virtual-sports-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.sportType >= 181 && data.sportType <= 185 ? "api/cn88-win-loss-by-products/virtual-sports/racing-match-detail" : "api/cn88-win-loss-by-products/virtual-sports/sportsbook-match-detail";
	                },
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "RNG Keno": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 8, isLive: 2, type: "universal-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            }
	        },
	        "Virtual Sports 2": {
	            mainView: "sportType",
	            sportType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 27, type: "virtual-sports-betradar-sport-type", mainColumnText: "Sport Type" },
	                getTitleFunction: "getProductTitle"
	            },
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 27, type: "virtual-sports-betradar-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getSportTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "MatchDetailController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/virtual-sports-betradar/match-detail",
	                mainParameters: { sheetName: "CN88 WinLoss" },
	                getTitleFunction: "getMatchDetailTitle"
	            }
	        },
	        "Lottery": {
	            mainView: "betType",
	            betType: {
	                templateUrl: "app/cn88-win-loss/shared/fanex-grid-with-title.html",
	                controller: "BetTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/cn88-win-loss-by-products/simple-grid",
	                mainParameters: { sheetName: "CN88 WinLoss", productId: 28, isLive: 2, type: "universal-bet-type", mainColumnText: "Bet Type" },
	                getTitleFunction: "getProductTitle"
	            }
	        }
	    };
	    angular.module("app.cn88WinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 175:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('CN88WinlossController', CN88WinlossController);
	
	    CN88WinlossController.$inject = [];
	    function CN88WinlossController() {
	        var vm = this;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },

/***/ 176:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').service('cn88WinlossService', cn88WinlossService);
	
	    cn88WinlossService.$inject = ['templateSetting'];
	    function cn88WinlossService(templateSetting) {
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
	})(_angular2.default, undefined);

/***/ },

/***/ 177:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('breadcrumbService', breadcrumbService);
	
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

/***/ 178:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('titleService', titleService);
	
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
	            getBetTypeLiveNonLiveTitle: getBetTypeLiveNonLiveTitle,
	            getCasinoProductTitle: getCasinoProductTitle,
	            getSportTypeTitle: getSportTypeTitle,
	            getSportTypeTitleLive: getSportTypeTitleLive,
	            getLeagueTitle: getLeagueTitle,
	            getSiteTitle: getSiteTitle,
	            getSiteTitleLive: getSiteTitleLive,
	            getMatchDetailTitle: getMatchDetailTitle,
	            getMatchDetailTitleLive: getMatchDetailTitleLive,
	            getSoccerMinorBetTypeTitle: getSoccerMinorBetTypeTitle
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
	
	        function getBetTypeLiveNonLiveTitle(data) {
	            return data.isLive === undefined ? data.productName : data.productName + getLiveText(data.isLive);
	        }
	
	        function getCasinoProductTitle(data) {
	            return data.casinoProductName;
	        }
	
	        function getSportTypeTitle(data) {
	            return data.sportTypeName;
	        }
	
	        function getLeagueTitle(data) {
	            return data.leagueName;
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
	            var isLiveText = data.isLive === 2 ? '' : data.isLive === 1 ? ' "Live"' : ' "Non-Live"';
	            return data.betTypeName + isLiveText;
	        }
	
	        function getLiveText(isLive) {
	            var isLiveValue = parseInt(isLive);
	            var isLiveText = isLiveValue === 2 ? '' : isLiveValue === 1 ? ' "Live"' : ' "Non-Live"';
	
	            return isLiveText;
	        }
	
	        function getSoccerMinorBetTypeTitle() {
	            return 'SOCCER MINOR BET TYPES';
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 179:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').directive('napFilter', napFilter);
	
	    function napFilter() {
	        var directive = {
	            restrict: 'EA',
	            scope: {},
	            templateUrl: 'app/cn88-win-loss/filter/filter.directive.html',
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
	        vm.minDate = moment("20190101", "YYYYMMDD");
	        vm.currentLevel = 0;
	        vm.accessDenied = modePermissions.length === 0 || productPermissions.length === 0;
	        vm.normalMode = modePermissions.indexOf("CN88WinLossByProducts_NormalMode") >= 0;
	        vm.showBothMode = modePermissions.indexOf("CN88WinLossByProducts_NormalMode") >= 0 && modePermissions.indexOf("CN88WinLossByProducts_HistoryMode") >= 0;
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
	        vm.dataMenuId = 651;
	        vm.legentTitle = 'CN88 Win Loss Legend';
	
	        $scope.$on('nap-filter-date', function (event, data) {
	            updateDateRange(data);
	        });
	
	        function generate() {
	            $('.ngdialog-close').click();
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
	
	            $('.ngdialog-close').click();
	            $('.filter-note').css('display', 'block');
	            $rootScope.$broadcast('nap-filter-switch');
	        }
	
	        function viewHistoryMode() {
	            vm.normalMode = false;
	
	            $('.ngdialog-close').click();
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
	
	        function validDateRange(fromDate, toDate) {
	            var isValidRange = toDate.diff(fromDate, 'days') <= 90;
	
	            if (isValidRange) {
	                return true;
	            } else {
	                var contentMsg = "Date range should not exceed 90 days!";
	                showErrorMsg(contentMsg);
	                return false;
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

/***/ 180:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').service('productShowHideColumnService', productShowHideColumnService);
	
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

/***/ 181:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('showHideColumnService', showHideColumnService);
	
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

/***/ 182:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('NG2LiveNonLiveController', NG2LiveNonLiveController);
	
	    NG2LiveNonLiveController.$inject = ['$scope', '$controller', '$element', 'cn88WinlossService', 'fanexGridService', 'showHideColumnService'];
	    function NG2LiveNonLiveController($scope, $controller, $element, cn88WinlossService, fanexGridService, showHideColumnService) {
	        angular.extend(this, $controller('BetTypeController', {
	            $scope: $scope,
	            $element: $element,
	            cn88WinlossService: cn88WinlossService,
	            fanexGridService: fanexGridService,
	            showHideColumnService: showHideColumnService
	        }));
	
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var nonliveGridElement = angular.element(gridElements[0]);
	        var liveGridElement = angular.element(gridElements[1]);
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	
	            var liveGridOptions, nonLiveGridOptions;
	            var httpData = {};
	            angular.extend(httpData, pane.data);
	            httpData.isLive = 1;
	            pane.service.getData(viewSetting, httpData).then(function (data) {
	                liveGridOptions = data;
	                renderAll();
	            });
	
	            httpData.isLive = 0;
	            pane.service.getData(viewSetting, httpData).then(function (data) {
	                nonLiveGridOptions = data;
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(liveGridOptions) && angular.isDefined(nonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([liveGridElement, nonliveGridElement], [liveGridOptions, nonLiveGridOptions]);
	
	                var canViewMatchDetail = httpData.endDate.diff(httpData.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	                    $scope.createDrilldownLinks(liveGridOptions.bodyRows, 1);
	                    $scope.createDrilldownLinks(nonLiveGridOptions.bodyRows, 0);
	                }
	
	                renderLiveGrid(liveGridElement, liveGridOptions);
	                renderNonLiveGrid(nonliveGridElement, nonLiveGridOptions);
	
	                pane.compileAll();
	            }
	        }
	
	        function renderNonLiveGrid(gridElement, data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" Non-Live"),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                showButtonsWhenNoData: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function renderLiveGrid(gridElement, data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" Live"),
	                showCollapseExpandButton: true,
	                showExcelButton: false
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	
	            var nonLiveTitle = tab.generateBreadcrumbTextWithSuffix(" Non-Live");
	            var liveTitle = tab.generateBreadcrumbTextWithSuffix(" Live");
	            var httpData = {};
	            angular.extend(httpData, pane.data);
	            angular.extend(httpData, { liveTitle: liveTitle, nonLiveTitle: nonLiveTitle });
	
	            var serviceBaseUrl = "api/cn88-win-loss-by-products/ng2-live-non-live";
	            var viewSetting = {};
	            angular.extend(viewSetting, $scope.viewSetting);
	            angular.extend(viewSetting, { serviceBaseUrl: serviceBaseUrl });
	
	            pane.service.exportExcel(viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 183:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('NGBetTypeController', NGBetTypeController);
	
	    NGBetTypeController.$inject = ['$scope', '$element', 'cn88WinlossService', 'fanexGridService', 'showHideColumnService'];
	    function NGBetTypeController($scope, $element, cn88WinlossService, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.createDrilldownLink = createDrilldownLink;
	        $scope.createDrilldownLinks = createDrilldownLinks;
	        $scope.renderGrid = renderGrid;
	        $scope.exportExcel = exportExcel;
	        $scope.leagueId = 0;
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            $scope.leagueId = pane.data.leagueId;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	
	                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	                    createDrilldownLinks(data.bodyRows);
	                }
	
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function createDrilldownLinks(rows) {
	            for (var i = 0; i < rows.length; i++) {
	                createDrilldownLink(rows[i]);
	            }
	        }
	
	        function createDrilldownLink(betTypeRow) {
	            var betTypeName = betTypeRow.Columns[0].Value;
	            var betTypeId = betTypeRow.Columns[0].CustomAttr;
	            betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\')">' + betTypeName + '</a>';
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                exportExcelFunction: $scope.exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function generateMatchDetail(betType, betTypeName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                leagueId: $scope.leagueId
	            });
	
	            tab.goForward('matchDetail', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 184:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('NGLeagueController', NGLeagueController);
	
	    NGLeagueController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function NGLeagueController($injector, $scope, $element, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateBetType = generateBetType;
	        $scope.viewSetting = {};
	        $scope.sportType = 0;
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            $scope.sportType = pane.data.sportType;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
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
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var sportTypeRow = data.bodyRows[i];
	                var leagueId = sportTypeRow.Columns[0].CustomAttr;
	                var leagueName = sportTypeRow.Columns[0].Value;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + leagueId + ',\'' + leagueName.replace(/'/g, "\\'") + '\')">' + leagueName + '</a>';
	            }
	        }
	
	        function generateBetType(leagueId, leagueName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                leagueId: leagueId,
	                leagueName: leagueName,
	                sportType: $scope.sportType
	            });
	            tab.goForward('betType', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 185:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('NGSportTypeController', NGSportTypeController);
	
	    NGSportTypeController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function NGSportTypeController($injector, $scope, $element, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateLeague = generateLeague;
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
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var sportTypeRow = data.bodyRows[i];
	                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
	                var sportTypeName = sportTypeRow.Columns[0].Value;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateLeague(' + sportTypeId + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\')">' + sportTypeName + '</a>';
	            }
	        }
	
	        function generateLeague(sportType, sportTypeName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName
	            });
	            tab.goForward('league', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 186:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('OtherSportsLiveNonLiveController', OtherSportsLiveNonLiveController);
	
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
	                sportTypeName: sportTypeName,
	                isLive: 2
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

/***/ 187:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('ParlayBetTypeController', ParlayBetTypeController);
	
	    ParlayBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'legacyService'];
	    function ParlayBetTypeController($scope, $element, fanexGridService, showHideColumnService, legacyService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	                renderGrid(data);
	                pane.compileAll();
	            });
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

/***/ 188:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(116);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('ProductController', ProductController);
	
	    ProductController.$inject = ['$element', '$scope', 'fanexGridService', 'cn88WinlossService', 'productShowHideColumnService'];
	    function ProductController($element, $scope, fanexGridService, cn88WinlossService, productShowHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new productShowHideColumnService.Builder(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateProduct = generateProduct;
	        $scope.viewSetting = {};
	
	        function generateProduct(productName) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, { productName: productName });
	            var level = cn88WinlossService.getMainView(productName);
	            tab.goForward(level, data);
	        }
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
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
	
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var productRow = data.bodyRows[i];
	                var customAttr = productRow.CustomAttr;
	                if (customAttr === 'product') {
	                    var productName = productRow.Columns[0].Value;
	                    productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace(/'/g, "\\'") + '\')">' + productName + '</a>';
	                }
	            }
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            var httpData = { title: title };
	            angular.extend(httpData, pane.data);
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 189:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('BetTypeController', BetTypeController);
	
	    BetTypeController.$inject = ['$scope', '$element', 'cn88WinlossService', 'fanexGridService', 'showHideColumnService'];
	    function BetTypeController($scope, $element, cn88WinlossService, fanexGridService, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        var betradarVirtualSportsMixParlayBettype = 2799;
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.createDrilldownLink = createDrilldownLink;
	        $scope.createDrilldownLinks = createDrilldownLinks;
	        $scope.renderGrid = renderGrid;
	        $scope.exportExcel = exportExcel;
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElement, data);
	
	                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	                    createDrilldownLinks(data.bodyRows, pane.data.isLive);
	                }
	
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function createDrilldownLinks(rows, isLive) {
	            for (var i = 0; i < rows.length; i++) {
	                createDrilldownLink(rows[i], isLive);
	            }
	        }
	
	        function createDrilldownLink(betTypeRow, isLive) {
	            var betTypeName = betTypeRow.Columns[0].Value;
	            var betTypeId = betTypeRow.Columns[0].CustomAttr;
	
	            var template = cn88WinlossService.getViewSetting(pane.data.productName, 'matchDetail', pane.data);
	            var hasDetailDrilldown = angular.isDefined(template) && parseInt(betTypeId) !== betradarVirtualSportsMixParlayBettype && parseInt(betTypeId) !== 0;
	
	            if (hasDetailDrilldown) {
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + betTypeName + '</a>';
	            }
	        }
	
	        function renderGrid(data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                exportExcelFunction: $scope.exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function generateMatchDetail(betType, betTypeName, isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                isLive: isLive
	            });
	            data.isHedge = getHedgeParameters(data.sportType, betTypeName);
	
	            tab.goForward('matchDetail', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	
	        function getHedgeParameters(sportType, betTypeName) {
	            if (sportType && sportType > 1) {
	                return 2;
	            }
	
	            return betTypeName && betTypeName.indexOf("(hedge)") > -1 ? 1 : 0;
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 190:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('BetTypeNewCricketController', BetTypeNewCricketController);
	
	    BetTypeNewCricketController.$inject = ['$scope', '$controller', '$element', 'cn88WinlossService', 'fanexGridService', 'showHideColumnService'];
	    function BetTypeNewCricketController($scope, $controller, $element, cn88WinlossService, fanexGridService, showHideColumnService) {
	
	        angular.extend(this, $controller('BetTypeController', {
	            $scope: $scope,
	            $element: $element,
	            cn88WinlossService: cn88WinlossService,
	            fanexGridService: fanexGridService,
	            showHideColumnService: showHideColumnService
	        }));
	
	        var pane = $scope.pane;
	        var gridElement = $element.find('.freegrid');
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	
	                showHideColumnBuilder.build(gridElement, data);
	
	                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	                    $scope.createDrilldownLinks(data.bodyRows, pane.data.isLive);
	                    createLinkChargeCom(data.footerRows);
	                }
	
	                $scope.renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function createLinkChargeCom(rows) {
	            for (var i = 0; i < rows.length; i++) {
	                if (rows[i].Columns[0].Value === "Charge Commission") {
	                    $scope.createDrilldownLink(rows[i]);
	                }
	            }
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 191:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('MatchDetailController', MatchDetailController);
	
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

/***/ 192:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('remoteDataService', remoteDataService);
	
	    remoteDataService.$inject = ['$http', 'httpResponseService', 'cn88WinlossService'];
	    function remoteDataService($http, httpResponseService, cn88WinlossService) {
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

/***/ 193:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('SportTypeController', SportTypeController);
	
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
	                createLinks(data, pane.data.isLive);
	                renderGrid(data);
	                pane.compileAll();
	            });
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
	
	        function createLinks(data, isLive) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var sportTypeRow = data.bodyRows[i];
	                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
	                var sportTypeName = sportTypeRow.Columns[0].Value;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + sportTypeName + '</a>';
	            }
	        }
	
	        function generateBetType(sportType, sportTypeName, isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName,
	                isLive: isLive
	            });
	            tab.goForward('betType', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 194:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('soccerBetTypeService', soccerBetTypeService);
	
	    soccerBetTypeService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
	    function soccerBetTypeService($http, httpResponseService, soccerConstants) {
	        var service = {
	            getData: getData,
	            exportExcel: exportExcel
	        };
	
	        return service;
	
	        function getData(viewSetting, data) {
	            var isMajor = buildMajorFlag(data);
	            var isLive = data.isLive;
	
	            var httpData = {};
	
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	            httpData.isMajor = isMajor;
	            httpData.normalMode = data.normalMode;
	
	            var url = buildUrl(isLive, isMajor);
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var isMajor = buildMajorFlag(data);
	            var isLive = data.isLive;
	
	            var httpData = {
	                title: title,
	                isMajor: isMajor,
	                normalMode: data.normalMode
	            };
	            angular.extend(httpData, data);
	
	            var url = buildUrl(isLive, isMajor) + '/excel';
	
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	
	        function buildMajorFlag(data) {
	            return data.betTypeNameMajorMinor === "Soccer-Major Bet Types" ? true : false;
	        }
	
	        function buildUrl(isLive, isMajor) {
	            var url = "api/cn88-win-loss-by-products/soccer/bettype";
	            if (isMajor && isLive === soccerConstants.LiveNonLive) {
	                url = "api/cn88-win-loss-by-products/soccer/sum-bettype";
	            } else if (isMajor && isLive === soccerConstants.NonLive) {
	                url = "api/cn88-win-loss-by-products/soccer/group-bettype";
	            }
	
	            return url;
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 195:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('SoccerBetTypeFullController', SoccerBetTypeFullController);
	
	    SoccerBetTypeFullController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'soccerConstants'];
	    function SoccerBetTypeFullController($scope, $element, fanexGridService, showHideColumnService, soccerConstants) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var betTypeFullGridElement = angular.element(gridElements[0]);
	        var betTypeLiveGridElement = angular.element(gridElements[1]);
	        var betTypeNonLiveGridElement = angular.element(gridElements[2]);
	
	        $scope.viewSetting = {};
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.createDrilldownLink = createDrilldownLink;
	        $scope.createDrilldownLinks = createDrilldownLinks;
	        $scope.renderGrid = renderGrid;
	        $scope.exportExcel = exportExcel;
	
	        function generate(viewSetting) {
	            var betTypeFullGridOptions, betTypeLiveGridOptions, betTypeNonLiveGridOptions;
	            $scope.viewSetting = viewSetting;
	
	            pane.service.getData(viewSetting, pane.data, 2).then(function (data) {
	                betTypeFullGridOptions = data;
	                renderAll();
	            });
	
	            pane.service.getData(viewSetting, pane.data, 1).then(function (data) {
	                betTypeLiveGridOptions = data;
	                renderAll();
	            });
	
	            pane.service.getData(viewSetting, pane.data, 0).then(function (data) {
	                betTypeNonLiveGridOptions = data;
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(betTypeFullGridOptions) && angular.isDefined(betTypeLiveGridOptions) && angular.isDefined(betTypeNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([betTypeFullGridElement, betTypeLiveGridElement, betTypeNonLiveGridElement], [betTypeFullGridOptions, betTypeLiveGridOptions, betTypeNonLiveGridOptions]);
	
	                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	                    createDrilldownLinks(betTypeFullGridOptions.bodyRows, 2);
	                    createDrilldownLinks(betTypeLiveGridOptions.bodyRows, 1);
	                    createDrilldownLinks(betTypeNonLiveGridOptions.bodyRows, 0);
	                }
	
	                renderFullGrid(betTypeFullGridElement, betTypeFullGridOptions);
	                renderGrid(betTypeLiveGridElement, betTypeLiveGridOptions, 1);
	                renderGrid(betTypeNonLiveGridElement, betTypeNonLiveGridOptions, 0);
	                pane.compileAll();
	            }
	        }
	
	        function createDrilldownLinks(rows, isLive) {
	            for (var i = 0; i < rows.length; i++) {
	                createDrilldownLink(rows[i], isLive);
	            }
	        }
	
	        function createDrilldownLink(betTypeRow, isLive) {
	            var betTypeName = betTypeRow.Columns[0].Value;
	            var betTypeId = betTypeRow.Columns[0].CustomAttr;
	
	            if (parseInt(betTypeId) !== 0) {
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + betTypeName + '</a>';
	            }
	        }
	        function renderFullGrid(gridElement, gridOptions) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtml(),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                showButtonsWhenNoData: true,
	                exportExcelFunction: $scope.exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            gridOptions.titleInfo = titleInfo;
	            gridOptions.bottomBorderWidth = 3;
	            gridElement.fanexGrid(gridOptions);
	        }
	
	        function renderGrid(gridElement, gridOptions, isLive) {
	            var suffix = isLive === 1 ? ' "LIVE"' : ' "NON-LIVE"';
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(suffix),
	                showCollapseExpandButton: true,
	                showExcelButton: false
	            };
	
	            gridOptions.titleInfo = titleInfo;
	            gridOptions.bottomBorderWidth = 3;
	            gridElement.fanexGrid(gridOptions);
	        }
	
	        function generateMatchDetail(betType, betTypeName, isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                isLive: isLive
	            });
	            data.isHedge = getHedgeParameters(data.sportType, betTypeName);
	
	            tab.goForward('matchDetail', data);
	        }
	
	        function getHedgeParameters(sportType, betTypeName) {
	            if (sportType && sportType > 1) {
	                return 2;
	            }
	
	            return betTypeName && betTypeName.indexOf("(hedge)") > -1 ? 1 : 0;
	        }
	
	        function exportExcel() {
	
	            var betTypeFullTitle = tab.generateBreadcrumbText();
	            var betTypeLiveTitle = tab.generateBreadcrumbTextWithSuffix(' "LIVE"');
	            var betTypeNonLiveTitle = tab.generateBreadcrumbTextWithSuffix(' "NON-LIVE"');
	
	            var httpData = {
	                betTypeFullTitle: betTypeFullTitle,
	                betTypeLiveTitle: betTypeLiveTitle,
	                betTypeNonLiveTitle: betTypeNonLiveTitle
	            };
	            angular.extend(httpData, pane.data);
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 196:
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('soccerBetTypeFullService', soccerBetTypeFullService);
	
	    soccerBetTypeFullService.$inject = ['$http', 'httpResponseService'];
	    function soccerBetTypeFullService($http, httpResponseService) {
	        var service = {
	            getData: getData,
	            exportExcel: exportExcel
	        };
	
	        return service;
	
	        function getData(viewSetting, data, isLive) {
	            var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
	            var isSumBetType = isMajor && isLive === 2;
	            var isGroupBetType = isMajor && isLive === 0;
	            var url = "api/cn88-win-loss-by-products/soccer/bettype";
	            if (isSumBetType) {
	                url = "api/cn88-win-loss-by-products/soccer/sum-bettype";
	            } else if (isGroupBetType) {
	                url = "api/cn88-win-loss-by-products/soccer/group-bettype";
	            }
	
	            var httpData = {};
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	            httpData.isLive = isLive;
	            httpData.isMajor = isMajor;
	
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(viewSetting, data, fileName) {
	            var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
	            var httpData = { isMajor: isMajor };
	            angular.extend(httpData, data);
	
	            var url = 'api/cn88-win-loss-by-products/soccer/bettype-full/excel';
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(angular);

/***/ },

/***/ 197:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('SoccerLiveNonLiveController', SoccerLiveNonLiveController);
	
	    SoccerLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'soccerConstants'];
	    function SoccerLiveNonLiveController($scope, $element, fanexGridService, showHideColumnService, soccerConstants) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var majorMinorGridElement = angular.element(gridElements[0]);
	        var liveNonLiveGridElement = angular.element(gridElements[1]);
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generate = generate;
	        $scope.generateSoccerLiveNonLivePane = generateSoccerLiveNonLivePane;
	        $scope.generateSoccerBetTypePane = generateSoccerBetTypePane;
	        $scope.viewSetting = {};
	        pane.data.isLive = soccerConstants.LiveNonLive;
	
	        function generate(viewSetting) {
	            var majorMinorGridOptions, liveNonLiveGridOptions;
	            $scope.viewSetting = viewSetting;
	
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                majorMinorGridOptions = data[0];
	                liveNonLiveGridOptions = data[1];
	                renderAll();
	            });
	
	            function renderAll() {
	                var isDataReady = angular.isDefined(majorMinorGridOptions) && angular.isDefined(liveNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([majorMinorGridElement, liveNonLiveGridElement], [majorMinorGridOptions, liveNonLiveGridOptions]);
	
	                createLinksForMajorMinor(majorMinorGridOptions);
	                renderMajorMinorGrid(majorMinorGridElement, majorMinorGridOptions);
	
	                createLinksForLiveNonLive(liveNonLiveGridOptions);
	                renderLiveNonLiveGrid(liveNonLiveGridElement, liveNonLiveGridOptions);
	
	                pane.compileAll();
	            }
	        }
	
	        function renderMajorMinorGrid(gridElement, data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" MAJOR/MINOR"),
	                showCollapseExpandButton: true,
	                showExcelButton: true,
	                showButtonsWhenNoData: true,
	                exportExcelFunction: exportExcel,
	                customButtons: showHideColumnBuilder.getButtonHtml()
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function renderLiveNonLiveGrid(gridElement, data) {
	            var titleInfo = {
	                text: tab.generateBreadcrumbHtmlWithSuffix(" LIVE/NON-LIVE"),
	                showCollapseExpandButton: true,
	                showExcelButton: false
	            };
	
	            data.titleInfo = titleInfo;
	            data.bottomBorderWidth = 3;
	            gridElement.fanexGrid(data);
	        }
	
	        function createLinksForMajorMinor(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var betTypeRow = data.bodyRows[i];
	                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
	            }
	        }
	
	        function generateSoccerBetTypePane(betTypeNameMajorMinor) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betTypeNameMajorMinor: betTypeNameMajorMinor,
	                sportTypeName: betTypeNameMajorMinor
	            });
	            tab.goForward('soccerBetTypeFull', data);
	        }
	
	        function createLinksForLiveNonLive(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var betTypeRow = data.bodyRows[i];
	                var soccerLiveNonLive = betTypeRow.Columns[0].Value;
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLivePane(\'' + soccerLiveNonLive + '\')">' + soccerLiveNonLive + '</a>';
	            }
	        }
	
	        function generateSoccerLiveNonLivePane(soccerLiveNonLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                soccerLiveNonLive: soccerLiveNonLive
	            });
	            tab.goForward('soccerMajorMinor', data);
	        }
	
	        function exportExcel() {
	
	            var majorMinorTitle = tab.generateBreadcrumbTextWithSuffix(" MAJOR/MINOR");
	            var liveNonLiveTitle = tab.generateBreadcrumbTextWithSuffix(" LIVE/NON-LIVE");
	
	            var httpData = {
	                majorMinorTitle: majorMinorTitle,
	                liveNonLiveTitle: liveNonLiveTitle
	            };
	            angular.extend(httpData, pane.data);
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 198:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('SoccerMajorMinorController', SoccerMajorMinorController);
	
	    SoccerMajorMinorController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerConstants', 'showHideColumnService'];
	    function SoccerMajorMinorController($scope, $element, fanexGridService, soccerConstants, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generateSoccerLiveNonLiveBetTypePane = generateSoccerLiveNonLiveBetTypePane;
	        $scope.viewSetting = {};
	        pane.data.isLive = pane.data.soccerLiveNonLive === "Soccer Non-Live" ? soccerConstants.NonLive : soccerConstants.Live;
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                showHideColumnBuilder.build(gridElements, data);
	                createLinksForMajorMinor(data);
	                renderGrid(gridElements, data);
	                pane.compileAll();
	            });
	        }
	
	        function renderGrid(gridElement, data) {
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
	
	        function createLinksForMajorMinor(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var betTypeRow = data.bodyRows[i];
	                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLiveBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
	            }
	        }
	
	        function generateSoccerLiveNonLiveBetTypePane(betTypeNameMajorMinor) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betTypeNameMajorMinor: betTypeNameMajorMinor,
	                sportTypeName: betTypeNameMajorMinor
	            });
	            tab.goForward('soccerBetType', data);
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            var httpData = {
	                title: title
	            };
	            angular.extend(httpData, pane.data);
	            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 199:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
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
	
	    angular.module('app.cn88WinlossApp').constant('soccerConstants', soccerConstants);
	})(_angular2.default);

/***/ },

/***/ 200:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').controller('SportsbookMatchDetailController', SportsbookMatchDetailController);
	
	    SportsbookMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', '$uibModal', '$uibModalStack'];
	    function SportsbookMatchDetailController($scope, $element, fanexGridService, $uibModal, $uibModalStack) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.viewMatchInformation = viewMatchInformation;
	        $scope.viewSetting = {};
	
	        function generate(viewSetting) {
	            $scope.viewSetting = viewSetting;
	            pane.service.getData(viewSetting, pane.data).then(function (data) {
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function viewMatchInformation(sportType, matchId, eventDate, leagueName, matchCode) {
	            pane.data.sportType = sportType;
	            pane.data.matchId = matchId;
	            pane.data.eventDate = eventDate;
	            pane.data.matchCode = matchCode;
	            pane.service.getMatchInformation(pane.data).then(function (data) {
	                showPopup(data, leagueName);
	            });
	        }
	
	        function showPopup(data, leagueName) {
	            var traderName = data && data.TraderName && data.TraderName !== '' ? data.TraderName : "Unassigned";
	            var newScope = $scope.$new();
	            angular.extend(newScope, {
	                sportTypeName: pane.data.sportTypeName,
	                betTypeName: pane.data.betTypeName,
	                leagueName: leagueName,
	                traderName: traderName,
	                matchId: pane.data.matchId,
	                liveName: getLiveName(pane.data.isLive),
	                matchInformation: data.MatchInformation,
	                closePopup: closePopup
	            });
	            $uibModal.open({
	                templateUrl: 'app/cn88-win-loss/sportsbook/sportsbook-match-information.html',
	                size: 'match-information',
	                scope: newScope
	            });
	        }
	
	        function getLiveName(data) {
	
	            if (data === 1) {
	                return "Live!";
	            } else if (data === 0) {
	                return "Non-Live!";
	            } else {
	                return " ";
	            }
	        }
	
	        function closePopup() {
	            $uibModalStack.dismissAll("Close");
	        }
	        function createLinks(data) {
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var bodyRow = data.bodyRows[i];
	                var customAttr = bodyRow.Columns[0].CustomAttr;
	                if (customAttr) {
	                    var matchName = bodyRow.Columns[0].Value;
	                    bodyRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMatchInformation(' + customAttr + ')">' + matchName + '</a>';
	                }
	            }
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
	                totalItem: data.bodyRows.length,
	                afterPagedFunction: function afterPagedFunction() {
	                    pane.compileDrilldown();
	                }
	            };
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

/***/ 201:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('sportsbookMatchDetailService', sportsbookMatchDetailService);
	
	    sportsbookMatchDetailService.$inject = ['$http', 'httpResponseService', 'legacyService', 'remoteDataService'];
	    function sportsbookMatchDetailService($http, httpResponseService, legacyService, remoteDataService) {
	        var service = {
	            getMatchInformation: getMatchInformation,
	            getData: remoteDataService.getData,
	            exportExcel: remoteDataService.exportExcel
	        };
	        return service;
	
	        function getMatchInformation(data) {
	            var httpData = {
	                matchId: data.matchId,
	                betType: data.betType,
	                sportType: data.sportType,
	                reportDate: data.eventDate,
	                matchCode: data.matchCode,
	                liveIndicator: data.isLive
	            };
	
	            var url = legacyService.resolveUrl('/ScoreInformation/GetScoreInformation');
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 202:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').directive('napPane', napPane);
	
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

/***/ },

/***/ 203:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector', 'cn88WinlossService', 'showHideColumnService'];
	    function napPane($log, $compile, $injector, cn88WinlossService, showHideColumnService) {
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
	
	            this.viewSetting = cn88WinlossService.getViewSetting(data.productName, viewLevel, data);
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
	                return 'CN88_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
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

/***/ },

/***/ 204:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').directive('napTab', napTab);
	
	    napTab.$inject = ['napPane'];
	    function napTab(Pane) {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                panes: '='
	            },
	            templateUrl: 'app/cn88-win-loss/tab/tab.directive.html',
	            controller: controller,
	            controllerAs: 'vm',
	            bindToController: true
	        };
	        return directive;
	    }
	
	    controller.$inject = ['$scope', '$rootScope', 'napTab', 'napPane'];
	    function controller($scope, $rootScope, Tab, Pane) {
	        var tab = new Tab($scope.panes);
	        var vm = this;
	        vm.tab = tab;
	
	        $scope.$on('nap-filter-generate', function (event, data) {
	            if (tab.panes.length === 0) {
	                var pane = getMainPane(data);
	                tab.addPane(pane);
	            } else {
	                var activePane = tab.getActivePane();
	                angular.extend(activePane.data, data);
	                activePane.generate();
	            }
	        });
	
	        $scope.$on('nap-filter-switch', function (event) {
	            tab.panes = [];
	        });
	
	        function getMainPane(data) {
	            var hasMainPagePermission = productPermissions.indexOf("CN88WinLossByProducts_AllProducts") >= 0 || productPermissions.indexOf("CN88WinLossByProducts_Sportsbook") >= 0 || productPermissions.indexOf("CN88WinLossByProducts_ThirdPartyProducts") >= 0 || productPermissions.indexOf("CN88WinLossByProducts_Soccer") >= 0 || productPermissions.indexOf("CN88WinLossByProducts_OtherSports") >= 0;
	            var hasOnlySoccerLivePermission = productPermissions.indexOf("CN88WinLossByProducts_SoccerLive") >= 0;
	            var hasOnlySoccerNonLivePermission = productPermissions.indexOf("CN88WinLossByProducts_SoccerNonLive") >= 0;
	
	            if (hasMainPagePermission) {
	                data.productName = "Main";
	                return new Pane('product', data);
	            }
	
	            if (hasOnlySoccerLivePermission) {
	                data.productName = "Soccer";
	                data.isLive = 1;
	                data.soccerLiveNonLive = "Soccer Live";
	                return new Pane('soccerMajorMinor', data);
	            }
	
	            if (hasOnlySoccerNonLivePermission) {
	                data.productName = "Soccer";
	                data.isLive = 0;
	                data.soccerLiveNonLive = "Soccer Non-Live";
	                return new Pane('soccerMajorMinor', data);
	            }
	
	            data.productName = "Main";
	            return new Pane('product', data);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 205:
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular) {
	    'use strict';
	
	    angular.module('app.cn88WinlossApp').factory('napTab', napTab);
	
	    napTab.$inject = ['$rootScope', 'breadcrumbService', 'napPane', 'titleService'];
	    function napTab($rootScope, breadcrumbService, Pane, titleService) {
	        function Tab(panes) {
	            this.panes = angular.isDefined(panes) ? panes : [];
	            this.addPane = addPane;
	            this.getActivePane = getActivePane;
	            this.getPreviousPane = getPreviousPane;
	            this.goBack = goBack;
	            this.goForward = goForward;
	            this.generateBreadcrumbList = generateBreadcrumbList;
	            this.generateBreadcrumbListWithModifiedLastItem = generateBreadcrumbListWithModifiedLastItem;
	            this.generateBreadcrumbHtml = generateBreadcrumbHtml;
	            this.generateBreadcrumbText = generateBreadcrumbText;
	            this.generateBreadcrumbTextWithSuffix = generateBreadcrumbTextWithSuffix;
	            this.generateBreadcrumbHtmlWithSuffix = generateBreadcrumbHtmlWithSuffix;
	
	            function addPane(pane) {
	                this.panes.push(pane);
	            }
	
	            function getActivePane() {
	                return this.panes[this.panes.length - 1];
	            }
	
	            function getPreviousPane(pane) {
	                var previousPane = null;
	                for (var i = 0; i < this.panes.length; i++) {
	                    var currentPane = this.panes[i];
	                    if (currentPane === pane) {
	                        break;
	                    }
	
	                    previousPane = currentPane;
	                }
	
	                return previousPane;
	            }
	
	            function goBack(index) {
	                this.panes = this.panes.slice(0, index + 1);
	                var newActivePane = this.getActivePane();
	                if (angular.isFunction(newActivePane.$scope.show)) {
	                    newActivePane.$scope.show();
	                }
	
	                var activePane = this.panes[index];
	                var dateRange = {
	                    normalMode: activePane.data.normalMode,
	                    startDate: activePane.data.startDate,
	                    endDate: activePane.data.endDate
	                };
	                $rootScope.$broadcast('nap-filter-date', dateRange);
	            }
	
	            function goForward(level, data) {
	                var pane = new Pane(level, data);
	                this.addPane(pane);
	            }
	
	            function generateBreadcrumbListWithModifiedLastItem() {
	                var list = [];
	                for (var i = 0; i < this.panes.length; i++) {
	                    var pane = this.panes[i];
	                    var isLast = i === this.panes.length - 1;
	                    var getTitleFunction = pane.viewSetting.getTitleFunction;
	                    var title = titleService[getTitleFunction](pane.data, isLast);
	                    list.push(title);
	                }
	
	                return list;
	            }
	
	            function generateBreadcrumbList() {
	                var list = [];
	                for (var i = 0; i < this.panes.length; i++) {
	                    var pane = this.panes[i];
	                    var getTitleFunction = pane.viewSetting.getTitleFunction;
	                    var title = titleService[getTitleFunction](pane.data, false);
	                    list.push(title);
	                }
	
	                return list;
	            }
	
	            function generateBreadcrumbHtml() {
	                var list = this.generateBreadcrumbListWithModifiedLastItem();
	                return breadcrumbService.generateHtml(list);
	            }
	
	            function generateBreadcrumbText() {
	                var list = this.generateBreadcrumbListWithModifiedLastItem();
	                return breadcrumbService.generateText(list);
	            }
	
	            function generateBreadcrumbHtmlWithSuffix(suffix) {
	                var list = this.generateBreadcrumbList();
	                list[list.length - 1] = list[list.length - 1] + suffix;
	                return breadcrumbService.generateHtml(list);
	            }
	
	            function generateBreadcrumbTextWithSuffix(suffix) {
	                var list = this.generateBreadcrumbList();
	                list[list.length - 1] = list[list.length - 1] + suffix;
	                return breadcrumbService.generateText(list);
	            }
	        }
	
	        return Tab;
	    }
	})(angular);

/***/ }

});
//# sourceMappingURL=cn88-win-loss.chunk.js.map