(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ParlayBetTypeController', ParlayBetTypeController);

    ParlayBetTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService', 'legacyService'];
    function ParlayBetTypeController($scope, $element, fanexGridService, showHideColumnService, legacyService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var parlaySportType = 9;
        var systemParlayBetType = 29;
        var mixParlayBetType = 9;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.viewMixParlayWindow = viewMixParlayWindow;

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function viewMixParlayWindow() {
            var url = '/WinLoss/DailyMixParlayWinLoss_2hLink/Index?startDate=' + pane.data.startDate.format('MM/DD/YYYY') + '&endDate=' + pane.data.endDate.format('MM/DD/YYYY') + '&SportId=' + parlaySportType + '&IsRedirect=true&BetType=' + mixParlayBetType;
            url = legacyService.resolveUrl(url);
            location.href = url;
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnService.build($scope, gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var betTypeId = parseInt(betTypeRow.Columns[0].CustomAttr);
                if (betTypeId === systemParlayBetType) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + "ALL" + '\')">' + betTypeName + '</a>';
                    for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                        var siteRow = data.bodyRows[i].SubRows[j];
                        var siteName = siteRow.Columns[0].Value;
                        siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                    }
                } else if (betTypeId === mixParlayBetType) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="viewMixParlayWindow()">' + betTypeName + '</a>';
                }
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnService.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);