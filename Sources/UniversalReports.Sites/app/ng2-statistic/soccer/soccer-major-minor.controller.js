import angular from "angular";
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.NG2Statistic')
        .controller('SoccerMajorMinorController', SoccerMajorMinorController);

    SoccerMajorMinorController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerConstants', 'showHideColumnService'];
    function SoccerMajorMinorController($scope, $element, fanexGridService, soccerConstants, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        $scope.generate = generate;
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generateSoccerLiveNonLiveBetTypePane = generateSoccerLiveNonLiveBetTypePane;
        pane.data.isLive = (pane.data.soccerLiveNonLive == "Soccer Non-Live") ? soccerConstants.NonLive : soccerConstants.Live;

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnBuilder.build(gridElements, data);
                createLinksForMajorMinor(data);
                renderGrid(gridElements, data);
                pane.compileAll();
            });
        }

        function renderGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel,
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.bottomBorderWidth = 3;
            gridElement.fanexGrid(data);
        }

        function createLinksForMajorMinor(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLiveBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
            }
        }

        function generateSoccerLiveNonLiveBetTypePane(betTypeNameMajorMinor) {
            var data = {
                betTypeNameMajorMinor: betTypeNameMajorMinor,
                sportTypeName: betTypeNameMajorMinor
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerBetType', data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);