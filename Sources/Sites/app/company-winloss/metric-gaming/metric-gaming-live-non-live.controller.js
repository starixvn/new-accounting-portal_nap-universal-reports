(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingBetTypeService'];

    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, metricGamingBetTypeService) {
        var pane = $scope.pane;
        var metricGamingLiveNonLiveService = pane.service;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(isLive) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                IsLive : isLive
            }
            angular.extend(data, pane.data);
            tab.goForward('betType', data);

        }

        function generate() {
            metricGamingBetTypeService.getData(pane.data).then(function (data) {
                createLinksForBetType(data);
                renderGridForBetType(data);
                pane.compileLinks();
            });

            metricGamingLiveNonLiveService.getData(pane.data).then(function (data) {
                createLinksForBetType(data);
                renderForLiveNonLive(data);
                pane.compileLinks();
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

        function renderForLiveNonLive(data) {
            pane.getTitle = getTitleWhenLiveNonLive;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(liveNonLiveGridElement, true);
            data.defaultCollapseAllGroups = true;
            liveNonLiveGridElement.fanexGrid(data);
        }
        
        function getTitleWhenLiveNonLive(isLast) {
            return isLast ? 'Metric Gaming - Superlive Live/Non-Live Win/Loss Report' : 'Metric Gaming - Superlive';
        }

        function createLinksForBetType(data) {
            var betType;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betType = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + betType + ',\'' + betType.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
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