(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .controller('VirtualSportsBetTypeController', VirtualSportsBetTypeController);

    VirtualSportsBetTypeController.$inject = ['$compile', '$scope', '$element', 'formatStrings', 'fanexGridHelper', 'levels', 'companyWinlossService', 'virtualSportsService', 'breadcrumbHelper', 'drillDownHelper'];
    function VirtualSportsBetTypeController($compile, $scope, $element, formatStrings, fanexGridHelper, levels, companyWinlossService, virtualSportsService, breadcrumbHelper, drillDownHelper) {
        var gridModel = companyWinlossService.gridModel;
        var filterModel = companyWinlossService.filterModel;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.show = show;
        $scope.generateDetail = generateDetail;
        $scope.generateSite = generateSite;

        function generateDetail(betType, betTypeName) {
            companyWinlossService.generate({
                level: levels.DETAIL,
                betType: betType,
                betTypeName: betTypeName
            });
        };

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        };

        function show() {
            gridElement.fanexGrid('resizeGrid');
        }

        function generate(startDate, endDate) {
            var dateRange = filterModel.getDateRange();
            virtualSportsService.getBetType(dateRange.startDate, dateRange.endDate, gridModel.sportType).then(function (data) {
                drillDownHelper.build($scope, data);
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
            drillDownHelper.compile($element);
        }

        function exportExcel() {
        }
    }
})();