webpackJsonp([4],{

/***/ 0:
/*!***************************!*\
  !*** multi ng2-statistic ***!
  \***************************/
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(/*! ./app/ng2-statistic/app.config.js */114);
	__webpack_require__(/*! ./app/ng2-statistic/app.js */115);
	__webpack_require__(/*! ./app/ng2-statistic/ng2-statistic.controller.js */116);
	__webpack_require__(/*! ./app/ng2-statistic/breadcrumb/breadcrumb.service.js */117);
	__webpack_require__(/*! ./app/ng2-statistic/breadcrumb/title.service.js */118);
	__webpack_require__(/*! ./app/ng2-statistic/daily/daily.controller.js */119);
	__webpack_require__(/*! ./app/ng2-statistic/daily/daily.service.js */120);
	__webpack_require__(/*! ./app/ng2-statistic/filter/filter.directive.js */121);
	__webpack_require__(/*! ./app/ng2-statistic/filter/filter.service.js */122);
	__webpack_require__(/*! ./app/ng2-statistic/tab/pane.directive.js */123);
	__webpack_require__(/*! ./app/ng2-statistic/tab/pane.service.js */124);
	__webpack_require__(/*! ./app/ng2-statistic/tab/tab.directive.js */125);
	module.exports = __webpack_require__(/*! ./app/ng2-statistic/tab/tab.service.js */126);


/***/ },

/***/ 114:
/*!*****************************************!*\
  !*** ./app/ng2-statistic/app.config.js ***!
  \*****************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
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

/***/ 115:
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
	
	    angular.module('app.numberGame2StatisticApp', ['app.core', 'fanex.dropdowntree']);
	})(_angular2.default);

/***/ },

/***/ 116:
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
	
	    angular.module('app.numberGame2StatisticApp').controller('NG2StatisticController', NG2StatisticController);
	
	    NG2StatisticController.$inject = [];
	    function NG2StatisticController() {
	        var vm = this;
	        vm.panes = [];
	    }
	})(_angular2.default);

/***/ },

/***/ 117:
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

/***/ 118:
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
	
	    angular.module('app.numberGame2StatisticApp').factory('titleService', titleService);
	
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

/***/ 119:
/*!*****************************************************!*\
  !*** ./app/ng2-statistic/daily/daily.controller.js ***!
  \*****************************************************/
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	var _numeral = __webpack_require__(/*! numeral */ 7);
	
	var _numeral2 = _interopRequireDefault(_numeral);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').controller('DailyController', DailyController);
	
	    DailyController.$inject = ['$element', '$scope', 'fanexGridService'];
	    function DailyController($element, $scope, fanexGridService) {
	        console.log("DailyController");
	
	        $scope.generate = generate;
	
	        function generate() {
	            console.log("DailyController-generate");
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 120:
/*!**************************************************!*\
  !*** ./app/ng2-statistic/daily/daily.service.js ***!
  \**************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('dailyService', dailyService);
	
	    dailyService.$inject = ['$http', 'httpResponseService'];
	    function dailyService($http, httpResponseService) {
	        console.log("dailyService");
	
	        var service = {
	            getData: getData
	        };
	        return service;
	
	        function getData() {
	            return {
	                fakeData: "fake"
	            };
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 121:
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
	
	    angular.module('app.numberGame2StatisticApp').directive('napFilter', napFilter);
	
	    function napFilter() {
	        var directive = {
	            restrict: 'EA',
	            scope: {},
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
	        vm.startDate = _moment2.default.utc(config.yesterday).startOf('month');
	        vm.endDate = _moment2.default.utc(config.yesterday);
	
	        vm.sportItems = [];
	        vm.sportSettings = {
	            hasFilter: false,
	            checkedAll: true,
	            sourceData: 'app/ng2-statistic/filter/sports.json',
	            templateUrl: 'app/root/components/fanex-dropdowntree/fanex.dropdowntree.directive.template.html'
	        };
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
	            return {
	                reportType: "daily",
	                isDrilldown: false
	            };
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 122:
/*!****************************************************!*\
  !*** ./app/ng2-statistic/filter/filter.service.js ***!
  \****************************************************/
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(/*! angular */ 10);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.numberGame2StatisticApp').factory('filterService', filterService);
	
	    filterService.$inject = ['$http', 'httpResponseService'];
	    function filterService($http, httpResponseService) {
	        var service = {
	            getCurrencies: getCurrencies
	        };
	        return service;
	
	        function getCurrencies() {
	            var url = 'app/ng2-statistic/filter/currencies.json';
	            return $http.get(url, {}).then(httpResponseService.getDataComplete).catch(httpResponseService.getDataFailed);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 123:
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

/***/ 124:
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
	
	    angular.module('app.numberGame2StatisticApp').factory('napPane', napPane);
	
	    napPane.$inject = ['$log', '$compile', '$injector'];
	    function napPane($log, $compile, $injector) {
	        function Pane(reportType, isDrilldown) {
	
	            this.reportType = reportType;
	            this.isDrilldown = isDrilldown;
	
	            this.$scope = undefined;
	            this.$element = undefined;
	            this.generate = generate;
	            this.show = show;
	            this.compileAll = compileAll;
	            this.compileLinks = compileLinks;
	            this.compileDrilldown = compileDrilldown;
	            this.getFileName = getFileName;
	
	            this.templateUrl = 'app/ng2-statistic/shared/fanex-grid-with-title.html';
	            this.controller = getControllerName(reportType, isDrilldown);
	            this.service = getService(reportType, isDrilldown);
	
	            function getService(reportType, isDrilldown) {
	                var reportTypeInCamel = reportType.substring(0, 1).toLowerCase() + reportType.substring(1);
	                var serviceName = reportTypeInCamel + (isDrilldown ? "Drilldown" : "") + "Service";
	
	                return $injector.get(serviceName);
	            }
	
	            function getControllerName(reportType, isDrilldown) {
	                var reportTypeInPascal = reportType.substring(0, 1).toUpperCase() + reportType.substring(1);
	                return reportTypeInPascal + (isDrilldown ? "Drilldown" : "") + "Controller";
	            }
	
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

/***/ 125:
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
	            var mainPane = new Pane(data.reportType, data.isDrilldown);
	            tab.addPane(mainPane);
	        });
	
	        $scope.$on('nap-filter-switch', function (event) {
	            tab.panes = [];
	        });
	    }
	})(_angular2.default);

/***/ },

/***/ 126:
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