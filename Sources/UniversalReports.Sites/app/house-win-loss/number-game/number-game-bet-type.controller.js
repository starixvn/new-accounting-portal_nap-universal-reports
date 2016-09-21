import angular from "angular";
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .controller('NumberGameBetTypeController', NumberGameBetTypeController);

    NumberGameBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function NumberGameBetTypeController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var nonliveGridElement = angular.element(gridElements[0]);
        var liveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateMatchDetail = generateMatchDetail;
        $scope.generateSite = generateSite;

        function generateMatchDetail(betType, betTypeName, isLive) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generateSite(betType, betTypeName, site, isLive) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isLive: isLive,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build([liveGridElement, nonliveGridElement], [data.Live, data.NonLive]);
                pane.data.isLive = true;
                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.Live, true);
                }
                renderGrid(liveGridElement, data.Live, true);

                pane.data.isLive = false;
                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.NonLive, false);
                }
                
                renderGrid(nonliveGridElement, data.NonLive, false);
                delete (pane.data.isLive);
                pane.compileAll();
            });
        }

        function renderGrid(gridElement, data, isLive) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: !isLive,
                exportExcelFunction: exportExcel
            };
            if (!isLive) {
                titleInfo.customButtons = showHideColumnBuilder.getButtonHtml();
            }

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
            gridElement.fanexGrid(data);
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') <= 3;
        }

        function createLinks(data, isLive) {
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