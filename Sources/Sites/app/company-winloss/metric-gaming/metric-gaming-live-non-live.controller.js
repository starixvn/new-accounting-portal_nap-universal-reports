(function (angular, undefined) {
    'use strict';
    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingLiveNonLive', MetricGamingLiveNonlive);
    MetricGamingLiveNonLive.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingBetTypeService'];

    function MetricGamingLiveNoneLive($scope, $element, fanexGridService, metricGamingBetTypeService) {
        var pane = $scope.pane;
        var metricGamingLiveNonLiveService = pane.service;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var sportTypeGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName
            }
            angular.extend(data, pane.data);
            tab.goForward('betType', data);

        }

        function generate() {

            metricGamingLiveNonLiveService.getData(data.pane).then(function (data) {
                renderGridForBetType(data);
                createLinksForSportType(data);
            });
        }

        function renderGridForBetType(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(betTypeGridElement, true);
            data.defaultCollapseAllGroups = true;
            betTypeGridElement.fanexGrid(data);
        }

        function renderGridForSportType(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(sportTypeGridElement, true);
            data.defaultCollapseAllGroups = true;
            sportTypeGridElement.fanexGrid(data);
        }

        function createLinksForSportType(data) {
            var betType;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betType = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSportType(' + betType + ',\'' + betType.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
            }
        }

        function exportExcel() {
            pane.data.isLive = true;
            var liveTitle = tab.generateBreadcrumbText();
            pane.data.isLive = false;
            var noneLiveTitle = tab.generateBreadcrumbText();
            delete (pane.data.isLive);
            pane.service.exportExcel(liveTitle, noneLiveTitle, pane.data, pane.getFileName());
        }
    }

})(angular, undefined);