(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('MetricGamingLiveNonLiveController', MetricGamingLiveNonLiveController);
    MetricGamingLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'metricGamingLiveNonLiveService', 'showHideColumnService', 'titleService'];

    function MetricGamingLiveNonLiveController($scope, $element, fanexGridService, metricGamingLiveNonLiveService, showHideColumnService, titleService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var getProductTitle = titleService.getProductTitle;
        var getProductLiveNonLiveTitle = pane.service.getTitle;
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var betTypeGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;
        $scope.generateMatchDetail = generateMatchDetail;
        $scope.generateSite = generateSite;

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

        function generateSite(betType, betTypeName, site, isHegde) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site,
                isHegde: isHegde
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generate() {
            var betTypeGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(betTypeGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnBuilder.build([betTypeGridElement, liveNonLiveGridElement], [betTypeGridOptions, liveNonLiveGridOptions]);
                    if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                        createLinksForBetType(betTypeGridOptions);
                    }
                    renderGridForBetType(betTypeGridOptions);
                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    renderGridForLiveNonLive(liveNonLiveGridOptions);
                    pane.compileAll();
                }
            };

            pane.service.getBetTypeData(pane.data).then(function (data) {
                betTypeGridOptions = data;
                renderAll();
            });

            pane.service.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });
        }

        function renderGridForBetType(data) {
            pane.service.getTitle = getProductTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(betTypeGridElement, true);
            betTypeGridElement.fanexGrid(data);
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') < 3;
        }

        function renderGridForLiveNonLive(data) {
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false
            };

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(liveNonLiveGridElement, true);
            liveNonLiveGridElement.fanexGrid(data);
        }

        function createLinksForBetType(data) {
            var betTypeId;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var isHegde = betTypeName.match("hegde") ? true : false;
                betTypeId = betTypeRow.Columns[0].CustomAttr;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var siteName = siteRow.Columns[0].Value;
                    siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\',' + isHegde + ')">' + siteName + '</a>';
                }
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
            pane.service.getTitle = getProductTitle;
            var sportTypeTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getProductLiveNonLiveTitle;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            metricGamingLiveNonLiveService.exportExcel(sportTypeTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);