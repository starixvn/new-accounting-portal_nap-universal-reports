(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CasinoSiteController', CasinoSiteController);

    CasinoSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'casinoService', 'breadcrumbHelper'];
    function CasinoSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, casinoService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            var dateRange = filterModel.getDateRange();
            casinoService.getSite(dateRange.startDate, dateRange.endDate, gridModel.betType, gridModel.site).then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo= titleInfo;
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
        }
    }
})();