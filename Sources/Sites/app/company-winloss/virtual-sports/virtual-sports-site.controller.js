(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSiteController', VirtualSportsSiteController);

    VirtualSportsSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService', 'breadcrumbHelper'];
    function VirtualSportsSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService, breadcrumbHelper) {
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

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
                    text: breadcrumbHelper.generateHtml($scope),
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