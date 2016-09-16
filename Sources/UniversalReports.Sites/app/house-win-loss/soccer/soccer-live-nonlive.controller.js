import angular from "angular";
(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerLiveNonLiveController', SoccerLiveNonLiveController);

    SoccerLiveNonLiveController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerMajorMinorService', 'soccerLiveNonLiveService', 'showHideColumnService', 'soccerConstants'];
    function SoccerLiveNonLiveController($scope, $element, fanexGridService, soccerMajorMinorService, soccerLiveNonLiveService, showHideColumnService, soccerConstants) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var getTitleWhenMajorMinor = soccerMajorMinorService.getTitle;
        var getTitleWhenLiveNonLive = pane.service.getTitle;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateSoccerLiveNonLivePane = generateSoccerLiveNonLivePane;
        $scope.generateSoccerBetTypePane = generateSoccerBetTypePane;
        pane.data.isLive = soccerConstants.LiveNonLive;

        function generate() {
            var majorMinorGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(majorMinorGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnBuilder.build([majorMinorGridElement, liveNonLiveGridElement], [majorMinorGridOptions, liveNonLiveGridOptions]);

                    createLinksForMajorMinor(majorMinorGridOptions);
                    pane.service.getTitle = getTitleWhenMajorMinor;
                    renderGrid(majorMinorGridElement, majorMinorGridOptions);

                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    pane.service.getTitle = getTitleWhenLiveNonLive;
                    renderGrid(liveNonLiveGridElement, liveNonLiveGridOptions);

                    pane.compileAll();
                }
            };
            pane.service.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
                renderAll();
            });

            pane.service.getMajorMinorData(pane.data).then(function (data) {
                majorMinorGridOptions = data;
                renderAll();
            });
        }

        function renderGrid(gridElement, data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: false,
                exportExcelFunction: exportExcel
            };
            if (gridElement === majorMinorGridElement) {
                titleInfo.customButtons = showHideColumnBuilder.getButtonHtml();
                titleInfo.showExcelButton = true;
            }

            data.titleInfo = titleInfo;
            data.bottomBorderWidth = 3;
            gridElement.fanexGrid(data);
        }

        function createLinksForMajorMinor(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeNameMajorMinor = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerBetTypePane(\'' + betTypeNameMajorMinor + '\')">' + betTypeNameMajorMinor + '</a>';
            }
        }

        function generateSoccerBetTypePane(betTypeNameMajorMinor) {
            var data = {
                betTypeNameMajorMinor: betTypeNameMajorMinor,
                sportTypeName: betTypeNameMajorMinor
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerBetType', data);
        }

        function createLinksForLiveNonLive(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var soccerLiveNonLive = betTypeRow.Columns[0].Value;
                betTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSoccerLiveNonLivePane(\'' + soccerLiveNonLive + '\')">' + soccerLiveNonLive + '</a>';
            }
        }

        function generateSoccerLiveNonLivePane(soccerLiveNonLive) {
            var data = {
                soccerLiveNonLive: soccerLiveNonLive
            };
            angular.extend(data, pane.data);

            tab.goForward('soccerMajorMinor', data);
        }

        function exportExcel() {

            pane.service.getTitle = getTitleWhenMajorMinor;
            var majorMinorTitle = tab.generateBreadcrumbText();

            pane.service.getTitle = getTitleWhenLiveNonLive;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            

            soccerLiveNonLiveService.exportExcel(majorMinorTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);