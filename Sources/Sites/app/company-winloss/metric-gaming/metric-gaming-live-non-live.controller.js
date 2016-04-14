(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'betTypeLiveService'];

    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, betTypeLiveService) {
        var pane = $scope.pane;
        var metricGamingLiveNonLiveService = pane.service;
        var defaultGetTitle = pane.getTitle;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(isLive) {
            var data = {
                isLive: isLive
            }
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generate() {
            var count = 0;
            var compileLinks = function () {
                count++;
                if (count === 2) {
                    pane.compileLinks();
                }
            };
            betTypeLiveService.getData(pane.data).then(function (data) {
                createLinksForBetType(data);
                renderGridForBetType(data);
                compileLinks();
            });

            metricGamingLiveNonLiveService.getData(pane.data).then(function (data) {
                createLinksForLiveNonLive(data);
                renderForLiveNonLive(data);
                compileLinks();
            });
        }

        function renderGridForBetType(data) {
            pane.getTitle = defaultGetTitle;
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
            return isLast ? pane.data.productName + ' Live/Non-Live Win/Loss Report' : pane.data.productName;
        }

        function createLinksForBetType(data) {
            var betType;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betType = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betType + ',\'' + betType.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
            }
        }

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var row = data.bodyRows[i];
                var name = row.Columns[0].Value;
                var isLive = parseInt(row.Columns[0].CustomAttr);
                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + isLive + ')">' + name + '</a>';
            }
        }

        function exportExcel() {
            pane.getTitle = defaultGetTitle;
            var sportTypeTitle = tab.generateBreadcrumbText();
            pane.getTitle = getTitleWhenLiveNonLive;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            metricGamingLiveNonLiveService.exportExcel(sportTypeTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }

})(angular, undefined);