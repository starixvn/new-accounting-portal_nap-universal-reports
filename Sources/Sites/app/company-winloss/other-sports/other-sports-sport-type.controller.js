(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('OtherSportsSportTypeController', OtherSportsSportTypeController);

    OtherSportsSportTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'otherSportsBetTypeService'];
    function OtherSportsSportTypeController($scope, $element, fanexGridService, otherSportsBetTypeService) {
        var pane = $scope.pane;
        var otherSportsSportTypeService = pane.service;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var sportTypeGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateMatchDetail = generateMatchDetail;
        $scope.generateSite = generateSite;

        function generateBetType(sportType, sportTypeName, isLive) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName,
                isLive: isLive
            };
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

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generate() {
            //otherSportsBetTypeService.getData(pane.data).then(function (data) {
            //    renderGridForBetType(data);
            //    createLinksForBetType(data);
            //});

            otherSportsSportTypeService.getData(pane.data).then(function (data) {
                renderGridForSportType(data);
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

        function createLinksForBetType(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',' + isLive + ')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isLive + ')">' + siteName + '</a>';
                }
            }
        }

        function createLinksForSportType(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',' + isLive + ')">' + betTypeName + '</a>';
            }
        }

        function createLinksForSportType(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',' + isLive + ')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isLive + ')">' + siteName + '</a>';
                }
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