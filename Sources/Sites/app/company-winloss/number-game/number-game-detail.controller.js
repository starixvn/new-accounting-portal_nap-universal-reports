(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('NumberGameDetailController', NumberGameDetailController);

    NumberGameDetailController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'numberGameService', 'breadcrumbHelper'];
    function NumberGameDetailController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, numberGameService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate(startDate, endDate) {            
            numberGameService.getMatchDetail().then(function (data) {
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
            data.defaultCollapseAllGroups = true;
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