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
        $scope.viewSetting = {};

        function generate(viewSetting) {
            $scope.viewSetting = viewSetting;
            pane.service.getData(viewSetting, pane.data).then(function (data) {
                showHideColumnBuilder.build([liveGridElement, nonliveGridElement], [data.Live, data.NonLive]);
                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.Live, true);
                }

                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data.NonLive, false);
                }

                renderLiveGrid(liveGridElement, data.Live);
                renderNonLiveGrid(nonliveGridElement, data.NonLive);

                pane.compileAll();
            });
        }

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

        function renderNonLiveGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtmlWithLastItemReplacement("Number Game Non-Live"),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons : showHideColumnBuilder.getButtonHtml()
            };
            
            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
            gridElement.fanexGrid(data);
        }

        function renderLiveGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtmlWithLastItemReplacement("Number Game Live"),
                showCollapseExpandButton: true,
                showExcelButton: false
            };
           
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
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + betTypeName + '</a>';

                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace(/'/g, "\\'") + '\',\'' + siteName.replace(/'/g, "\\'") + '\',' + isLive + ')">' + siteName + '</a>';
                }
            }
        }

        function exportExcel() {
            var nonLiveTitle = tab.generateBreadcrumbTextWithLastItemReplacement("Number Game Non-Live");
            var liveTitle = tab.generateBreadcrumbTextWithLastItemReplacement("Number Game Live");
            var httpData = {};
            angular.extend(httpData, pane.data);
            angular.extend(httpData, { liveTitle:liveTitle, nonLiveTitle: nonLiveTitle });

            pane.service.exportExcel($scope.viewSetting, httpData, pane.getFileName());
        }
    }
})(angular, undefined);