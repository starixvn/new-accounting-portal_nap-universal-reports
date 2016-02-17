(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoSiteController', LiveCasinoSiteController);

    LiveCasinoSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'liveCasinoService'];
    function LiveCasinoSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, liveCasinoService) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateMain = function () {
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
        };
        $scope.generateThirdPartyProduct = function () {
            companyWinlossService.generate({
                level: levels.THIRD_PARTY_PRODUCT
            });
        };
        $scope.generateBetType = function () {
            companyWinlossService.generate({
                level: levels.BET_TYPE
            });
        }

        function generate() {
            var dateRange = companyWinlossService.filterModel.getDateRange();
            var gridModel = companyWinlossService.gridModel;
            liveCasinoService.getSite(dateRange.startDate, dateRange.endDate, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
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
            var gridModel = companyWinlossService.gridModel;
            var columns = [
                 { HeaderText: gridModel.site, Width: 150, Name: "Site", HeaderAlign: "center", CellAlign: "center" },
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
                    text: '<ol class="breadcrumb"><li><a href data-ng-click="generateMain()">MAIN</a></li><li><a href data-ng-click="generateThirdPartyProduct()">LIVE CASINO</a></li><li><a href data-ng-click="generateBetType()">' + gridModel.thirdPartyProductName + '</a></li><li class="active">' + gridModel.betTypeName + ' Product Win/Loss BY ' + gridModel.site + ' SITE</li></ol>',
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