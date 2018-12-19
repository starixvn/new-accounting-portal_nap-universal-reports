webpackJsonp([2],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(170);
	__webpack_require__(171);
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
	module.exports = __webpack_require__(200);


/***/ },

/***/ 176:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    "use strict";
	
	    var templateSetting = {
	        "Main": {
	            mainView: "product",
	            product: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/basic-grid",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", type: "soccer-minor-sport-type", mainColumnText: "Sport Type", mainColumnWidth: 210 },
	                getTitleFunction: "getMainTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "SoccerBetTypeFullController",
	                service: "soccerMinorBetTypeService",
	                serviceBaseUrl: "api/house-win-loss-by-products/basic-grid",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", type: "soccer-minor-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270 },
	                getTitleFunction: "getSoccerMinorBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SportsbookMatchDetailController",
	                service: "sportsbookMatchDetailService",
	                serviceBaseUrl: function serviceBaseUrl(data) {
	                    return data.betType === 10 ? 'api/house-win-loss-by-products/soccer-minor/outright-match-detail' : 'api/house-win-loss-by-products/soccer-minor/match-detail';
	                },
	                mainParameters: { sheetName: "Soccer Minor Bet Types", sportType: 1 },
	                getTitleFunction: "getMatchDetailTitleLive"
	            },
	            site: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "SiteController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/basic-site-grid",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", sportType: 1, type: "soccer-minor-site" },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        }
	    };
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 177:
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
	
	    controller.$inject = ['$scope', '$rootScope', 'config', 'moment'];
	    function controller($scope, $rootScope, config, moment) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.minDate = moment("20110101", "YYYYMMDD");
	        vm.currentLevel = 0;
	        vm.accessDenied = modePermissions.length === 0 || productPermissions.length === 0;
	        vm.normalMode = modePermissions.indexOf("HouseWinLossByProducts_NormalMode") >= 0;
	        vm.showBothMode = modePermissions.indexOf("HouseWinLossByProducts_NormalMode") >= 0 && modePermissions.indexOf("HouseWinLossByProducts_HistoryMode") >= 0;
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
	        vm.dataMenuId = 370;
	        vm.legentTitle = 'Daily Win Loss (2h) Soccer Minor Bet Types Legend';
	
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

/***/ 178:
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
	                return 'Daily_Win_Loss_2h_Soccer_Minor_Bet_Types_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
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

/***/ 179:
/***/ function(module, exports) {

	'use strict';
	
	//import angular from "angular";
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').factory('soccerMinorBetTypeService', soccerMinorBetTypeService);
	
	    soccerMinorBetTypeService.$inject = ['$http', 'httpResponseService'];
	    function soccerMinorBetTypeService($http, httpResponseService) {
	        var service = {
	            getData: getData,
	            exportExcel: exportExcel
	        };
	
	        return service;
	
	        function getData(viewSetting, data, isLive) {
	            var httpData = {};
	            angular.extend(httpData, data);
	            angular.extend(httpData, viewSetting.mainParameters);
	            httpData.isLive = isLive;
	
	            var url = "api/house-win-loss-by-products/basic-grid";
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(viewSetting, data, fileName) {
	            var url = 'api/house-win-loss-by-products/soccer-minor/bet-type-full/excel';
	            var httpData = {};
	            angular.extend(httpData, data);
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(angular);

/***/ }

});
//# sourceMappingURL=daily-winloss-2h-soccer-minor.chunk.js.map