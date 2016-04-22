(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerBetTypeController', SoccerBetTypeController);

    SoccerBetTypeController.$inject = ['$scope', '$element', 'companyWinlossService', 'fanexGridService', 'showHideColumnService', 'soccerConstants'];
    function SoccerBetTypeController($scope, $element, companyWinlossService, fanexGridService, showHideColumnService, soccerConstants) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateSite = generateSite;
        $scope.generateMatchDetail = generateMatchDetail;
        
        function buildIsHedge(betTypeName)
        {
            var isHedge = false;

            if (betTypeName && betTypeName.indexOf("(hedge)") > -1)
            {
                isHedge = true;
            }

            return isHedge;
        }

        function generateSite(betType, betTypeName, site) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                site: site,
                isHedge: buildIsHedge(betTypeName),
                sportType: soccerConstants.SoccerSportType
            };
            angular.extend(data, pane.data);
            tab.goForward('site', data);
        }

        function generateMatchDetail(betType, betTypeName) {
            var data = {
                betType: betType,
                betTypeName: betTypeName,
                isHedge: buildIsHedge(betTypeName),
                sportType: soccerConstants.SoccerSportType
            };
            angular.extend(data, pane.data);
            tab.goForward('matchDetail', data);
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
            var betTypeId;
            var template = companyWinlossService.getTemplate(pane.data, 'matchDetail');
            var hasDetailDrilldown = angular.isDefined(template);
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                betTypeId = betTypeRow.Columns[0].CustomAttr;

                if (betTypeRow.SubRows) {
                    if (hasDetailDrilldown) {
                        betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateMatchDetail(' + betTypeId + ',\'' + betTypeName.replace('\'', '\\\'') + '\')">' + betTypeName + '</a>';
                    }

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