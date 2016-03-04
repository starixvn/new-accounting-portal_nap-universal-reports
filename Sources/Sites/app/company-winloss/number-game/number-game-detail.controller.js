(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('NumberGameDetailController', NumberGameDetailController);

    NumberGameDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameDetailService', 'breadcrumbHelper'];
    function NumberGameDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameDetailService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate(startDate, endDate) {
            numberGameDetailService.getData().then(function (data) {
                renderGrid(data);
                compileLinks();
            });
        }

        function renderGrid(data) {
            var titleInfo = {
                text: breadcrumbHelper.generateHtml($scope, gridModel.isLive),
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
            numberGameDetailService.exportExcel();
        }
    }
})();