(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('LiveCasinoBetTypeController', LiveCasinoBetTypeController);

    LiveCasinoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'liveCasinoService', 'breadcrumbHelper', 'drillDownHelper'];
    function LiveCasinoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, liveCasinoService, breadcrumbHelper, drillDownHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            var dateRange = filterModel.getDateRange();
            liveCasinoService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.thirdPartyProductId, breadcrumbHelper.generateText()).then(function (data) {
                drillDownHelper.build($scope, data);
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