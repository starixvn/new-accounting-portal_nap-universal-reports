(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSiteController', VirtualSportsSiteController);

    VirtualSportsSiteController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService', 'breadcrumbHelper'];
    function VirtualSportsSiteController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService, breadcrumbHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;

        function generate() {
            var dateRange = filterModel.getDateRange();
            virtualSportsService.getSite(dateRange.startDate, dateRange.endDate, gridModel.sportType, gridModel.betType, gridModel.site).then(function (data) {
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
        }

        function exportExcel() {
        }
    }
})();