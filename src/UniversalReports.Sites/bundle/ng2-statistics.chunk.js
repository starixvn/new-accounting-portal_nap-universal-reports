webpackJsonp([4],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(209);
	__webpack_require__(210);
	__webpack_require__(211);
	__webpack_require__(212);
	__webpack_require__(213);
	__webpack_require__(214);
	__webpack_require__(215);
	__webpack_require__(216);
	__webpack_require__(217);
	__webpack_require__(218);
	__webpack_require__(219);
	__webpack_require__(220);
	__webpack_require__(221);
	__webpack_require__(222);
	module.exports = __webpack_require__(223);


/***/ },

/***/ 209:
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
	                templateUrl: 'app/ng2-statistics/ng2-statistics.html',
	                controller: 'NG2StatisticsController',
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

/***/ 210:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp', ['app.core', 'fanex.dropdowntree']);
	})(_angular2.default);

/***/ },

/***/ 211:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').controller('NG2StatisticsController', NG2StatisticsController);
	
	    NG2StatisticsController.$inject = [];
	    function NG2StatisticsController() {
	        var vm = this;
	        vm.xxx = 10;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },

/***/ 212:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(116);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').controller('BettypeController', BettypeController);
	
	    BettypeController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog', '$injector', 'grandtotalService'];
	    function BettypeController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector, grandtotalService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.generateCurrencyReport = generateCurrencyReport;
	        $scope.generateGrandtotalReport = generateGrandtotalReport;
	
	        function generateCurrencyReport(currency, betTypeId) {
	
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                drilldownType: "Currency",
	                currency: pane.data.currency === -1 ? -1 : currency,
	                currencyName: pane.data.currencyName,
	                betType: betTypeId,
	                isDrilldown: true
	            });
	
	            tab.goForward(data);
	        }
	
	        function generateGrandtotalReport() {
	            var model = {
	                drilldownType: "Grandtotal",
	                currency: pane.data.currency,
	                currencyName: pane.data.currencyName,
	                isDrilldown: true,
	                endDate: pane.data.endDate,
	                startDate: pane.data.startDate,
	                betType: pane.data.betType,
	                username: pane.data.username,
	                balanceUpDate: pane.data.balanceUpDate
	            };
	            grandtotalService.getData(model).then(function (data) {
	                renderPopup(model, data);
	            });
	        }
	
	        function generate() {
	            pane.service.getData(pane.data).then(function (data) {
	                createLinks(data);
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
	            var sortOptions = {
	                serverSortFunction: generateSort
	            };
	
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.titleInfo = titleInfo;
	            data.sortOption = sortOptions;
	            data.gridHeight = 575;
	            data.fullHeight = false;
	            gridElement.fanexGrid(data);
	        }
	
	        function generateSort(sortColumnName, sortDirection) {
	            pane.data.sortColumnName = sortColumnName;
	            pane.data.sortDirection = sortDirection;
	            pane.service.getDataSort(pane.data).then(function (data) {
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function createLinks(data) {
	            if (!pane.data.isDrilldown) {
	
	                for (var i = 0; i < data.bodyRows.length; i++) {
	                    var row = data.bodyRows[i];
	                    if (row.Columns.length > 1) {
	                        var currencyColumn = row.Columns.length === 12 ? row.Columns[3] : row.Columns[2];
	                        var betTypeColumn = row.Columns.length === 12 ? row.Columns[2] : row.Columns[1];
	                        var currencyId = currencyColumn.CustomAttr;
	                        var currencyName = currencyColumn.Value;
	                        var betTypeId = betTypeColumn.CustomAttr;
	                        currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(' + currencyId + ',\'' + betTypeId + '\')">' + currencyName + '</a>';
	                    }
	                }
	                data.footerRows[0].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + data.footerRows[0].Columns[0].Value + '</a>';
	            }
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	
	        function exportExcelGrandTotal() {
	            var title = grandtotalService.getTitle(pane.data);
	            grandtotalService.exportExcel(title, pane.data, pane.getFileName());
	        }
	
	        function renderPopup(model, data) {
	
	            var titleInfo = {
	                text: grandtotalService.getTitle(model),
	                showExcelButton: true,
	                exportExcelFunction: exportExcelGrandTotal
	            };
	
	            data.titleInfo = titleInfo;
	            ngDialog.open({
	                template: 'templateId',
	                plain: false,
	                width: 1245,
	                height: 650,
	                closeByDocument: false,
	                data: data
	            });
	
	            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
	                data.gridHeight = 575;
	                data.fullHeight = false;
	                $('#myGrid').fanexGrid(data);
	            });
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 213:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('breadcrumbService', breadcrumbService);
	
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

/***/ 214:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('titleService', titleService);
	
	    titleService.$inject = [];
	    function titleService() {
	        var gameStatisticReport = ' Game Statistics Report ';
	
	        var service = {
	            getTitleReport: getTitleReport,
	            getGrandTotalTitle: getGrandTotalTitle
	        };
	        return service;
	
	        function getTitleReport(model) {
	            return model.data.isDrilldown === true ? getTitleDrilldown(model.data) : getReportMainTitle(model.data);
	        }
	
	        function getTitleDrilldown(data) {
	
	            return data.drilldownType === "Currency" ? getReportbyCrurrencyTitle(data) : getGrandTotalTitle(data);
	        }
	
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
	
	            return getReportbyTitlle(data) + gameStatisticReport + "From " + data.startDate.format('ll') + " To " + data.endDate.format('ll') + " " + getCurrencyName(data);
	        }
	
	        function getReportbyCrurrencyTitle(data) {
	
	            return getReportbyTitlle(data) + gameStatisticReport + "On " + data.startDate.format('ll') + " BY CURRENCY " + getCurrencyName(data);
	        }
	
	        function getGrandTotalTitle(data) {
	
	            return "Grand Total By Currency From " + data.startDate.format('ll') + " To " + data.endDate.format('ll') + " " + getCurrencyName(data);
	        }
	
	        function getCurrencyName(data) {
	            return data.currency === 0 || data.currencyName.toUpperCase() === 'ALL' ? "(Original currency)" : "(" + data.currencyName + ")";
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 215:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(116);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').controller('CommonController', CommonController);
	
	    CommonController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog', '$injector', 'grandtotalService'];
	    function CommonController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector, grandtotalService) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.generateCurrencyReport = generateCurrencyReport;
	        $scope.generateGrandtotalReport = generateGrandtotalReport;
	
	        function generateCurrencyReport(currency, dateCurrency) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                drilldownType: "Currency",
	                currency: pane.data.currency === -1 ? -1 : currency,
	                currencyName: pane.data.currencyName,
	                startDate: _moment2.default.utc(dateCurrency).startOf('day'),
	                endDate: _moment2.default.utc(dateCurrency).startOf('day'),
	                isDrilldown: true
	            });
	            tab.goForward(data);
	        }
	
	        function generateGrandtotalReport() {
	
	            var model = {
	                drilldownType: "Grandtotal",
	                currency: pane.data.currency,
	                currencyName: pane.data.currencyName,
	                isDrilldown: true,
	                endDate: pane.data.endDate,
	                startDate: pane.data.startDate,
	                betType: pane.data.betType,
	                username: pane.data.username,
	                balanceUpDate: pane.data.balanceUpDate
	            };
	
	            grandtotalService.getData(model).then(function (data) {
	                renderPopup(model, data);
	            });
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
	            var sortOptions = {
	                serverSortFunction: generateSort
	            };
	            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
	            data.titleInfo = titleInfo;
	            data.pagerOption = {
	                itemsPerPage: 50,
	                currentPage: 0,
	                itemsPerPageArray: [50, 100, 200, 500],
	                totalItem: data.bodyRows.length
	            };
	            data.sortOption = sortOptions;
	            data.gridHeight = 575;
	            data.fullHeight = false;
	            gridElement.fanexGrid(data);
	        }
	
	        function checkDrilldown(data) {
	            if (!pane.data.isDrilldown) {
	                createLinks(data);
	            }
	        }
	
	        function generateSort(sortColumnName, sortDirection) {
	            pane.data.sortColumnName = sortColumnName;
	            pane.data.sortDirection = sortDirection;
	            pane.service.getDataSort(pane.data).then(function (data) {
	                checkDrilldown(data);
	                renderGrid(data);
	                pane.compileAll();
	            });
	        }
	
	        function createLinks(data) {
	            if (pane.data.reportType !== "username") {
	                for (var i = 0; i < data.bodyRows.length; i++) {
	                    var row = data.bodyRows[i];
	                    var currencyColumn = row.Columns.length === 12 ? row.Columns[3] : row.Columns[2];
	                    var date = row.Columns.length === 12 ? row.Columns[0].Value : row.Columns[1].CustomAttr;
	
	                    currencyColumn.Value = '<a class="drill-down" href data-nap-click="generateCurrencyReport(\'' + currencyColumn.CustomAttr + '\',\'' + date + '\')">' + currencyColumn.Value + '</a>';
	                }
	            }
	
	            data.footerRows[0].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateGrandtotalReport()">' + data.footerRows[0].Columns[0].Value + '</a>';
	        }
	
	        function exportExcel() {
	            var title = tab.generateBreadcrumbText();
	            pane.service.exportExcel(title, pane.data, pane.getFileName());
	        }
	
	        function exportExcelGrandTotal() {
	            var title = grandtotalService.getTitle(pane.data);
	            grandtotalService.exportExcel(title, pane.data, pane.getFileName());
	        }
	
	        function renderPopup(model, data) {
	
	            var titleInfo = {
	                text: grandtotalService.getTitle(model),
	                showExcelButton: true,
	                exportExcelFunction: exportExcelGrandTotal
	            };
	
	            data.titleInfo = titleInfo;
	            ngDialog.open({
	                template: 'templateId',
	                plain: false,
	                width: 1245,
	                height: 650,
	                closeByDocument: false,
	                data: data
	            });
	
	            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
	                data.gridHeight = 575;
	                data.fullHeight = false;
	                $('#myGrid').fanexGrid(data);
	            });
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 216:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('commonService', commonService);
	
	    commonService.$inject = ['$http', 'httpResponseService', 'titleService'];
	    function commonService($http, httpResponseService, titleService) {
	
	        var service = {
	            getTitle: titleService.getTitleReport,
	            getData: getData,
	            getDataSort: getDataSort,
	            exportExcel: exportExcel
	        };
	        return service;
	
	        function getData(data) {
	            var httpData = {
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency,
	                moveBetsDay: data.balanceUpDate,
	                isDrilldown: data.isDrilldown
	            };
	            var url = 'api/ng2-statistics/' + data.reportType;
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function getDataSort(data) {
	            var httpData = {
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency,
	                moveBetsDay: data.balanceUpDate,
	                isDrilldown: data.isDrilldown,
	                sortColumnName: data.sortColumnName,
	                sortDirection: data.sortDirection
	            };
	            var url = 'api/ng2-statistics/' + data.reportType + "/sort";
	
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title,
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency,
	                moveBetsDay: data.balanceUpDate,
	                isDrilldown: data.isDrilldown,
	                sortColumnName: data.sortColumnName,
	                sortDirection: data.sortDirection
	            };
	            var url = 'api/ng2-statistics/' + data.reportType + '/excel';
	
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 217:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _moment = __webpack_require__(5);
	
	var _moment2 = _interopRequireDefault(_moment);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').directive('napFilter', napFilter);
	
	    function napFilter() {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                ngModel: '='
	            },
	            templateUrl: 'app/ng2-statistics/filter/filter.directive.html',
	            replace: true,
	            controller: controller,
	            controllerAs: 'vm',
	            bindToController: true
	        };
	        return directive;
	    }
	
	    controller.$inject = ['$scope', '$rootScope', 'config', 'filterService', 'ngDialog'];
	    function controller($scope, $rootScope, config, filterService, ngDialog) {
	        /*jshint validthis: true */
	        var vm = this;
	        vm.minDate = (0, _moment2.default)("20161101", "YYYYMMDD");
	        vm.reportType = "daily";
	        vm.currentLevel = 0;
	        vm.normalMode = true;
	        vm.today = config.today;
	        vm.yesterday = config.yesterday;
	        vm.date = config.today;
	        vm.startDate = _moment2.default.utc(config.yesterday);
	        vm.endDate = _moment2.default.utc(config.yesterday);
	        vm.balanceUpDate = config.balanceUpDate;
	        vm.sportItems = [];
	        vm.user = undefined;
	        filterService.getSports().then(function (data) {
	            generateDropdown(data);
	        });
	
	        vm.sportTextSettings = {
	            CheckAll: "ALL",
	            CollapseExpanse: "Collapse/Expanse",
	            CollapseBranch: "Collapse/Expanse this branch",
	            NoItemChecked: "Select options",
	            ItemsSelected: "# selected",
	            NoData: "Select options",
	            AllItemsSelected: "All"
	        };
	
	        vm.currencies = [];
	        filterService.getCurrencies().then(function (data) {
	            generateCurrency(data);
	        });
	
	        vm.generate = generate;
	        vm.todayClicked = todayClicked;
	        vm.yesterdayClicked = yesterdayClicked;
	        vm.viewNormalMode = viewNormalMode;
	        vm.viewHistoryMode = viewHistoryMode;
	        vm.getReportCriteria = getReportCriteria;
	        vm.updateDateRange = updateDateRange;
	
	        function generateCurrency(data) {
	            vm.currencies = data;
	            vm.currency = data[1];
	        }
	
	        function generateDropdown(data) {
	            vm.sportSettings = {
	                hasFilter: false,
	                collapsedAll: true,
	                checkedAll: true,
	                idMember: "Id",
	                nameMember: "Name",
	                selectedMember: null,
	                dataMember: null,
	                childrenMember: "Children",
	                sourceData: data,
	                templateUrl: 'app/root/components/fanex-dropdowntree/fanex.dropdowntree.directive.template.html'
	            };
	        }
	
	        vm.reportCriteria = {};
	
	        function generate() {
	            $('.ngdialog-close').click();
	            vm.reportCriteria = vm.getReportCriteria();
	            if (validDateRange(vm.reportCriteria.startDate, vm.reportCriteria.endDate) && validbetType(vm.reportCriteria.betType)) {
	                $rootScope.$broadcast('nap-filter-generate', vm.reportCriteria);
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
	            vm.startDate = vm.yesterday;
	            vm.endDate = vm.yesterday;
	            $('.filter-note').css('display', 'block');
	            resetFilter();
	        }
	
	        function viewHistoryMode() {
	            vm.normalMode = false;
	            vm.startDate = vm.yesterday;
	            vm.endDate = vm.yesterday;
	            $scope.$broadcast('nap-filter-switch-history', "yesterday");
	            $('.filter-note').css('display', 'none');
	            resetFilter();
	        }
	
	        function resetFilter() {
	            generateCurrency(vm.currencies);
	            generateDropdown(vm.sportSettings.sourceData);
	            vm.reportType = "daily";
	            if (vm.user !== undefined) {
	                vm.user.title = "";
	            }
	            $('.ngdialog-close').click();
	            $rootScope.$broadcast('nap-filter-switch');
	            $scope.$broadcast('angucomplete-alt:clearInput');
	        }
	
	        function getReportCriteria() {
	            var dateRange = getDateRange();
	            return {
	                reportType: vm.reportType,
	                isDrilldown: false,
	                normalMode: dateRange.normalMode,
	                startDate: dateRange.startDate,
	                endDate: dateRange.endDate,
	                username: vm.user === undefined ? "" : getUserName(),
	                currency: vm.currency.Id,
	                currencyName: vm.currency.Name,
	                balanceUpDate: vm.balanceUpDate,
	                betType: getBetType(vm.sportItems)
	            };
	        }
	
	        function getUserName() {
	
	            return vm.user.title !== undefined ? vm.user.title : vm.user.originalObject;
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
	
	        function validbetType(betType) {
	
	            if (betType === "") {
	                var contentMsg = "Please select at least one bet type!";
	                showErrorMsg(contentMsg);
	                return false;
	            } else {
	                return true;
	            }
	        }
	
	        function validDateRange(fromDate, toDate) {
	            var isValidRange = toDate.diff(fromDate, 'years') <= 1;
	
	            if (isValidRange) {
	                return true;
	            } else {
	                var contentMsg = "Date range should not exceed 1 year";
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

/***/ 218:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('filterService', filterService);
	
	    filterService.$inject = ['$http', 'httpResponseService'];
	    function filterService($http, httpResponseService) {
	        var service = {
	            getCurrencies: getCurrencies,
	            getSports: getSports
	        };
	        return service;
	
	        function getCurrencies() {
	            var url = 'api/ng2-statistics/filter/currencies';
	            return $http.post(url, {}).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function getSports() {
	            var url = 'api/ng2-statistics/filter/sports';
	            return $http.post(url, {}).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 219:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('grandtotalService', grandtotalService);
	
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
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency,
	                moveBetsDay: data.balanceUpDate,
	                isDrilldown: data.isDrilldown
	            };
	
	            var url = 'api/ng2-statistics/grandtotal';
	            return $http.post(url, httpData).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	
	        function exportExcel(title, data, fileName) {
	            var httpData = {
	                title: title,
	                fromDate: data.startDate,
	                toDate: data.endDate,
	                betType: data.betType,
	                username: data.username,
	                currency: data.currency,
	                moveBetsDay: data.balanceUpDate,
	                isDrilldown: true
	            };
	
	            var url = 'api/ng2-statistics/grandtotal/excel';
	
	            return $http.post(url, httpData, { responseType: "arraybuffer" }).then(function (response) {
	                httpResponseService.saveExcelFile(response.data, fileName);
	            }).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 220:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').directive('napPane', napPane);
	
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

/***/ 221:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector'];
	    function napPane($log, $compile, $injector) {
	        function Pane(data) {
	
	            this.data = data;
	            this.$scope = undefined;
	            this.$element = undefined;
	            this.generate = generate;
	            this.show = show;
	            this.compileAll = compileAll;
	            this.compileLinks = compileLinks;
	            this.compileDrilldown = compileDrilldown;
	            this.getFileName = getFileName;
	
	            this.templateUrl = 'app/ng2-statistics/shared/fanex-grid-with-title.html';
	            this.controller = getController(data.reportType);
	            this.service = $injector.get("commonService");
	
	            function getController(data) {
	                return data === "bettype" ? 'BettypeController' : 'CommonController';
	            }
	
	            function generate() {
	                this.$scope.generate();
	            }
	
	            function show() {
	                var gridElement = this.$element.find('.freegrid');
	                gridElement.fanexGrid('resizeGrid');
	            }
	
	            function getFileName() {
	                return 'NG2_Statistics_Report_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
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

/***/ 222:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').directive('napTab', napTab);
	
	    napTab.$inject = ['napPane'];
	    function napTab(Pane) {
	        var directive = {
	            restrict: 'EA',
	            scope: {
	                panes: '='
	            },
	            templateUrl: 'app/ng2-statistics/tab/tab.directive.html',
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

/***/ 223:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.ng2StatisticsApp').factory('napTab', napTab);
	
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
	                    reportType: activePane.data.reportType,
	                    isDrilldown: activePane.data.isDrilldown
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
	                    var title = isLast == true ? pane.service.getTitle(pane, isLast) : "Back";
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
//# sourceMappingURL=ng2-statistics.chunk.js.map