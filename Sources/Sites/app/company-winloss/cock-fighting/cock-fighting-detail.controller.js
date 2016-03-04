(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('CockfightingDetailController', CockfightingDetailController);

    CockfightingDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'cockfightingDetailService', 'breadcrumbHelper'];
    function CockfightingDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, cockfightingDetailService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate(startDate, endDate) {
            cockfightingDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope),
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridHelper.calculateExpandHeight(gridElement, true);
            data.defaultCollapseAllGroups = true;
            gridElement.fanexGrid(data);
        }

        function compileLinks() {
            breadcrumbHelper.compile($element);
            var elements = $element.find('.drill-down');
            $compile(elements)($scope);
        }

        function exportExcel() {
            cockfightingDetailService.exportExcel();
        }
    }
})();