webpackJsonp([4],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	__webpack_require__(207);
	__webpack_require__(208);
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
	__webpack_require__(223);
	__webpack_require__(224);
	__webpack_require__(225);
	__webpack_require__(226);
	__webpack_require__(227);
	__webpack_require__(228);
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
	__webpack_require__(245);
	module.exports = __webpack_require__(246);


/***/ },

/***/ 216:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular, undefined) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('Daily2hSoccerBetTypeFullController', Daily2hSoccerBetTypeFullController);
	
	    Daily2hSoccerBetTypeFullController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'soccerConstants'];
	    function Daily2hSoccerBetTypeFullController($scope, $element, fanexGridService, showHideColumnService, soccerConstants) {
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
	        $scope.generateSite = generateSite;
	        $scope.generateMatchDetail = generateMatchDetail;
	        $scope.createDrilldownLink = createDrilldownLink;
	        $scope.createDrilldownLinks = createDrilldownLinks;
	        $scope.renderGrid = renderGrid;
	        $scope.exportExcel = exportExcel;
	        $scope.sortData = sortData;
	        $scope.betTypeFullGridOptions = null;
	        $scope.betTypeLiveGridOptions = null;
	        $scope.betTypeNonLiveGridOptions = null;
	
	        function generate(viewSetting) {
	            var betTypeFullGridOptions, betTypeLiveGridOptions, betTypeNonLiveGridOptions;
	            $scope.viewSetting = viewSetting;
	
	            pane.service.getData(viewSetting, pane.data, 2).then(function (data) {
	                betTypeFullGridOptions = data;
	                $scope.betTypeFullGridOptions = data;
	                renderAll();
	            });
	
	            pane.service.getData(viewSetting, pane.data, 1).then(function (data) {
	                betTypeLiveGridOptions = data;
	                $scope.betTypeLiveGridOptions = data;
	                renderAll();
	            });
	
	            pane.service.getData(viewSetting, pane.data, 0).then(function (data) {
	                betTypeNonLiveGridOptions = data;
	                $scope.betTypeNonLiveGridOptions = data;
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
	
	            if (betTypeRow.SubRows) {
	                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + betTypeName + '</a>';
	            }
	            if (betTypeRow.SubRows) {
	                for (var i = 0; i < betTypeRow.SubRows.length; i++) {
	                    var siteRow = betTypeRow.SubRows[i];
	                    var siteName = siteRow.Columns[0].Value;
	                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',\'' + siteName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + siteName + '</a>';
	                }
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
	            gridOptions.sortOption = {
	                serverSortFunction: function serverSortFunction(sortColumnName, sortDirection) {
	                    sortData(sortColumnName, sortDirection, 2);
	                }
	            };
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
	            gridOptions.sortOption = {
	                serverSortFunction: function serverSortFunction(sortColumnName, sortDirection) {
	                    sortData(sortColumnName, sortDirection, isLive);
	                }
	            };
	            gridOptions.bottomBorderWidth = 3;
	            gridElement.fanexGrid(gridOptions);
	        }
	
	        function generateSite(betType, betTypeName, site, isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                betType: betType,
	                betTypeName: betTypeName,
	                siteType: site,
	                mainColumnText: site,
	                isLive: isLive
	            });
	
	            data.isHedge = getHedgeParameters(data.sportType, betTypeName);
	            data.isCorners = getCornerParameters(betType, betTypeName);
	
	            tab.goForward('site', data);
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
	            data.isCorners = getCornerParameters(betType, betTypeName);
	
	            tab.goForward('matchDetail', data);
	        }
	
	        function getHedgeParameters(sportType, betTypeName) {
	            if (sportType && sportType > 1) {
	                return 2;
	            }
	
	            return betTypeName && betTypeName.indexOf("(hedge)") > -1 ? 1 : 0;
	        }
	
	        function getCornerParameters(betType, betTypeName) {
	            if (betType !== 228 && betType !== 229) {
	                return 2;
	            }
	
	            return betTypeName && betTypeName.indexOf("(Corners)") > -1 ? 1 : 0;
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
	
	        function sortData(sortColumnName, sortDirection, isLive) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sortColumnName: sortColumnName,
	                sortDirection: sortDirection,
	                isLive: isLive
	            });
	
	            if (isLive === 2) {
	                pane.service.getData($scope.viewSetting, data, 2).then(function (data) {
	                    $scope.betTypeFullGridOptions = data;
	                    renderGridAfterSort(isLive);
	                });
	            }
	
	            if (isLive === 1) {
	                pane.service.getData($scope.viewSetting, data, 1).then(function (data) {
	                    $scope.betTypeLiveGridOptions = data;
	                    renderGridAfterSort(isLive);
	                });
	            }
	
	            if (isLive === 0) {
	                pane.service.getData($scope.viewSetting, data, 0).then(function (data) {
	                    $scope.betTypeNonLiveGridOptions = data;
	                    renderGridAfterSort(isLive);
	                });
	            }
	
	            function renderGridAfterSort(isLive) {
	                var isDataReady = angular.isDefined($scope.betTypeFullGridOptions) && angular.isDefined($scope.betTypeLiveGridOptions) && angular.isDefined($scope.betTypeNonLiveGridOptions);
	                if (!isDataReady) {
	                    return;
	                }
	
	                showHideColumnBuilder.build([betTypeFullGridElement, betTypeLiveGridElement, betTypeNonLiveGridElement], [$scope.betTypeFullGridOptions, $scope.betTypeLiveGridOptions, $scope.betTypeNonLiveGridOptions]);
	
	                var canViewMatchDetail = pane.data.endDate.diff(pane.data.startDate, 'days') <= 3;
	                if (canViewMatchDetail) {
	
	                    if (isLive === 2) {
	                        createDrilldownLinks($scope.betTypeFullGridOptions.bodyRows, 2);
	                    }
	
	                    if (isLive === 1) {
	                        createDrilldownLinks($scope.betTypeLiveGridOptions.bodyRows, 1);
	                    }
	                    if (isLive === 0) {
	                        createDrilldownLinks($scope.betTypeNonLiveGridOptions.bodyRows, 0);
	                    }
	                }
	
	                renderFullGrid(betTypeFullGridElement, $scope.betTypeFullGridOptions);
	                renderGrid(betTypeLiveGridElement, $scope.betTypeLiveGridOptions, 1);
	                renderGrid(betTypeNonLiveGridElement, $scope.betTypeNonLiveGridOptions, 0);
	                pane.compileAll();
	            }
	        }
	    }
	})(_angular2.default, undefined);

/***/ },

/***/ 217:
/***/ function(module, exports, __webpack_require__) {

	'use strict';
	
	var _angular = __webpack_require__(119);
	
	var _angular2 = _interopRequireDefault(_angular);
	
	function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }
	
	(function (angular) {
	    'use strict';
	
	    angular.module('app.houseWinlossApp').controller('Daily2hSoccerMatchDetailController', Daily2hSoccerMatchDetailController);
	
	    Daily2hSoccerMatchDetailController.$inject = ['$scope', '$element', 'fanexGridService', '$uibModal', '$uibModalStack'];
	    function Daily2hSoccerMatchDetailController($scope, $element, fanexGridService, $uibModal, $uibModalStack) {
	        var pane = $scope.pane;
	        var tab = $scope.tab;
	        var gridElement = $element.find('.freegrid');
	        $scope.generate = generate;
	        $scope.viewMatchInformation = viewMatchInformation;
	        $scope.viewSetting = {};
	        $scope.sortData = sortData;
	
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
	                templateUrl: 'app/house-win-loss/sportsbook/sportsbook-match-information.html',
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
	            data.sortOption = {
	                serverSortFunction: function serverSortFunction(sortColumnName, sortDirection) {
	                    sortData(sortColumnName, sortDirection);
	                }
	            };
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
	
	        function sortData(sortColumnName, sortDirection) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sortColumnName: sortColumnName,
	                sortDirection: sortDirection
	            });
	
	            pane.data = data;
	            pane.service.getData($scope.viewSetting, data).then(function (data) {
	                createLinks(data);
	                renderGrid(data);
	                pane.compileAll();
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
	
	    angular.module('app.houseWinlossApp').controller('Daily2hSoccerSportTypeController', Daily2hSoccerSportTypeController);
	
	    Daily2hSoccerSportTypeController.$inject = ['$injector', '$scope', '$element', 'fanexGridService', 'showHideColumnService'];
	    function Daily2hSoccerSportTypeController($injector, $scope, $element, fanexGridService, showHideColumnService) {
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
	                var isSabaSport = sportTypeId;
	                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace(/'/g, "\\'") + '\',' + isLive + ',' + isSabaSport + ')">' + sportTypeName + '</a>';
	            }
	        }
	
	        function generateBetType(sportType, sportTypeName, isLive, isSabaSport) {
	            var data = {};
	            angular.extend(data, pane.data);
	            angular.extend(data, {
	                sportType: sportType,
	                sportTypeName: sportTypeName,
	                isLive: isLive,
	                isSabaSport: isSabaSport
	            });
	            tab.goForward('betType', data);
	        }
	
	        function exportExcel() {
	            pane.service.exportExcelForSingleGrid($scope.viewSetting, tab, pane);
	        }
	    }
	})(_angular2.default);

/***/ },

/***/ 219:
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
	                controller: "Daily2hSoccerSportTypeController",
	                service: "remoteDataService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/sport-type",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", type: "soccer-minor-sport-type", mainColumnText: "Sport Type", mainColumnWidth: 210 },
	                getTitleFunction: "getMainTitle"
	            },
	            betType: {
	                templateUrl: "app/house-win-loss/shared/three-fanex-grid-with-title.html",
	                controller: "Daily2hSoccerBetTypeFullController",
	                service: "soccerMinorBetTypeService",
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/bet-type",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", type: "soccer-minor-bet-type", mainColumnText: "Bet Type", mainColumnWidth: 270 },
	                getTitleFunction: "getSoccerMinorBetTypeTitle"
	            },
	            matchDetail: {
	                templateUrl: "app/house-win-loss/shared/fanex-grid-with-title.html",
	                controller: "Daily2hSoccerMatchDetailController",
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
	                serviceBaseUrl: "api/house-win-loss-by-products/soccer-minor/site",
	                mainParameters: { sheetName: "Soccer Minor Bet Types", sportType: 1, type: "soccer-minor-site" },
	                getTitleFunction: "getSiteTitleLive"
	            }
	        }
	    };
	    angular.module("app.houseWinlossApp").constant("templateSetting", templateSetting);
	})(_angular2.default);

/***/ },

/***/ 220:
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
	                    endDate: vm.date,
	                    permissionProfileID: 1
	                };
	            } else {
	                return {
	                    normalMode: vm.normalMode,
	                    startDate: vm.startDate,
	                    endDate: vm.endDate,
	                    permissionProfileID: 1
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

/***/ 221:
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

/***/ 222:
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
	
	            var url = "api/house-win-loss-by-products/soccer-minor/bet-type";
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