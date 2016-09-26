webpackJsonp([4],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(78);
	__webpack_require__(79);
	__webpack_require__(80);
	__webpack_require__(81);
	__webpack_require__(82);
	__webpack_require__(83);
	__webpack_require__(84);
	__webpack_require__(85);
	__webpack_require__(86);
	__webpack_require__(87);
	__webpack_require__(88);
	__webpack_require__(89);
	__webpack_require__(90);
	__webpack_require__(91);
	__webpack_require__(92);
	__webpack_require__(93);
	module.exports = __webpack_require__(94);


/***/ },

/***/ 78:
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
	                templateUrl: 'app/ng2-statistic/ng2-statistic.html',
	                controller: 'NG2StatisticController',
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

/***/ 79:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp', ['app.core', 'fanex.dropdowntree']);
	})(_angular2.default);

/***/ },

/***/ 80:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').controller('NG2StatisticController', NG2StatisticController);
	
	    NG2StatisticController.$inject = [];
	    function NG2StatisticController() {
	        var vm = this;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },

/***/ 81:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('breadcrumbService', breadcrumbService);
	
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

/***/ 82:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('titleService', titleService);
	
	    titleService.$inject = [];
	    function titleService() {
	        var gameStatisticReport = ' Game Statistic Report ';
	
	        var service = {
	            getGrandTotalTitle: getGrandTotalTitle,
	            getReportMainTitle: getReportMainTitle,
	            getReportbyCrurrencyTitle: getReportbyCrurrencyTitle
	        };
	        return service;
	
	        function getReportbyTitlle(data) {
	            switch (data.reportType) {
	                case "daily":
	                    return "Daily";
	                case "username":
	                    return "Username";
	                case "bettype":
	                    return "Bet Type";
	            }
	        }
	
	        function getReportMainTitle(data) {
	            return getReportbyTitlle(data) + gameStatisticReport + "From " + data.startDate.format('ll') + " To " + data.endDate.format('ll');
	        }
	
	        function getReportbyCrurrencyTitle(data) {
	            return data.reportType + gameStatisticReport + "On " + data.startDate.format('ll');
	        }
	
	        function getGrandTotalTitle() {
	            return "GRAND TOTAL BY CURRENCY";
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 83:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(7);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').controller('CommonController', CommonController);
	
	    CommonController.$inject = ['$element', '$scope', 'fanexGridService'];
	    function CommonController($element, $scope, fanexGridService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.generateCurrencyReport = generateCurrencyReport;
	        $scope.generateGrandtotalReport = generateGrandtotalReport;
	
	        function generateCurrencyReport() {
	            var data = { drilldownType: "Currency" };
	            pane.data.isDrilldown = true;
	
	            angular.extend(data, pane.data);
	            tab.goForward(data);
	        }
	
	        function generateGrandtotalReport() {
	            var data = { drilldownType: "Grandtotal" };
	            pane.data.isDrilldown = true;
	
	            angular.extend(data, pane.data);
	            tab.goForward(data);
	        }
	
	        function generate() {
	            pane.service.getData(pane.data).then(function (data) {
	                checkDrilldown(data);
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
	            gridElement.fanexGrid(data);
	        }
	
	        function checkDrilldown(data) {
	            if (!pane.data.isDrilldown) {
	                createLinks(data);
	            }
	        }
	
	        function createLinks(data) {
	
	            for (var i = 0; i < data.bodyRows.length; i++) {
	                var productColumn = data.bodyRows[i].Columns[0];
	                var productId = productColumn.CustomAttr;
	                var productName = productColumn.Value;
	                productColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
	            }
	
	            var grandTotalColumn = data.footerRows[0].Columns[0];
	            grandTotalColumn.Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + grandTotalColumn.Value + '</a>';
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 84:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('commonService', commonService);
	
	    commonService.$inject = ['$http', 'httpResponseService', 'titleService'];
	    function commonService($http, httpResponseService, titleService) {
	
	        var service = {
	            getTitle: titleService.getReportMainTitle,
	            getData: getData,
	            exportExcel: exportExcel
	        };
	        return service;
	
	        function getData(data) {
	            var httpData = {
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                normalMode: data.normalMode,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency
	            };
	
	            var httpDatatemp = {
	                startDate: data.endDate,
	                endDate: data.endDate,
	                casinoType: 2,
	                normalMode: data.true
	            };
	            var urltemp = 'api/house-win-loss-by-products/casino/product';
	            var url = 'api/ng2-statistic/report/' + data.reportType;
	            return $http.post(urltemp, httpDatatemp).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title,
	                startDate: data.startDate,
	                endDate: data.endDate,
	                normalMode: data.normalMode,
	                reportType: data.reportType,
	                sportbetType: data.sportbetType,
	                username: data.username,
	                currency: data.currency
	            };
	            var url = 'api/ng2-statistic/report/' + data.reportType + '/excel';
	
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 85:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(7);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').controller('CurrencyController', CurrencyController);
	
	    CurrencyController.$inject = ['$element', '$scope', 'fanexGridService'];
	    function CurrencyController($element, $scope, fanexGridService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	
	        function generate() {
	            pane.service.getData(pane.data).then(function (data) {
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
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 86:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('currencyService', currencyService);
	
	    currencyService.$inject = ['$http', 'httpResponseService', 'titleService'];
	    function currencyService($http, httpResponseService, titleService) {
	
	        var service = {
	            getTitle: titleService.getReportbyCrurrencyTitle,
	            getData: getData,
	            exportExcel: exportExcel
	        };
	        return service;
	
	        function getData(data) {
	            var httpData = {
	                startDate: data.startDate,
	                endDate: data.endDate,
	                normalMode: data.normalMode,
	                reportType: data.reportType,
	                sportbetType: data.sportbetType,
	                username: data.username,
	                currency: data.currency
	            };
	            var httpDatatemp = {
	                startDate: data.endDate,
	                endDate: data.endDate,
	                casinoType: 2,
	                normalMode: data.true
	            };
	            var url = 'api/ng2-statistic/report';
	            return $http.post('api/house-win-loss-by-products/casino/product', httpDatatemp).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title,
	                startDate: data.startDate,
	                endDate: data.endDate,
	                normalMode: data.normalMode,
	                reportType: data.reportType,
	                sportbetType: data.sportbetType,
	                username: data.username,
	                currency: data.currency
	            };
	            var httpDatatemp = {
	                title: title,
	                startDate: data.endDate,
	                endDate: data.endDate,
	                casinoType: 2,
	                normalMode: data.true
	            };
	            return $http.post('api/house-win-loss-by-products/casino/product/excel', httpDatatemp, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 87:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').directive('napFilter', napFilter);
	
	    function napFilter() {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                ngModel: '='
	            },
	            templateUrl: 'app/ng2-statistic/filter/filter.directive.html',
	            replace: true,
	            controller: controller,
	            controllerAs: 'vm',
	            bindToController: true
	        };
	        return directive;
	    }
	
	    controller.$inject = ['$scope', '$rootScope', 'config', 'filterService'];
	    function controller($scope, $rootScope, config, filterService) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.minDate = (0, _moment2.default)("20130101", "YYYYMMDD");
	        vm.reportType = "daily";
	        vm.currentLevel = 0;
	        vm.normalMode = false;
	
	        vm.today = config.today;
	        vm.yesterday = config.yesterday;
	        vm.date = config.today;
	        vm.startDate = _moment2.default.utc(config.yesterday);
	        vm.endDate = _moment2.default.utc(config.yesterday);
	        var tab = $scope.tab;
	
	        vm.sportItems = [];
	        filterService.getSports().then(function (data) {
	            vm.sportSettings = {
	                hasFilter: false,
	                checkedAll: true,
	                idMember: "Id",
	                nameMember: "Name",
	                selectedMember: null,
	                dataMember: null,
	                childrenMember: "Children",
	                sourceData: data,
	                templateUrl: 'app/root/components/fanex-dropdowntree/fanex.dropdowntree.directive.template.html'
	            };
	        });
	
	        vm.sportTextSettings = {
	            CheckAll: "ALL",
	            CollapseExpanse: "Collapse/Expanse",
	            CollapseBranch: "Collapse/Expanse this branch",
	            NoItemChecked: "Select bet type",
	            ItemsSelected: "# selected",
	            NoData: "Select bet type"
	        };
	
	        vm.currencies = [];
	        filterService.getCurrencies().then(function (data) {
	            vm.currencies = data;
	            vm.currency = 1;
	        });
	
	        vm.generate = generate;
	        vm.todayClicked = todayClicked;
	        vm.yesterdayClicked = yesterdayClicked;
	        vm.viewNormalMode = viewNormalMode;
	        vm.viewHistoryMode = viewHistoryMode;
	        vm.getReportCriteria = getReportCriteria;
	        vm.updateDateRange = updateDateRange;
	
	        $scope.$on('nap-filter-date', function (event, data) {
	            updateDateRange(data);
	        });
	
	        vm.reportCriteria = {};
	
	        function generate() {
	            vm.reportCriteria = vm.getReportCriteria();
	            $rootScope.$broadcast('nap-filter-generate', vm.reportCriteria);
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
	
	        function getReportCriteria() {
	            var dateRange = getDateRange();
	            return {
	                reportType: vm.reportType,
	                isDrilldown: false,
	                normalMode: dateRange.normalMode,
	                startDate: dateRange.startDate,
	                endDate: dateRange.endDate,
	                username: vm.user == null ? " " : vm.user.title,
	                currency: vm.currency,
	                betType: getBetType(vm.sportItems)
	            };
	        }
	
	        function getBetType(sportItems) {
	            var betTypes = "";
	            for (var i = 0; i < sportItems.length; i++) {
	                betTypes = betTypes + sportItems[i].Id + ",";
	            }
	            return betTypes;
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
	            vm.reportType = dateRange.reportType;
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

/***/ 88:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('filterService', filterService);
	
	    filterService.$inject = ['$http', 'httpResponseService'];
	    function filterService($http, httpResponseService) {
	        var service = {
	            getCurrencies: getCurrencies,
	            getSports: getSports
	        };
	        return service;
	
	        function getCurrencies() {
	            var url = 'api/ng2-statistic/filter/currencies';
	            return $http.post(url, {}).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function getSports() {
	            var url = 'api/ng2-statistic/filter/sports';
	            return $http.post(url, {}).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 89:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(7);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').controller('GrandtotalController', GrandtotalController);
	
	    GrandtotalController.$inject = ['$element', '$scope', 'fanexGridService'];
	    function GrandtotalController($element, $scope, fanexGridService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	
	        function generate() {
	            pane.service.getData(pane.data).then(function (data) {
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
	            gridElement.fanexGrid(data);
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 90:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('grandtotalService', grandtotalService);
	
	    grandtotalService.$inject = ['$http', 'httpResponseService', 'titleService'];
	    function grandtotalService($http, httpResponseService, titleService) {
	
	        var service = {
	            getTitle: titleService.getGrandTotalTitle,
	            getData: getData,
	            exportExcel: exportExcel
	        };
	        return service;
	
	        function getData(data) {
	            var httpData = {
	                startDate: data.startDate,
	                endDate: data.endDate,
	                normalMode: data.normalMode,
	                reportType: data.reportType,
	                sportbetType: data.sportbetType,
	                username: data.username,
	                currency: data.currency
	            };
	            var httpDatatemp = {
	                startDate: data.endDate,
	                endDate: data.endDate,
	                casinoType: 2,
	                normalMode: data.true
	            };
	
	            var url = 'api/ng2-statistic/report';
	            return $http.post('api/house-win-loss-by-products/casino/product', httpDatatemp).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title,
	                startDate: data.startDate,
	                endDate: data.endDate,
	                normalMode: data.normalMode,
	                reportType: data.reportType,
	                sportbetType: data.sportbetType,
	                username: data.username,
	                currency: data.currency
	            };
	            var httpDatatemp = {
	                title: title,
	                startDate: data.endDate,
	                endDate: data.endDate,
	                casinoType: 2,
	                normalMode: data.true
	            };
	
	            return $http.post('api/house-win-loss-by-products/casino/product/excel', httpDatatemp, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 91:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').directive('napPane', napPane);
	
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

/***/ 92:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector'];
	    function napPane($log, $compile, $injector) {
	        function Pane(data) {
	
	            this.reportType = data.reportType;
	            this.isDrilldown = data.isDrilldown;
	            this.data = data;
	            var drilldownType = data.drilldownType;
	            this.$scope = undefined;
	            this.$element = undefined;
	            this.generate = generate;
	            this.show = show;
	            this.compileAll = compileAll;
	            this.compileLinks = compileLinks;
	            this.compileDrilldown = compileDrilldown;
	            this.getFileName = getFileName;
	
	            this.templateUrl = 'app/ng2-statistic/shared/fanex-grid-with-title.html';
	            this.controller = 'CommonController';
	            this.service = $injector.get('commonService');
	
	            function generate() {
	                this.$scope.generate();
	            }
	
	            function show() {
	                var gridElement = this.$element.find('.freegrid');
	                gridElement.fanexGrid('resizeGrid');
	            }
	
	            function getFileName() {
	                return 'NG2_Statistic_Report_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
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

/***/ 93:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').directive('napTab', napTab);
	
	    napTab.$inject = ['napPane'];
	    function napTab(Pane) {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                panes: '='
	            },
	            templateUrl: 'app/ng2-statistic/tab/tab.directive.html',
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
	            //if(tab.panes.length === 0){
	            //    var mainPane = new Pane(data);
	            //    tab.addPane(mainPane);
	            //} else {
	            //    var activePane = tab.getActivePane();
	            //    angular.extend(activePane.data, data);
	            //    activePane.generate();
	            //}
	            tab.panes = [];
	            var mainPane = new Pane(data);
	            tab.addPane(mainPane);
	        });
	
	        $scope.$on('nap-filter-switch', function (event) {
	            tab.panes = [];
	        });
	    }
	})(_angular2.default);

/***/ },

/***/ 94:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('napTab', napTab);
	
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
	                    endDate: activePane.data.endDate,
	                    reportType: activePane.data.reportType
	                };
	                $rootScope.$broadcast('nap-filter-date', dateRange);
	            }
	
	            function goForward(data) {
	                var activePane = this.getActivePane();
	                var pane = new Pane(data);
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