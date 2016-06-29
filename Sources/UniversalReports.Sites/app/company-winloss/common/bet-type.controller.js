(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('BetTypeController', BetTypeController);

    BetTypeController.$inject = ['$scope', '$element', 'companyWinlossService', 'fanexGridService', 'showHideColumnService'];
    function BetTypeController($scope, $element, companyWinlossService, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.generateMatchDetail = generateMatchDetail;

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site,
                isHedge: betTypeName && betTypeName.indexOf("(hedge)") > -1
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isHedge: betTypeName && betTypeName.indexOf("(hedge)") > -1
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElement, data);

                if (isDateRangeInThreeDays(pane.data.startDate, pane.data.endDate)) {
                    createLinks(data);
                }

                renderGrid(data);
                pane.compileAll();
            });
        }

        function isDateRangeInThreeDays(startDate, endDate) {
            return endDate.diff(startDate, 'days') < 3;
        }

        function createLinks(data) {
            var template = companyWinlossService.getTemplate(pane.data, 'matchDetail');
            var hasDetailDrilldown = angular.isDefined(template);
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                var betTypeId = betTypeRow.Columns[0].CustomAttr;
                var isTotalRow = betTypeName == "Total";
                var enableLink = !isTotalRow && betTypeRow.SubRows;
                if (enableLink && hasDetailDrilldown) {
                    betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                }
                if (enableLink) {
                    for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                        var siteRow = data.bodyRows[i].SubRows[j];
                        var siteName = siteRow.Columns[0].Value;
                        siteRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\',\'' + siteName.replace('\'', '\\\'') + '\')">' + siteName + '</a>';
                    }
                }

            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
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