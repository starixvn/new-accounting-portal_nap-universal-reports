/* Author: Nexcel -  2016-02-17 */
/* Author: Nexcel -  2016-02-17 */
(function () {
    'use strict';

    var levels = {
        PRODUCT: 1,
        SUB_PRODUCT: 2,
        SPORT_TYPE: 3,
        BET_TYPE: 4,
        SITE: 5,
        DETAIL: 6
    };

    var levelSettings = {
        'product': {
            templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
            controller: 'ProductController'
        },
        'Number Game': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/number-game/number-game.html',
                controller: 'NumberGameBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController'
            }
        },
        'Virtual Sports': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsBetTypeController'
            },
            detail: function (gridModel) {
                if (gridModel.sportType >= 181 && gridModel.sportType <= 185) {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                        controller: 'VirtualSportsRacingDetailController'
                    }
                } else {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                        controller: 'VirtualSportsSportsbookDetailController'
                    }
                }
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSiteController'
            }
        },
        'Racing': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSiteController'
            }
        },
        'Keno': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoBetTypeController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoSiteController'
            }
        }
    };

    angular
        .module('companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope', 'levels', 'companyWinlossService'];
    function CompanyWinlossController($scope, levels, companyWinlossService) {
        companyWinlossService.scope = $scope;
        companyWinlossService.gridModel = this;
        var vm = this;
        vm.level = levels.PRODUCT;
        vm.levels = levels;
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['$timeout', 'levels'];
    function companyWinlossService($timeout, levels) {
        var service = {
            scope: {},
            gridModel: {},
            filterModel: {},
            updateGridModel: updateGridModel,
            generate: generate
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level <= data.level;
            this.updateGridModel(data);
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel.level);
            } else {
                this.scope.$broadcast('show', this.gridModel.level);
            }
        }

        function updateGridModel(data) {
            this.gridModel.level = angular.isDefined(data.level) ? data.level : this.gridModel.level;
            this.gridModel.productName = angular.isDefined(data.productName) ? data.productName : this.gridModel.productName;
            this.gridModel.subProductName = angular.isDefined(data.subProductName) ? data.subProductName : this.gridModel.subProductName;
            this.gridModel.sportType = angular.isDefined(data.sportType) ? data.sportType : this.gridModel.sportType;
            this.gridModel.sportTypeName = angular.isDefined(data.sportTypeName) ? data.sportTypeName : this.gridModel.sportTypeName;
            this.gridModel.isLive = angular.isDefined(data.isLive) ? data.isLive : this.gridModel.isLive;
            this.gridModel.betType = angular.isDefined(data.betType) ? data.betType : this.gridModel.betType;
            this.gridModel.betTypeName = angular.isDefined(data.betTypeName) ? data.betTypeName : this.gridModel.betTypeName;
            this.gridModel.site = angular.isDefined(data.site) ? data.site : this.gridModel.site;
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('breadcrumbHelper', breadcrumbHelper);

    breadcrumbHelper.$inject = [];
    function breadcrumbHelper() {
        var service = {
            generateHtml: generateHtml
        };
        return service;

        function generateHtml(scope) {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: '/app/company-winloss/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope', 'config', 'companyWinlossService'];
        function controller($scope, config, companyWinlossService) {
            companyWinlossService.filterModel = this;
            /*jshint validthis: true */
            var vm = this;
            vm.currentLevel = 0;
            vm.normalMode = true;
            vm.today = config.today;
            vm.yesterday = config.yesterday;
            vm.date = config.today;
            vm.startDate = moment.utc(config.today).startOf('month');
            vm.endDate = config.today;
            vm.getDateRange = getDateRange;
            vm.updateDateRange = updateDateRange;

            vm.generate = function () {
                companyWinlossService.generate({});
            };

            vm.todayClicked = function () {
                vm.date = vm.today;
                vm.generate();
            };

            vm.yesterdayClicked = function () {
                vm.date = vm.yesterday;
                vm.generate();
            };

            vm.viewHistoryMode = function () {
                vm.normalMode = false;
            };

            vm.viewNormalMode = function () {
                vm.normalMode = true;
            };

            vm.getEndOfDay = function (date) {
                return moment.utc(date).endOf('day');
            };

            function getDateRange() {
                if (vm.normalMode) {
                    return {
                        startDate: vm.date,
                        endDate: vm.date
                    };
                } else {
                    return {
                        startDate: vm.startDate,
                        endDate: vm.endDate
                    };
                }
            }

            function updateDateRange(dateRange) {
                vm.date = dateRange.startDate;
                vm.startDate = dateRange.startDate;
                vm.endDate = dateRange.endDate;
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoBetTypeController', KenoBetTypeController);

    KenoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService'];
    function KenoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        
        function generateSite(betType, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            kenoService.getBetType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var bettypes = data.BetTypes;
            for (var i = 0; i < bettypes.length; i++) {
                var bettypeItem = bettypes[i];
                bodyData.push(createBetTypeWinLossDataRow(bettypeItem));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(bettypeItem) {
            return {
                Columns: createWinLossDataRow(bettypeItem.Total, true),
                SubRows: [
                    { Columns: createWinLossDataRow(bettypeItem.Credit, false) },
                    { Columns: createWinLossDataRow(bettypeItem.Deposit, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTotal) {
            var betTypeColumn = isTotal ? createBetTypeTotalColumn(winLoss) : createBetTypeSiteColumn(winLoss);
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }
        
        function createBetTypeTotalColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
            }];
        }

        function createBetTypeSiteColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
                CustomCellRender: function (cellValue) {
                    return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                }
            }];
        }

        function createColumnWithoutBetType(winLoss) {
            return [
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createGrandTotalColumn(grandTotal.Total) },
                { Columns: createGrandTotalColumn(grandTotal.Credit) },
                { Columns: createGrandTotalColumn(grandTotal.Deposit) }
            ];
        }

        function createGrandTotalColumn(winLoss) {
            var betTypeColumn = [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
            }];
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoSiteController', KenoSiteController);

    KenoSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService'];
    function KenoSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            kenoService.getSite(dateRange.startDate, dateRange.endDate, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoService', kenoService);

    kenoService.$inject = ['$http', 'logger'];
    function kenoService($http, logger) {
        var service = {
            getBetType: getBetType,
            getSite: getSite
        };
        return service;

        function getBetType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }
      
        function getSite(startDate, endDate, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/keno/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napLevel', napSite);

    napSite.$inject = ['$controller'];
    function napSite($controller) {
        var directive = {
            restrict: 'EA',
            scope: {
                level: '='
            },
            controller: controller
        };
        return directive;

        controller.$inject = ['$log', '$compile', '$timeout', '$element', '$scope', 'config', 'levels', 'levelSettings', '$templateRequest', 'companyWinlossService'];
        function controller($log, $compile, $timeout, $element, $scope, config, levels, levelSettings, $templateRequest, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var levelSetting = undefined;
                switch ($scope.level) {
                    case levels.PRODUCT:
                        levelSetting = levelSettings.product;
                        break;

                    case levels.SPORT_TYPE:
                        levelSetting = levelSettings[gridModel.productName].sportType;
                        break;

                    case levels.BET_TYPE:
                        levelSetting = levelSettings[gridModel.productName].betType;
                        break;

                    case levels.SITE:
                        levelSetting = levelSettings[gridModel.productName].site;
                        break;

                    case levels.DETAIL:
                        levelSetting = levelSettings[gridModel.productName].detail;
                        break;
                }

                if (angular.isUndefined(levelSetting)) {
                    $log.error('Product level setting is undefined');
                    return;
                }

                if (angular.isFunction(levelSetting)) {
                    levelSetting = levelSetting(gridModel);
                }

                $templateRequest(levelSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(levelSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        if (currentScope) {
                            currentScope.$destroy();
                            currentScope = null;
                        }

                        currentScope = scope;
                        currentScope.generate();
                    });
                });
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoController', LiveCasinoController);

    LiveCasinoController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService'];
    function LiveCasinoController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService) {
        $scope.generate = generate;

        function generate() {
            $element.html('test');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameBetTypeController', NumberGameBetTypeController);

    NumberGameBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;       
        $scope.generateDetail = generateDetail;        
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateDetail(betType, betTypeName, isLive) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            });
        };

        function generateSite(betType, betTypeName, isLive, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive,
                site: site
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            numberGameService.getBetType(dateRange.startDate, dateRange.endDate).then(function (data) {
                var nonLiveData = {
                    IsLive: false,
                    GrandTotal: data.NonLiveGrandTotal,
                    BetTypes: data.NonLive
                };
                renderGrid(nonliveGridElement, nonLiveData);
                var liveData = {
                    IsLive: true,
                    GrandTotal: data.LiveGrandTotal,
                    BetTypes: data.Live
                };
                renderGrid(liveGridElement, liveData);
                compileLinks();
            });
        }

        function show() {
            nonliveGridElement.fanexGrid('resizeGrid');
            liveGridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var gridModel = companyWinlossService.gridModel;
            var title = gridModel.productName + ' "' + (data.IsLive ? 'Live' : 'Non-Live') + '" ' + 'PRODUCT WIN/LOSS REPORT';
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + title + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(nonliveGridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeItem = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeItem, data.IsLive));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem, isLive) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, 'generateDetail', betTypeName, isLive),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateSite', betTypeName, isLive) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateSite', betTypeName, isLive) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName, isLive) {
            var betTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',' + isLive + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                betTypeColumn.CellAlign = 'right';
            }
            return [
                betTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameDetailController', NumberGameDetailController);

    NumberGameDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;       
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            numberGameService.getMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.isLive, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" ' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var leagues = data.Leagues;
            for (var i = 0; i < leagues.length; i++) {
                var leagueData = leagues[i];
                var leagueName = leagueData.LeagueName;
                bodyData.push({ Columns: createLeagueNameDataRow(leagueName) });
                var matches = leagueData.Matches;
                for (var j = 0; j < matches.length; j++) {
                    var matchData = matches[j];
                    bodyData.push({ Columns: createWinLossDataRow(matchData) });
                }
            }

            return bodyData;
        }

        function createLeagueNameDataRow(leagueName) {
            return [
                { Name: "Code", Value: "" },
                { Name: "MemberWinLoss", Value: leagueName, MergeColNumber: 6, CssClass: 'league-header' }
            ];
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Code", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.Name = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameSiteController', NumberGameSiteController);

    NumberGameSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            numberGameService.getSite(dateRange.startDate, dateRange.endDate, gridModel.isLive, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameService', numberGameService);

    numberGameService.$inject = ['$http', 'logger'];
    function numberGameService($http, logger) {
        var service = {
            getBetType: getBetType,
            getMatchDetail: getMatchDetail,
            getSite: getSite
        };

        return service;

        function getBetType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/number-game/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getMatchDetail(startDate, endDate, isLive, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, isLive, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/number-game/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'productService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService'];
    function ProductController($compile, $timeout, $element, $scope, formatStrings, productService, fanexGridHelper, levels, levelSettings, companyWinlossService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var level = levelSettings[productName].level;
            companyWinlossService.generate({
                level: level,
                productName: productName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            productService.getData(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
            var elements = gridElement.find('.drill-down');
            $compile(elements)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Product", Width: 150, Name: "Product", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Variance", Width: 120, Name: "Variance", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Product", Name: "Product", MergeRowNumber: 2 },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeColNumber: 2 },
                { HeaderText: "Variance", Name: "Variance", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeColNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeColNumber: 2 }
            ];

            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li class="active">PRODUCT WIN/LOSS REPORT</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sportsbookDetail = data.SportsbookDetail;
            for (var i = 0; i < sportsbookDetail.length; i++) {
                var sportsbookItem = sportsbookDetail[i];
                bodyData.push({
                    Columns: createWinLossDataRow(sportsbookItem)
                });
            }

            var products = data.Products;
            for (var i = 0; i < products.length; i++) {
                var productItem = products[i];
                var isSportsBook = i === 0;
                bodyData.push(createProductWinLossDataRow(productItem, isSportsBook));
            }

            return bodyData;
        }

        function createProductWinLossDataRow(productWinLossItem, isSportsBook) {
            var rowCssClass = isSportsBook ? 'sports-book-row' : '';
            return {
                Columns: createWinLossDataRow(productWinLossItem.Total, !isSportsBook),
                SubRows: [
                    { Columns: createWinLossDataRow(productWinLossItem.Credit, false, true), CssClass: rowCssClass },
                    { Columns: createWinLossDataRow(productWinLossItem.Deposit, false, true), CssClass: rowCssClass }
                ],
                CssClass: rowCssClass
            };
        }

        function createWinLossDataRow(winLoss, hasProductDrillDown, isTextRight) {
            var productColumn = !hasProductDrillDown
                ? { Name: "Product", Value: winLoss.Name }
                : {
                    Name: "Product", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateProduct(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                productColumn.CellAlign = 'right';
            }
            return [
                productColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "VirtualIncome", Value: winLoss.VirtualIncome },
                { Name: "Variance", Value: winLoss.VarianceIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "VirtualTurnover", Value: winLoss.VirtualTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin },
                { Name: "VirtualMargin", Value: winLoss.VirtualMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, false, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'logger'];
    function productService($http, logger) {
        var service = {
            getData: getData
        };
        return service;

        function getData(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/values', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingBetTypeController', RacingBetTypeController);

    RacingBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateSite = generateSite;
        $scope.generateDetail = generateDetail;
        
        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateSite(betType, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.sportTypeName + ' Product Win/Loss Report</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeData = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeData));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? {
                    Name: "BetType",
                    Value: winLoss.Name,
                    CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                }
                : {
                    Name: "BetType",
                    Value: winLoss.Name,
                    CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateDetail(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingDetailController', RacingDetailController);

    RacingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Race", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var leagues = data.Leagues;
            for (var i = 0; i < leagues.length; i++) {
                var leagueData = leagues[i];

                appendLeagueHeaderRow(bodyData, leagueData);
                appendRaceWinLossDataRow(bodyData, leagueData);
            }

            return bodyData;
        }


        function appendLeagueHeaderRow(bodyData, leagueData) {
            var leagueRowHeader = {
                Columns: [{
                    Name: "Name", Value: leagueData.LeagueName, MergeColNumber: 7, CellAlign: "left",
                }]
            };
            bodyData.push(leagueRowHeader);
        }

        function appendRaceWinLossDataRow(bodyData, leagueData) {

            var races = leagueData.Races;
            for (var i = 0; i < races.length; i++) {
                appendRaceDataRow(bodyData, races[i], "center");
            }

            appendRaceDataRow(bodyData, leagueData.Total, "right");
        }

        function appendRaceDataRow(bodyData, winLoss, align) {
            var row = createRaceDataRow(winLoss, align);
            bodyData.push(row);
        }

        function createRaceDataRow(winLoss, align) {
            return {
                Columns: [
                    { Name: "Name", Value: winLoss.Name, CellAlign: align },
                    { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                    { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                    { Name: "Commission", Value: winLoss.Commission },
                    { Name: "RealIncome", Value: winLoss.RealIncome },
                    { Name: "RealTurnover", Value: winLoss.RealTurnover },
                    { Name: "RealMargin", Value: winLoss.RealMargin }
                ]
            };
        }

        function createWinLossDataRowFooter(winLoss) {
            return;
        }

        function createFooterData(data) {
            return createRaceDataRow(data.Total, "right");
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingSiteController', RacingSiteController);

    RacingSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;        
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getSite(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingSportTypeController', RacingSportTypeController);

    RacingSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;       

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            racingService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Sport Type", Width: 150, Name: "SportType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sports = data.Sports;
            for (var i = 0; i < sports.length; i++) {
                var sportTypeItem = sports[i];
                bodyData.push(createSportTypeWinLossDataRow(sportTypeItem));
            }

            return bodyData;
        }

        function createSportTypeWinLossDataRow(sportTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(sportTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? { Name: "SportType", Value: winLoss.Name }
                : {
                    Name: "SportType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateBetType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('racingService', racingService);

    racingService.$inject = ['$http', 'logger'];
    function racingService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getGameDetail: getGameDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/racing/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/racing/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getGameDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/racing/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, sportType, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/racing/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsDetailController', VirtualSportsDetailController);

    VirtualSportsDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = function () {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        $scope.generateSportType = function () {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };
        $scope.generateBetType = function () {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Event", Width: 150, Name: "HomeName", HeaderAlign: "center", CellAlign: "center", MergeHeaderColNumber: 3 },
                 { HeaderText: "vs", Width: 30, Name: "vs", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "AwayName", Width: 150, Name: "AwayName", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode },
                { Name: "HomeName", Value: winLoss.HomeName },
                { Name: "vs", Value: '-vs-' },
                { Name: "AwayName", Value: winLoss.AwayName },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode, CssClass: 'text-right', MergeColNumber: 4 },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsBetTypeController', VirtualSportsBetTypeController);

    VirtualSportsBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateDetail = generateDetail;
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.sportTypeName + ' Product Win/Loss Report</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeData = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeData));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, 'generateDetail', betTypeName),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateSite', betTypeName) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateSite', betTypeName) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName) {
            var sportTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsRacingDetailController', VirtualSportsRacingDetailController);

    VirtualSportsRacingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsRacingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;       
        $scope.generateSportType = generateSportType;       
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getRacingMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.Name },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.Name, CssClass: 'text-right' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSiteController', VirtualSportsSiteController);

    VirtualSportsSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct =generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getSite(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + ' | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportTypeController', VirtualSportsSportTypeController);

    VirtualSportsSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateBetType = generateBetType;
        $scope.generateProduct = generateProduct;

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            virtualSportsService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Sport Type", Width: 150, Name: "SportType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sports = data.Sports;
            for (var i = 0; i < sports.length; i++) {
                var sportTypeItem = sports[i];
                bodyData.push(createSportTypeWinLossDataRow(sportTypeItem));
            }

            return bodyData;
        }

        function createSportTypeWinLossDataRow(sportTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(sportTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? { Name: "SportType", Value: winLoss.Name }
                : {
                    Name: "SportType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateBetType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportsbookDetailController', VirtualSportsSportsbookDetailController);

    VirtualSportsSportsbookDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSportsbookDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getSportsBookMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Event", Width: 150, Name: "HomeName", HeaderAlign: "center", CellAlign: "right", MergeHeaderColNumber: 3 },
                 { HeaderText: "vs", Width: 30, Name: "vs", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "AwayName", Width: 150, Name: "AwayName", HeaderAlign: "center", CellAlign: "left" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode },
                { Name: "HomeName", Value: winLoss.HomeName },
                { Name: "vs", Value: '-vs-' },
                { Name: "AwayName", Value: winLoss.AwayName },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode, CssClass: 'text-right', MergeColNumber: 4 },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsService', virtualSportsService);

    virtualSportsService.$inject = ['$http', 'logger'];
    function virtualSportsService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getSportsBookMatchDetail: getSportsBookMatchDetail,
            getRacingMatchDetail: getRacingMatchDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/virtual-sports/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/virtual-sports/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSportsBookMatchDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/sports-book-match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getRacingMatchDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, sportType, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    var levels = {
        PRODUCT: 1,
        SUB_PRODUCT: 2,
        SPORT_TYPE: 3,
        BET_TYPE: 4,
        SITE: 5,
        DETAIL: 6
    };

    var levelSettings = {
        'product': {
            templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
            controller: 'ProductController'
        },
        'Number Game': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/number-game/number-game.html',
                controller: 'NumberGameBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'NumberGameSiteController'
            }
        },
        'Virtual Sports': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsBetTypeController'
            },
            detail: function (gridModel) {
                if (gridModel.sportType >= 181 && gridModel.sportType <= 185) {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                        controller: 'VirtualSportsRacingDetailController'
                    }
                } else {
                    return {
                        templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                        controller: 'VirtualSportsSportsbookDetailController'
                    }
                }
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'VirtualSportsSiteController'
            }
        },
        'Racing': {
            level: levels.SPORT_TYPE,
            sportType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSportTypeController'
            },
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingBetTypeController'
            },
            detail: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingDetailController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'RacingSiteController'
            }
        },
        'Keno': {
            level: levels.BET_TYPE,
            betType: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoBetTypeController'
            },
            site: {
                templateUrl: 'app/company-winloss/shared/fanex-grid-with-title.html',
                controller: 'KenoSiteController'
            }
        }
    };

    angular
        .module('companyWinlossApp')
        .constant('levels', levels)
        .constant('levelSettings', levelSettings);
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CompanyWinlossController', CompanyWinlossController);

    CompanyWinlossController.$inject = ['$scope', 'levels', 'companyWinlossService'];
    function CompanyWinlossController($scope, levels, companyWinlossService) {
        companyWinlossService.scope = $scope;
        companyWinlossService.gridModel = this;
        var vm = this;
        vm.level = levels.PRODUCT;
        vm.levels = levels;
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['$timeout', 'levels'];
    function companyWinlossService($timeout, levels) {
        var service = {
            scope: {},
            gridModel: {},
            filterModel: {},
            updateGridModel: updateGridModel,
            generate: generate
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level <= data.level;
            this.updateGridModel(data);
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel.level);
            } else {
                this.scope.$broadcast('show', this.gridModel.level);
            }
        }

        function updateGridModel(data) {
            this.gridModel.level = angular.isDefined(data.level) ? data.level : this.gridModel.level;
            this.gridModel.productName = angular.isDefined(data.productName) ? data.productName : this.gridModel.productName;
            this.gridModel.subProductName = angular.isDefined(data.subProductName) ? data.subProductName : this.gridModel.subProductName;
            this.gridModel.sportType = angular.isDefined(data.sportType) ? data.sportType : this.gridModel.sportType;
            this.gridModel.sportTypeName = angular.isDefined(data.sportTypeName) ? data.sportTypeName : this.gridModel.sportTypeName;
            this.gridModel.isLive = angular.isDefined(data.isLive) ? data.isLive : this.gridModel.isLive;
            this.gridModel.betType = angular.isDefined(data.betType) ? data.betType : this.gridModel.betType;
            this.gridModel.betTypeName = angular.isDefined(data.betTypeName) ? data.betTypeName : this.gridModel.betTypeName;
            this.gridModel.site = angular.isDefined(data.site) ? data.site : this.gridModel.site;
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('breadcrumbHelper', breadcrumbHelper);

    breadcrumbHelper.$inject = [];
    function breadcrumbHelper() {
        var service = {
            generateHtml: generateHtml
        };
        return service;

        function generateHtml(scope) {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: '/app/company-winloss/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope', 'config', 'companyWinlossService'];
        function controller($scope, config, companyWinlossService) {
            companyWinlossService.filterModel = this;
            /*jshint validthis: true */
            var vm = this;
            vm.currentLevel = 0;
            vm.normalMode = true;
            vm.today = config.today;
            vm.yesterday = config.yesterday;
            vm.date = config.today;
            vm.startDate = moment.utc(config.today).startOf('month');
            vm.endDate = config.today;
            vm.getDateRange = getDateRange;
            vm.updateDateRange = updateDateRange;

            vm.generate = function () {
                companyWinlossService.generate({});
            };

            vm.todayClicked = function () {
                vm.date = vm.today;
                vm.generate();
            };

            vm.yesterdayClicked = function () {
                vm.date = vm.yesterday;
                vm.generate();
            };

            vm.viewHistoryMode = function () {
                vm.normalMode = false;
            };

            vm.viewNormalMode = function () {
                vm.normalMode = true;
            };

            vm.getEndOfDay = function (date) {
                return moment.utc(date).endOf('day');
            };

            function getDateRange() {
                if (vm.normalMode) {
                    return {
                        startDate: vm.date,
                        endDate: vm.date
                    };
                } else {
                    return {
                        startDate: vm.startDate,
                        endDate: vm.endDate
                    };
                }
            }

            function updateDateRange(dateRange) {
                vm.date = dateRange.startDate;
                vm.startDate = dateRange.startDate;
                vm.endDate = dateRange.endDate;
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoBetTypeController', KenoBetTypeController);

    KenoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService'];
    function KenoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        
        function generateSite(betType, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            kenoService.getBetType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var bettypes = data.BetTypes;
            for (var i = 0; i < bettypes.length; i++) {
                var bettypeItem = bettypes[i];
                bodyData.push(createBetTypeWinLossDataRow(bettypeItem));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(bettypeItem) {
            return {
                Columns: createWinLossDataRow(bettypeItem.Total, true),
                SubRows: [
                    { Columns: createWinLossDataRow(bettypeItem.Credit, false) },
                    { Columns: createWinLossDataRow(bettypeItem.Deposit, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTotal) {
            var betTypeColumn = isTotal ? createBetTypeTotalColumn(winLoss) : createBetTypeSiteColumn(winLoss);
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }
        
        function createBetTypeTotalColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
            }];
        }

        function createBetTypeSiteColumn(winLoss) {
            return [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
                CustomCellRender: function (cellValue) {
                    return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                }
            }];
        }

        function createColumnWithoutBetType(winLoss) {
            return [
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createGrandTotalColumn(grandTotal.Total) },
                { Columns: createGrandTotalColumn(grandTotal.Credit) },
                { Columns: createGrandTotalColumn(grandTotal.Deposit) }
            ];
        }

        function createGrandTotalColumn(winLoss) {
            var betTypeColumn = [{
                Name: "Name",
                Value: winLoss.Name,
                CellAlign: 'right',
            }];
            var remainColumn = createColumnWithoutBetType(winLoss);
            return betTypeColumn.concat(remainColumn);
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('KenoSiteController', KenoSiteController);

    KenoSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'kenoService'];
    function KenoSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, kenoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            kenoService.getSite(dateRange.startDate, dateRange.endDate, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoService', kenoService);

    kenoService.$inject = ['$http', 'logger'];
    function kenoService($http, logger) {
        var service = {
            getBetType: getBetType,
            getSite: getSite
        };
        return service;

        function getBetType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/keno/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }
      
        function getSite(startDate, endDate, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/keno/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napLevel', napSite);

    napSite.$inject = ['$controller'];
    function napSite($controller) {
        var directive = {
            restrict: 'EA',
            scope: {
                level: '='
            },
            controller: controller
        };
        return directive;

        controller.$inject = ['$log', '$compile', '$timeout', '$element', '$scope', 'config', 'levels', 'levelSettings', '$templateRequest', 'companyWinlossService'];
        function controller($log, $compile, $timeout, $element, $scope, config, levels, levelSettings, $templateRequest, companyWinlossService) {
            var dateRange,
                currentScope;

            $scope.$on('generate', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        dateRange = companyWinlossService.filterModel.getDateRange();
                        generate();
                    });
                }
            });

            $scope.$on('show', function (event, level) {
                if ($scope.level === level) {
                    $timeout(function () {
                        companyWinlossService.filterModel.updateDateRange(dateRange);
                        currentScope.show();
                    });
                }
            });

            function generate() {
                var gridModel = companyWinlossService.gridModel;
                var levelSetting = undefined;
                switch ($scope.level) {
                    case levels.PRODUCT:
                        levelSetting = levelSettings.product;
                        break;

                    case levels.SPORT_TYPE:
                        levelSetting = levelSettings[gridModel.productName].sportType;
                        break;

                    case levels.BET_TYPE:
                        levelSetting = levelSettings[gridModel.productName].betType;
                        break;

                    case levels.SITE:
                        levelSetting = levelSettings[gridModel.productName].site;
                        break;

                    case levels.DETAIL:
                        levelSetting = levelSettings[gridModel.productName].detail;
                        break;
                }

                if (angular.isUndefined(levelSetting)) {
                    $log.error('Product level setting is undefined');
                    return;
                }

                if (angular.isFunction(levelSetting)) {
                    levelSetting = levelSetting(gridModel);
                }

                $templateRequest(levelSetting.templateUrl, true).then(function (response) {
                    var templateScope = $scope.$new();
                    var templateElement = $element.html(response);
                    var templateCtrl = $controller(levelSetting.controller, { $scope: templateScope, $element: templateElement });
                    templateElement.data('$ngControllerController', templateCtrl);
                    $compile(templateElement.contents())(templateScope, function (clonedElement, scope) {
                        if (currentScope) {
                            currentScope.$destroy();
                            currentScope = null;
                        }

                        currentScope = scope;
                        currentScope.generate();
                    });
                });
            }
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoController', LiveCasinoController);

    LiveCasinoController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService'];
    function LiveCasinoController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService) {
        $scope.generate = generate;

        function generate() {
            $element.html('test');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameBetTypeController', NumberGameBetTypeController);

    NumberGameBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;       
        $scope.generateDetail = generateDetail;        
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateDetail(betType, betTypeName, isLive) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            });
        };

        function generateSite(betType, betTypeName, isLive, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive,
                site: site
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            numberGameService.getBetType(dateRange.startDate, dateRange.endDate).then(function (data) {
                var nonLiveData = {
                    IsLive: false,
                    GrandTotal: data.NonLiveGrandTotal,
                    BetTypes: data.NonLive
                };
                renderGrid(nonliveGridElement, nonLiveData);
                var liveData = {
                    IsLive: true,
                    GrandTotal: data.LiveGrandTotal,
                    BetTypes: data.Live
                };
                renderGrid(liveGridElement, liveData);
                compileLinks();
            });
        }

        function show() {
            nonliveGridElement.fanexGrid('resizeGrid');
            liveGridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var gridModel = companyWinlossService.gridModel;
            var title = gridModel.productName + ' "' + (data.IsLive ? 'Live' : 'Non-Live') + '" ' + 'PRODUCT WIN/LOSS REPORT';
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + title + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(nonliveGridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeItem = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeItem, data.IsLive));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem, isLive) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, 'generateDetail', betTypeName, isLive),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateSite', betTypeName, isLive) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateSite', betTypeName, isLive) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName, isLive) {
            var betTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',' + isLive + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                betTypeColumn.CellAlign = 'right';
            }
            return [
                betTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameDetailController', NumberGameDetailController);

    NumberGameDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;       
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            numberGameService.getMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.isLive, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" ' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var leagues = data.Leagues;
            for (var i = 0; i < leagues.length; i++) {
                var leagueData = leagues[i];
                var leagueName = leagueData.LeagueName;
                bodyData.push({ Columns: createLeagueNameDataRow(leagueName) });
                var matches = leagueData.Matches;
                for (var j = 0; j < matches.length; j++) {
                    var matchData = matches[j];
                    bodyData.push({ Columns: createWinLossDataRow(matchData) });
                }
            }

            return bodyData;
        }

        function createLeagueNameDataRow(leagueName) {
            return [
                { Name: "Code", Value: "" },
                { Name: "MemberWinLoss", Value: leagueName, MergeColNumber: 6, CssClass: 'league-header' }
            ];
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Code", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.Name = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameSiteController', NumberGameSiteController);

    NumberGameSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService'];
    function NumberGameSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            numberGameService.getSite(dateRange.startDate, dateRange.endDate, gridModel.isLive, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('numberGameService', numberGameService);

    numberGameService.$inject = ['$http', 'logger'];
    function numberGameService($http, logger) {
        var service = {
            getBetType: getBetType,
            getMatchDetail: getMatchDetail,
            getSite: getSite
        };

        return service;

        function getBetType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/number-game/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getMatchDetail(startDate, endDate, isLive, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType
            };
            return $http.post('/api/company-win-loss/number-game/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, isLive, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: 161,
                isLive: isLive,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/number-game/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$compile', '$timeout', '$element', '$scope', 'formatStrings', 'productService', 'fanexGridHelper', 'levels', 'levelSettings', 'companyWinlossService'];
    function ProductController($compile, $timeout, $element, $scope, formatStrings, productService, fanexGridHelper, levels, levelSettings, companyWinlossService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var level = levelSettings[productName].level;
            companyWinlossService.generate({
                level: level,
                productName: productName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            productService.getData(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(data);
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
            var elements = gridElement.find('.drill-down');
            $compile(elements)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Product", Width: 150, Name: "Product", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Variance", Width: 120, Name: "Variance", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Real", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER },
                 { HeaderText: "Virtual", Width: 120, Name: "VirtualMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Product", Name: "Product", MergeRowNumber: 2 },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeColNumber: 2 },
                { HeaderText: "Variance", Name: "Variance", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeColNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeColNumber: 2 }
            ];

            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li class="active">PRODUCT WIN/LOSS REPORT</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sportsbookDetail = data.SportsbookDetail;
            for (var i = 0; i < sportsbookDetail.length; i++) {
                var sportsbookItem = sportsbookDetail[i];
                bodyData.push({
                    Columns: createWinLossDataRow(sportsbookItem)
                });
            }

            var products = data.Products;
            for (var i = 0; i < products.length; i++) {
                var productItem = products[i];
                var isSportsBook = i === 0;
                bodyData.push(createProductWinLossDataRow(productItem, isSportsBook));
            }

            return bodyData;
        }

        function createProductWinLossDataRow(productWinLossItem, isSportsBook) {
            var rowCssClass = isSportsBook ? 'sports-book-row' : '';
            return {
                Columns: createWinLossDataRow(productWinLossItem.Total, !isSportsBook),
                SubRows: [
                    { Columns: createWinLossDataRow(productWinLossItem.Credit, false, true), CssClass: rowCssClass },
                    { Columns: createWinLossDataRow(productWinLossItem.Deposit, false, true), CssClass: rowCssClass }
                ],
                CssClass: rowCssClass
            };
        }

        function createWinLossDataRow(winLoss, hasProductDrillDown, isTextRight) {
            var productColumn = !hasProductDrillDown
                ? { Name: "Product", Value: winLoss.Name }
                : {
                    Name: "Product", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateProduct(\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                productColumn.CellAlign = 'right';
            }
            return [
                productColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "VirtualIncome", Value: winLoss.VirtualIncome },
                { Name: "Variance", Value: winLoss.VarianceIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "VirtualTurnover", Value: winLoss.VirtualTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin },
                { Name: "VirtualMargin", Value: winLoss.VirtualMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, false, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, false, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('productService', productService);

    productService.$inject = ['$http', 'logger'];
    function productService($http, logger) {
        var service = {
            getData: getData
        };
        return service;

        function getData(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/values', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingBetTypeController', RacingBetTypeController);

    RacingBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateSite = generateSite;
        $scope.generateDetail = generateDetail;
        
        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateSite(betType, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.sportTypeName + ' Product Win/Loss Report</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeData = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeData));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? {
                    Name: "BetType",
                    Value: winLoss.Name,
                    CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateSite(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                }
                : {
                    Name: "BetType",
                    Value: winLoss.Name,
                    CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateDetail(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingDetailController', RacingDetailController);

    RacingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Race", Width: 150, Name: "Name", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var leagues = data.Leagues;
            for (var i = 0; i < leagues.length; i++) {
                var leagueData = leagues[i];

                appendLeagueHeaderRow(bodyData, leagueData);
                appendRaceWinLossDataRow(bodyData, leagueData);
            }

            return bodyData;
        }


        function appendLeagueHeaderRow(bodyData, leagueData) {
            var leagueRowHeader = {
                Columns: [{
                    Name: "Name", Value: leagueData.LeagueName, MergeColNumber: 7, CellAlign: "left",
                }]
            };
            bodyData.push(leagueRowHeader);
        }

        function appendRaceWinLossDataRow(bodyData, leagueData) {

            var races = leagueData.Races;
            for (var i = 0; i < races.length; i++) {
                appendRaceDataRow(bodyData, races[i], "center");
            }

            appendRaceDataRow(bodyData, leagueData.Total, "right");
        }

        function appendRaceDataRow(bodyData, winLoss, align) {
            var row = createRaceDataRow(winLoss, align);
            bodyData.push(row);
        }

        function createRaceDataRow(winLoss, align) {
            return {
                Columns: [
                    { Name: "Name", Value: winLoss.Name, CellAlign: align },
                    { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                    { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                    { Name: "Commission", Value: winLoss.Commission },
                    { Name: "RealIncome", Value: winLoss.RealIncome },
                    { Name: "RealTurnover", Value: winLoss.RealTurnover },
                    { Name: "RealMargin", Value: winLoss.RealMargin }
                ]
            };
        }

        function createWinLossDataRowFooter(winLoss) {
            return;
        }

        function createFooterData(data) {
            return createRaceDataRow(data.Total, "right");
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingSiteController', RacingSiteController);

    RacingSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;        
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            racingService.getSite(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateBetType()">NUMBER GAME</a></li><li class="active">' + gridModel.betTypeName + ' "' + (gridModel.isLive ? 'LIVE' : 'NON-LIVE') + '" | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('RacingSportTypeController', RacingSportTypeController);

    RacingSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'racingService'];
    function RacingSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, racingService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateBetType = generateBetType;       

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            racingService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Sport Type", Width: 150, Name: "SportType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sports = data.Sports;
            for (var i = 0; i < sports.length; i++) {
                var sportTypeItem = sports[i];
                bodyData.push(createSportTypeWinLossDataRow(sportTypeItem));
            }

            return bodyData;
        }

        function createSportTypeWinLossDataRow(sportTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(sportTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? { Name: "SportType", Value: winLoss.Name }
                : {
                    Name: "SportType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateBetType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('racingService', racingService);

    racingService.$inject = ['$http', 'logger'];
    function racingService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getGameDetail: getGameDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/racing/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/racing/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getGameDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/racing/match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, sportType, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/racing/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsDetailController', VirtualSportsDetailController);

    VirtualSportsDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = function () {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        $scope.generateSportType = function () {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };
        $scope.generateBetType = function () {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getGameDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Event", Width: 150, Name: "HomeName", HeaderAlign: "center", CellAlign: "center", MergeHeaderColNumber: 3 },
                 { HeaderText: "vs", Width: 30, Name: "vs", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "AwayName", Width: 150, Name: "AwayName", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode },
                { Name: "HomeName", Value: winLoss.HomeName },
                { Name: "vs", Value: '-vs-' },
                { Name: "AwayName", Value: winLoss.AwayName },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode, CssClass: 'text-right', MergeColNumber: 4 },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsBetTypeController', VirtualSportsBetTypeController);

    VirtualSportsBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateDetail = generateDetail;
        $scope.generateSite = generateSite;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "BetType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li class="active">' + gridModel.sportTypeName + ' Product Win/Loss Report</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var betTypes = data.BetTypes;
            for (var i = 0; i < betTypes.length; i++) {
                var betTypeData = betTypes[i];
                bodyData.push(createBetTypeWinLossDataRow(betTypeData));
            }

            return bodyData;
        }

        function createBetTypeWinLossDataRow(betTypeWinLossItem) {
            var betTypeName = betTypeWinLossItem.Total.Name;
            return {
                Columns: createWinLossDataRow(betTypeWinLossItem.Total, false, 'generateDetail', betTypeName),
                SubRows: [
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Credit, true, 'generateSite', betTypeName) },
                    { Columns: createWinLossDataRow(betTypeWinLossItem.Deposit, true, 'generateSite', betTypeName) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, generateFunc, betTypeName) {
            var sportTypeColumn = !generateFunc
                ? { Name: "BetType", Value: winLoss.Name }
                : {
                    Name: "BetType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="' + generateFunc + '(' + winLoss.Id + ',\'' + betTypeName + '\',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsRacingDetailController', VirtualSportsRacingDetailController);

    VirtualSportsRacingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsRacingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;       
        $scope.generateSportType = generateSportType;       
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getRacingMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Bet Type", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.Name },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.Name, CssClass: 'text-right' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSiteController', VirtualSportsSiteController);

    VirtualSportsSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct =generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getSite(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Credit Site", Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var groupHeaderRowsColumns = [
                { HeaderText: "Site", Name: "Site" },
                { HeaderText: "Member Win Loss", Name: "MemberWinLoss", MergeRowNumber: 2 },
                { HeaderText: "SMA Win Loss", Name: "SMAWinLoss", MergeRowNumber: 2 },
                { HeaderText: "Commission", Name: "Commission", MergeRowNumber: 2 },
                { HeaderText: "Company Income", Name: "RealIncome", MergeRowNumber: 2 },
                { HeaderText: "Company Turnover", Name: "RealTurnover", MergeRowNumber: 2 },
                { HeaderText: "Margin", Name: "RealMargin", MergeRowNumber: 2 }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                customizeHeader: true,
                groupHeaderRows: [
                    { Columns: groupHeaderRowsColumns }
                ],
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + ' | Product WinLoss By ' + gridModel.site + ' Site' + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sites = data.Sites;
            for (var i = 0; i < sites.length; i++) {
                var siteData = sites[i];
                bodyData.push({ Columns: createWinLossDataRow(siteData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss, isFooter) {
            return [
                { Name: "Site", Value: winLoss.Name, CssClass: isFooter ? 'text-right' : '' },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var total = data.Total;
            total.Name = 'Total';
            return [
                { Columns: createWinLossDataRow(total, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportTypeController', VirtualSportsSportTypeController);

    VirtualSportsSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateBetType = generateBetType;
        $scope.generateProduct = generateProduct;

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            virtualSportsService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Sport Type", Width: 150, Name: "SportType", HeaderAlign: "center", CellAlign: "left", ShowCollapseExpand: true },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTree: true,
                defaultCollapseAllGroups: true,
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li class="active">' + gridModel.productName + '</li></ol>',
                    showCollapseExpandButton: true,
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var sports = data.Sports;
            for (var i = 0; i < sports.length; i++) {
                var sportTypeItem = sports[i];
                bodyData.push(createSportTypeWinLossDataRow(sportTypeItem));
            }

            return bodyData;
        }

        function createSportTypeWinLossDataRow(sportTypeWinLossItem) {
            return {
                Columns: createWinLossDataRow(sportTypeWinLossItem.Total, false, true),
                SubRows: [
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Credit, true, false) },
                    { Columns: createWinLossDataRow(sportTypeWinLossItem.Deposit, true, false) }
                ]
            };
        }

        function createWinLossDataRow(winLoss, isTextRight, isTotal) {
            var sportTypeColumn = !isTotal
                ? { Name: "SportType", Value: winLoss.Name }
                : {
                    Name: "SportType", Value: winLoss.Name, CustomCellRender: function (cellValue) {
                        return '<a class="drill-down" href data-ng-click="generateBetType(' + winLoss.Id + ',\'' + winLoss.Name + '\')">' + winLoss.Name + '</a>';
                    }
                };
            if (isTextRight) {
                sportTypeColumn.CellAlign = 'right';
            }
            return [
                sportTypeColumn,
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.RealMargin }
            ];
        }

        function createFooterData(data) {
            var grandTotal = data.GrandTotal;
            return [
                { Columns: createWinLossDataRow(grandTotal.Total, true) },
                { Columns: createWinLossDataRow(grandTotal.Credit, true) },
                { Columns: createWinLossDataRow(grandTotal.Deposit, true) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportsbookDetailController', VirtualSportsSportsbookDetailController);

    VirtualSportsSportsbookDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService'];
    function VirtualSportsSportsbookDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;
        $scope.generateSportType = generateSportType;
        $scope.generateBetType = generateBetType;

        function generateProduct() {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };

        function generateSportType() {
            companyWinlossService.generate({
                level: levels.SPORT_TYPE
            });
        };

        function generateBetType() {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        };

        function generate(startDate, endDate) {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            virtualSportsService.getSportsBookMatchDetail(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var gridOptions = createGridOptions(data);
            gridElement.fanexGrid(gridOptions);
        }

        function compileLinks() {
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);

            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)($scope);
        }

        function createGridOptions(data) {
            var columns = [
                 { HeaderText: "Code", Width: 150, Name: "Code", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "Event", Width: 150, Name: "HomeName", HeaderAlign: "center", CellAlign: "right", MergeHeaderColNumber: 3 },
                 { HeaderText: "vs", Width: 30, Name: "vs", HeaderAlign: "center", CellAlign: "center" },
                 { HeaderText: "AwayName", Width: 150, Name: "AwayName", HeaderAlign: "center", CellAlign: "left" },
                 { HeaderText: "Member Win Loss", Width: 120, Name: "MemberWinLoss", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "SMA Win Loss", Width: 120, Name: "SMAWinLoss", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Commission", Width: 120, Name: "Commission", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Income", Width: 120, Name: "RealIncome", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Company Turnover", Width: 120, Name: "RealTurnover", HeaderAlign: "center", CellAlign: "right", FormatNumber: formatStrings.TWO_DECIMAL_NUMBER },
                 { HeaderText: "Margin", Width: 120, Name: "RealMargin", HeaderAlign: "center", CellAlign: "right", FormatPositive: '$', FormatNumber: formatStrings.TWO_DECIMAL_PERCENT_NUMBER }
            ];

            var gridModel = companyWinlossService.gridModel;
            var gridOptions = {
                columns: columns,
                bodyRows: createBodyData(data),
                showTitle: true,
                titleInfo:
                {
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateProduct()">MAIN</a></li><li><a href data-ng-click="generateSportType()">' + gridModel.productName + '</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.sportTypeName + '</a></li><li class="active">' + gridModel.betTypeName + '</li></ol>',
                    showExcelButton: true,
                    exportExcelFunction: exportExcel
                },
                showFooter: true,
                footerRows: createFooterData(data),
                gridExpandHeight: fanexGridHelper.calculateExpandHeight(gridElement, true)
            };

            return gridOptions;
        }

        function createBodyData(data) {
            var bodyData = [];
            var matches = data.Matches;
            for (var i = 0; i < matches.length; i++) {
                var matchData = matches[i];
                bodyData.push({ Columns: createWinLossDataRow(matchData) });
            }

            return bodyData;
        }

        function createWinLossDataRow(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode },
                { Name: "HomeName", Value: winLoss.HomeName },
                { Name: "vs", Value: '-vs-' },
                { Name: "AwayName", Value: winLoss.AwayName },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createWinLossDataRowFooter(winLoss) {
            return [
                { Name: "Code", Value: winLoss.MatchCode, CssClass: 'text-right', MergeColNumber: 4 },
                { Name: "MemberWinLoss", Value: winLoss.MemberWinLoss },
                { Name: "SMAWinLoss", Value: winLoss.SMAWinLoss },
                { Name: "Commission", Value: winLoss.Commission },
                { Name: "RealIncome", Value: winLoss.RealIncome },
                { Name: "RealTurnover", Value: winLoss.RealTurnover },
                { Name: "RealMargin", Value: winLoss.Margin }
            ];
        }

        function createFooterData(data) {
            var gridModel = companyWinlossService.gridModel;
            var total = data.Total;
            total.MatchCode = gridModel.betTypeName + ' Total';
            return [
                { Columns: createWinLossDataRowFooter(total) }
            ];
        }

        function exportExcel() {

        }
    }
})();
(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsService', virtualSportsService);

    virtualSportsService.$inject = ['$http', 'logger'];
    function virtualSportsService($http, logger) {
        var service = {
            getSportType: getSportType,
            getBetType: getBetType,
            getSportsBookMatchDetail: getSportsBookMatchDetail,
            getRacingMatchDetail: getRacingMatchDetail,
            getSite: getSite
        };
        return service;

        function getSportType(startDate, endDate) {
            var data = { startDate: startDate, endDate: endDate };
            return $http.post('/api/company-win-loss/virtual-sports/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getBetType(startDate, endDate, sportType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType
            };
            return $http.post('/api/company-win-loss/virtual-sports/bet-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSportsBookMatchDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/sports-book-match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getRacingMatchDetail(startDate, endDate, sportType, betType) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType
            };
            return $http.post('/api/company-win-loss/virtual-sports/racing-match-detail', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getSite(startDate, endDate, sportType, betType, site) {
            var data = {
                startDate: startDate,
                endDate: endDate,
                sportType: sportType,
                betType: betType,
                site: site
            };
            return $http.post('/api/company-win-loss/virtual-sports/site', data)
                .then(getDataComplete)
                .catch(getDataFailed);
        }

        function getDataComplete(response) {
            logger.hide();
            return response.data;
        }

        function getDataFailed(error) {
            logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }
    }
})();