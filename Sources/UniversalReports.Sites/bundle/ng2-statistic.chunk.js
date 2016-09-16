webpackJsonp([4],{

/***/ 0:
/*!***************************!*\
  !*** multi ng2-statistic ***!
  \***************************/
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(/*! ./app/ng2-statistic/app.js */108);
	__webpack_require__(/*! ./app/ng2-statistic/ng2-statistic.constant.js */109);
	__webpack_require__(/*! ./app/ng2-statistic/ng2-statistic.controller.js */110);
	__webpack_require__(/*! ./app/ng2-statistic/ng2-statistic.service.js */111);
	__webpack_require__(/*! ./app/ng2-statistic/breadcrumb/breadcrumb.service.js */112);
	__webpack_require__(/*! ./app/ng2-statistic/breadcrumb/live-title.service.js */113);
	__webpack_require__(/*! ./app/ng2-statistic/breadcrumb/title.service.js */114);
	__webpack_require__(/*! ./app/ng2-statistic/filter/filter.directive.js */115);
	__webpack_require__(/*! ./app/ng2-statistic/soccer/soccer-major-minor.controller.js */116);
	__webpack_require__(/*! ./app/ng2-statistic/soccer/soccer-major-minor.service.js */117);
	__webpack_require__(/*! ./app/ng2-statistic/soccer/soccer.constant.js */118);
	__webpack_require__(/*! ./app/ng2-statistic/tab/pane.directive.js */119);
	__webpack_require__(/*! ./app/ng2-statistic/tab/pane.service.js */120);
	__webpack_require__(/*! ./app/ng2-statistic/tab/tab.directive.js */121);
	module.exports = __webpack_require__(/*! ./app/ng2-statistic/tab/tab.service.js */122);


/***/ },

/***/ 108:
/*!**********************************!*\
  !*** ./app/ng2-statistic/app.js ***!
  \**********************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic', ['app.core']);
	})(_angular2.default);

/***/ },

/***/ 109:
/*!*****************************************************!*\
  !*** ./app/ng2-statistic/ng2-statistic.constant.js ***!
  \*****************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    var templateSetting = {
	        'Soccer': {
	            product: 'soccerLiveNonLive',
	            soccerLiveNonLive: {
	                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
	                controller: 'SoccerLiveNonLiveController',
	                service: 'soccerLiveNonLiveService'
	            },
	            soccerMajorMinor: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SoccerMajorMinorController',
	                service: 'soccerMajorMinorService'
	            },
	            soccerBetType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'soccerBetTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportsbookMatchDetailController',
	                service: 'sportsbookMatchDetailService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'sportsbookSiteService'
	            }
	        },
	        'Metric Gaming - Superlive': {
	            product: 'liveNonLive',
	            liveNonLive: {
	                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
	                controller: 'MetricGamingLiveNonLiveController',
	                service: 'metricGamingLiveNonLiveService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'sportsbookBetTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportsbookMatchDetailController',
	                service: 'sportsbookMatchDetailService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'sportsbookSiteService'
	            }
	        },
	        'Other Sports': {
	            product: 'liveNonLive',
	            liveNonLive: {
	                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
	                controller: 'OtherSportsLiveNonLiveController',
	                service: 'otherSportsLiveNonLiveService'
	            },
	            sportType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportTypeController',
	                service: 'otherSportsSportTypeService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'sportsbookBetTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportsbookMatchDetailController',
	                service: 'sportsbookMatchDetailService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'sportsbookSiteService'
	            }
	        },
	        'Parlay': {
	            product: 'betType',
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'ParlayBetTypeController',
	                service: 'parlayBetTypeService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'parlaySiteService'
	            }
	        },
	        'Live Casino': {
	            product: 'casinoProduct',
	            casinoProduct: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'CasinoProductController',
	                service: 'casinoProductService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'CasinoBetTypeService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'siteService'
	            }
	        },
	        'Casino': {
	            product: 'casinoProduct',
	            casinoProduct: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'CasinoProductController',
	                service: 'casinoProductService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'CasinoBetTypeService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'siteService'
	            }
	        },
	        'Number Game': {
	            product: 'betType',
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/two-fanex-grid-with-title.html',
	                controller: 'NumberGameBetTypeController',
	                service: 'numberGameBetTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'MatchDetailController',
	                service: 'numberGameMatchDetailService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'numberGameSiteService'
	            }
	        },
	        'Virtual Sports': {
	            product: 'sportType',
	            sportType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportTypeController',
	                service: 'sportTypeService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'betTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'MatchDetailController',
	                service: function service(data) {
	                    return data.sportType >= 181 && data.sportType <= 185 ? 'virtualSportsRacingDetailService' : 'virtualSportsSportsbookDetailService';
	                }
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'siteService'
	            }
	        },
	        'Bettrade': {
	            product: 'betType',
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'bettradeBetTypeService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'siteService'
	            }
	        },
	        'Racing': {
	            product: 'sportType',
	            sportType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SportTypeController',
	                service: 'sportTypeService'
	            },
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'betTypeService'
	            },
	            matchDetail: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'MatchDetailController',
	                service: 'matchDetailService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'siteService'
	            }
	        }
	    };
	    var universalSettings = {
	        products: {
	            "Bingo": 7,
	            "Keno": 8,
	            "Colossus Bets": 15
	        },
	        settings: {
	            product: 'betType',
	            betType: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'BetTypeController',
	                service: 'universalBetTypeService'
	            },
	            site: {
	                templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                controller: 'SiteController',
	                service: 'universalSiteService'
	            }
	        },
	        getProductId: function getProductId(productName) {
	            return universalSettings.products[productName];
	        }
	    };
	    angular.module('app.NG2Statistic').constant('templateSetting', templateSetting).constant('universalSettings', universalSettings);
	})(_angular2.default);

/***/ },

/***/ 110:
/*!*******************************************************!*\
  !*** ./app/ng2-statistic/ng2-statistic.controller.js ***!
  \*******************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').controller('HouseWinlossController', HouseWinlossController);
	
	    HouseWinlossController.$inject = [];
	    function HouseWinlossController() {
	        var vm = this;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },

/***/ 111:
/*!****************************************************!*\
  !*** ./app/ng2-statistic/ng2-statistic.service.js ***!
  \****************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').service('ng2StatisticService', ng2StatisticService);
	
	    ng2StatisticService.$inject = ['templateSetting', 'universalSettings'];
	    function ng2StatisticService(templateSetting, universalSettings) {
	        var service = {
	            getTemplate: getTemplate,
	            getTemplateSetting: getTemplateSetting,
	            resolveProductPath: resolveProductPath,
	            resolveServiceUrl: resolveServiceUrl
	        };
	        return service;
	
	        function resolveProductPath(productName) {
	            if (productName == 'Live Casino' || productName == 'Casino') {
	                return 'casino';
	            }
	            return productName.replace(/\s+/g, '-').replace(/\-+/g, '-');
	        }
	
	        function resolveServiceUrl(productName, suffix) {
	            return 'api/house-win-loss-by-products/' + resolveProductPath(data.productName) + '/' + suffix;
	        }
	
	        function getTemplateSetting(productName) {
	            var productSetting = templateSetting[productName];
	            if (!angular.isUndefined(productSetting)) {
	                return productSetting;
	            }
	
	            return universalSettings.settings;
	        }
	
	        function getTemplate(data, type) {
	            if (type === 'product') {
	                return {
	                    templateUrl: 'app/house-win-loss/shared/fanex-grid-with-title.html',
	                    controller: 'ProductController',
	                    service: 'productService'
	                };
	            }
	
	            var productSetting = getTemplateSetting(data.productName);
	            if (angular.isUndefined(productSetting)) {
	                return undefined;
	            }
	
	            var template = productSetting[type];
	            if (angular.isUndefined(template)) {
	                return undefined;
	            }
	
	            var templateUrl = template.templateUrl;
	            if (angular.isFunction(templateUrl)) {
	                templateUrl = templateUrl(data);
	            }
	
	            var controller = template.controller;
	            if (angular.isFunction(controller)) {
	                controller = controller(data);
	            }
	
	            var service = template.service;
	            if (angular.isFunction(service)) {
	                service = service(data);
	            }
	
	            return {
	                templateUrl: templateUrl,
	                controller: controller,
	                service: service
	            };
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 112:
/*!************************************************************!*\
  !*** ./app/ng2-statistic/breadcrumb/breadcrumb.service.js ***!
  \************************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('breadcrumbService', breadcrumbService);
	
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

/***/ 113:
/*!************************************************************!*\
  !*** ./app/ng2-statistic/breadcrumb/live-title.service.js ***!
  \************************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('liveTitleService', liveTitleService);
	
	    liveTitleService.$inject = [];
	    function liveTitleService() {
	
	        var service = {
	            getProductTitle: getProductTitle,
	            getSportTypeTitle: getSportTypeTitle,
	            getSiteTitle: getSiteTitle,
	            getProductNumberGameTitle: getProductNumberGameTitle,
	            getMatchDetailTitle: getMatchDetailTitle
	        };
	        return service;
	
	        function getLiveText(isLive) {
	            return ' "' + (isLive ? 'Live' : 'Non-Live') + '" ';
	        }
	
	        function getSiteText(site) {
	            return '| ' + site + ' Site';
	        }
	
	        function getProductTitle(data) {
	            return data.productName + getLiveText(data.isLive);
	        }
	
	        function getProductNumberGameTitle(data) {
	            return data.isLive == undefined ? data.productName : data.productName + getLiveText(data.isLive);
	        }
	
	        function getSportTypeTitle(data) {
	            return data.sportTypeName + getLiveText(data.isLive);
	        }
	
	        function getSiteTitle(data) {
	            return data.betTypeName + getLiveText(data.isLive) + getSiteText(data.site);
	        }
	
	        function getMatchDetailTitle(data) {
	            return data.betTypeName + getLiveText(data.isLive);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 114:
/*!*******************************************************!*\
  !*** ./app/ng2-statistic/breadcrumb/title.service.js ***!
  \*******************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('titleService', titleService);
	
	    titleService.$inject = [];
	    function titleService() {
	        var productWinLossReport = 'Product Win/Loss Report';
	
	        var service = {
	            getMainTitle: getMainTitle,
	            getProductTitle: getProductTitle,
	            getProductLiveNonLiveTitle: getProductLiveNonLiveTitle,
	            getCasinoProductTitle: getCasinoProductTitle,
	            getSportTypeTitle: getSportTypeTitle,
	            getSiteTitle: getSiteTitle,
	            getMatchDetailTitle: getMatchDetailTitle
	        };
	        return service;
	
	        function getSiteText(site) {
	            return '| ' + (site == undefined ? "ALL" : site) + ' Site';
	        }
	
	        function getMainTitle(data) {
	            return 'Main';
	        }
	
	        function getProductTitle(data) {
	            return data.productName;
	        }
	
	        function getProductLiveNonLiveTitle(data, isLast) {
	            return isLast ? data.productName + ' Live/Non-Live ' : data.productName;
	        }
	
	        function getCasinoProductTitle(data) {
	            return data.casinoProductName;
	        }
	
	        function getSportTypeTitle(data) {
	            return data.sportTypeName;
	        }
	
	        function getSiteTitle(data) {
	            return data.betTypeName + ' ' + getSiteText(data.site);
	        }
	
	        function getMatchDetailTitle(data) {
	            return data.betTypeName;
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 115:
/*!******************************************************!*\
  !*** ./app/ng2-statistic/filter/filter.directive.js ***!
  \******************************************************/
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(/*! moment */ 5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').directive('napFilter', napFilter);
	
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
	
	    controller.$inject = ['$scope', '$rootScope', 'config'];
	    function controller($scope, $rootScope, config) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.currentLevel = 0;
	        vm.normalMode = true;
	        vm.today = config.today;
	        vm.yesterday = config.yesterday;
	        vm.date = config.today;
	        vm.startDate = _moment2.default.utc(config.yesterday).startOf('month');
	        vm.endDate = _moment2.default.utc(config.yesterday);
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

/***/ 116:
/*!*******************************************************************!*\
  !*** ./app/ng2-statistic/soccer/soccer-major-minor.controller.js ***!
  \*******************************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').controller('SoccerMajorMinorController', SoccerMajorMinorController);
	
	    SoccerMajorMinorController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerConstants', 'showHideColumnService'];
	    function SoccerMajorMinorController($scope, $element, fanexGridService, soccerConstants, showHideColumnService) {
	        var pane = $scope.pane;
	        var showHideColumnBuilder = new showHideColumnService(pane);
	        var tab = $scope.tab;
	        var gridElements = $element.find('.freegrid');
	        var majorMinorGridElement = angular.element(gridElements[0]);
	        $scope.generate = generate;
	        $scope.show = showHideColumnBuilder.toggle;
	        $scope.generateSoccerLiveNonLiveBetTypePane = generateSoccerLiveNonLiveBetTypePane;
	        pane.data.isLive = pane.data.soccerLiveNonLive == "Soccer Non-Live" ? soccerConstants.NonLive : soccerConstants.Live;
	
	        function generate() {
	            pane.service.getData(pane.data).then(function (data) {
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
	            var data = {
	                betTypeNameMajorMinor: betTypeNameMajorMinor,
	                sportTypeName: betTypeNameMajorMinor
	            };
	            angular.extend(data, pane.data);
	
	            tab.goForward('soccerBetType', data);
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 117:
/*!****************************************************************!*\
  !*** ./app/ng2-statistic/soccer/soccer-major-minor.service.js ***!
  \****************************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('soccerMajorMinorService', soccerMajorMinorService);
	
	    soccerMajorMinorService.$inject = ['$http', 'httpResponseService', 'soccerConstants'];
	    function soccerMajorMinorService($http, httpResponseService, soccerConstants) {
	        var service = {
	            getTitle: getTitleWhenMajorMinor,
	            getData: getData,
	            exportExcel: exportExcel
	        };
	
	        return service;
	
	        function getTitleWhenMajorMinor(data) {
	            if (data.isLive == soccerConstants.LiveNonLive) {
	                return data.productName + ' ' + "MAJOR/MINOR";
	            } else {
	                var liveNonLive = data.isLive == soccerConstants.Live ? "LIVE" : "NON-LIVE";
	
	                return data.productName + ' ' + liveNonLive;
	            }
	        }
	
	        function getData(data) {
	            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title
	            };
	            angular.extend(httpData, data);
	            return $http.post('api/house-win-loss-by-products/soccer/major-minor/excel', httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 118:
/*!*****************************************************!*\
  !*** ./app/ng2-statistic/soccer/soccer.constant.js ***!
  \*****************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
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
	
	    angular.module('app.NG2Statistic').constant('soccerConstants', soccerConstants);
	})(_angular2.default);

/***/ },

/***/ 119:
/*!*************************************************!*\
  !*** ./app/ng2-statistic/tab/pane.directive.js ***!
  \*************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').directive('napPane', napPane);
	
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

/***/ 120:
/*!***********************************************!*\
  !*** ./app/ng2-statistic/tab/pane.service.js ***!
  \***********************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector', 'ng2StatisticService', 'showHideColumnService'];
	    function napPane($log, $compile, $injector, ng2StatisticService, showHideColumnService) {
	        function Pane(level, data) {
	            this.level = level;
	            this.data = data;
	            this.$scope = undefined;
	            this.$element = undefined;
	            this.generate = generate;
	            this.show = show;
	            this.compileAll = compileAll;
	            this.compileLinks = compileLinks;
	            this.compileDrilldown = compileDrilldown;
	            this.getFileName = getFileName;
	
	            if (angular.isUndefined(this.level) || angular.isUndefined(this.data)) {
	                $log.error('Invalid pane');
	                return;
	            }
	
	            var template = ng2StatisticService.getTemplate(data, level);
	            this.templateUrl = template.templateUrl;
	            this.controller = template.controller;
	            this.service = $injector.get(template.service);
	
	            function generate() {
	                this.$scope.generate();
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

/***/ },

/***/ 121:
/*!************************************************!*\
  !*** ./app/ng2-statistic/tab/tab.directive.js ***!
  \************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').directive('napTab', napTab);
	
	    napTab.$inject = ['napPane'];
	    function napTab(Pane) {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                panes: '='
	            },
	            templateUrl: 'app/house-win-loss/tab/tab.directive.html',
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
	                var mainPane = new Pane('product', data);
	                tab.addPane(mainPane);
	            } else {
	                var activePane = tab.getActivePane();
	                angular.extend(activePane.data, data);
	                activePane.generate();
	            }
	        });
	
	        $scope.$on('nap-filter-switch', function (event) {
	            tab.panes = [];
	        });
	    }
	})(_angular2.default);

/***/ },

/***/ 122:
/*!**********************************************!*\
  !*** ./app/ng2-statistic/tab/tab.service.js ***!
  \**********************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.NG2Statistic').factory('napTab', napTab);
	
	    napTab.$inject = ['$rootScope', 'breadcrumbService', 'napPane'];
	    function napTab($rootScope, breadcrumbService, Pane) {
	        function Tab(panes) {
	            this.panes = angular.isDefined(panes) ? panes : [];
	            this.addPane = addPane;
	            this.getActivePane = getActivePane;
	            this.getPreviousPane = getPreviousPane;
	            this.goBack = goBack;
	            this.goForward = goForward;
	            this.generateBreadcrumbList = generateBreadcrumbList;
	            this.generateBreadcrumbHtml = generateBreadcrumbHtml;
	            this.generateBreadcrumbText = generateBreadcrumbText;
	
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
	                var activePane = this.getActivePane();
	                this.panes = this.panes.slice(0, index + 1);
	                var newActivePane = this.getActivePane();
	                if (angular.isFunction(newActivePane.$scope.show)) {
	                    newActivePane.$scope.show();
	                }
	
	                activePane = this.panes[index];
	                var dateRange = {
	                    normalMode: activePane.data.normalMode,
	                    startDate: activePane.data.startDate,
	                    endDate: activePane.data.endDate
	                };
	                $rootScope.$broadcast('nap-filter-date', dateRange);
	            }
	
	            function goForward(level, data) {
	                var activePane = this.getActivePane();
	                var pane = new Pane(level, data);
	                this.addPane(pane);
	            }
	
	            function generateBreadcrumbList() {
	                var list = [];
	                for (var i = 0; i < this.panes.length; i++) {
	                    var pane = this.panes[i];
	                    var isLast = i === this.panes.length - 1;
	                    var title = pane.service.getTitle(pane.data, isLast);
	                    list.push(title);
	                }
	
	                return list;
	            }
	
	            function generateBreadcrumbHtml() {
	                var list = this.generateBreadcrumbList();
	                return breadcrumbService.generateHtml(list);
	            }
	
	            function generateBreadcrumbText() {
	                var list = this.generateBreadcrumbList();
	                return breadcrumbService.generateText(list);
	            }
	        }
	
	        return Tab;
	    }
	})(_angular2.default);

/***/ }

});
//# sourceMappingURL=ng2-statistic.chunk.js.map