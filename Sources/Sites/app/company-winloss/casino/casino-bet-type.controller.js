(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('CasinoBetTypeController', CasinoBetTypeController);

    CasinoBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'casinoService', 'breadcrumbHelper', 'drillDownHelper'];
    function CasinoBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, casinoService, breadcrumbHelper, drillDownHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;

        function generate() {
            var dateRange = filterModel.getDateRange();
            casinoService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.thirdPartyProductId).then(function (data) {
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