(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsSportTypeController', VirtualSportsSportTypeController);

    VirtualSportsSportTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService', 'breadcrumbHelper', 'drillDownHelper'];
    function VirtualSportsSportTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService, breadcrumbHelper, drillDownHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            var dateRange = filterModel.getDateRange();
            virtualSportsService.getSportType(dateRange.startDate, dateRange.endDate).then(function (data) {
                drillDownHelper.build($scope, data);
                renderGrid(gridElement, data);
                compileLinks();
            });
        }

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function renderGrid(gridElement, data) {
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
            drillDownHelper.compile($element);
        }

        function exportExcel() {
        }
    }
})();