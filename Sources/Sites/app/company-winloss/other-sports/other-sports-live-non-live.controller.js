(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('OtherSportsLiveNonLiveController', OtherSportsLiveNonLiveController);

    OtherSportsLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'sportTypeService'];
    function OtherSportsLiveNonLiveController($scope, $element, fanexGridService, sportTypeService) {
        var pane = $scope.pane;
        var getProductTitle = sportTypeService.getTitle;
        var getProductLiveNonLiveTitle = pane.service.getTitle;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var sportTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;
        $scope.generateSportType = generateSportType;

        function generateBetType(sportType, sportTypeName) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generateSportType(isLive) {
            var data = {
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('sportType', data);
        }

        function generate() {
            var count = 0;
            var compileLinks = function () {
                count++;
                if (count === 2) {
                    pane.compileLinks();
                }
            };
            sportTypeService.getData(pane.data).then(function (data) {
                createLinksForSportType(data);
                renderGridForSportType(data);
                compileLinks();
            });
            pane.service.getData(pane.data).then(function (data) {
                createLinksForLiveNonLive(data);
                renderGridForLiveNonLive(data);
                compileLinks();
            });
        }

        function renderGridForSportType(data) {
            pane.service.getTitle = getProductTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(sportTypeGridElement, true);
            data.defaultCollapseAllGroups = true;
            sportTypeGridElement.fanexGrid(data);
        }

        function createLinksForSportType(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeName = sportTypeRow.Columns[0].Value;
                var sportType = sportTypeRow.Columns[0].CustomAttr;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportType + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }

        function renderGridForLiveNonLive(data) {
            pane.service.getTitle = getProductLiveNonLiveTitle;
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

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var row = data.bodyRows[i];
                var name = row.Columns[0].Value;
                var isLive = parseInt(row.Columns[0].CustomAttr);
                row.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSportType(' + isLive + ')">' + name + '</a>';
            }
        }

        function exportExcel() {
            pane.service.getTitle = getProductTitle;
            var sportTypeTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            otherSportsLiveNonLiveService.exportExcel(sportTypeTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);