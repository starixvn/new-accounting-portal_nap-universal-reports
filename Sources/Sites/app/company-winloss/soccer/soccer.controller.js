(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SoccerController', SoccerController);

    SoccerController.$inject = ['$scope', '$element', 'fanexGridService', 'soccerLiveNonLiveService', 'showHideColumnService', 'soccerSportTypeService', 'soccerConstants'];
    function SoccerController($scope, $element, fanexGridService, soccerLiveNonLiveService, showHideColumnService, soccerSportTypeService, soccerConstants) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var getTitleWhenMajorMinor = pane.service.getTitle;
        var getTitleWhenLiveNonLive = soccerLiveNonLiveService.getTitle;
        var gridElements = $element.find('.freegrid');
        var majorMinorGridElement = angular.element(gridElements[0]);
        var liveNonLiveGridElement = angular.element(gridElements[1]);
        $scope.generate = generate;
        $scope.generateSoccerLiveNonLivePane = generateSoccerLiveNonLivePane;
        $scope.generateSoccerBetTypePane = generateSoccerBetTypePane;
        pane.data.isLive = soccerConstants.LiveNonLive;
        
        function generate() {
            var majorMinorGridOptions,
                liveNonLiveGridOptions;
            var renderAll = function () {
                if (angular.isDefined(majorMinorGridOptions) && angular.isDefined(liveNonLiveGridOptions)) {
                    showHideColumnService.build($scope, [majorMinorGridElement, liveNonLiveGridElement], [majorMinorGridOptions, liveNonLiveGridOptions]);
                    
                    createLinksForMajorMinor(majorMinorGridOptions);
                    renderGrid(majorMinorGridElement, majorMinorGridOptions);

                    pane.service.getTitle = getTitleWhenLiveNonLive;
                    createLinksForLiveNonLive(liveNonLiveGridOptions);
                    renderGrid(liveNonLiveGridElement, liveNonLiveGridOptions);
                    pane.service.getTitle = getTitleWhenMajorMinor;

                    pane.compileAll();
                }
            };
            pane.service.getData(pane.data).then(function (data) {
                majorMinorGridOptions = data;
                renderAll();
            });

            soccerLiveNonLiveService.getData(pane.data).then(function (data) {
                liveNonLiveGridOptions = data;
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
                titleInfo.customButtons = showHideColumnService.customButtonHtml;
                titleInfo.showExcelButton = true;
            }

            data.titleInfo = titleInfo;
            //data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            data.defaultCollapseAllGroups = true;
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
                betTypeNameMajorMinor: betTypeNameMajorMinor
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

            tab.goForward('soccerLiveNonLive', data);
        }

        function exportExcel() {            
            var majorMinorTitle = tab.generateBreadcrumbText();

            pane.service.getTitle = getTitleWhenLiveNonLive;
            var liveNonLiveTitle = tab.generateBreadcrumbText();
            pane.service.getTitle = getTitleWhenMajorMinor;

            soccerSportTypeService.exportExcel(majorMinorTitle, liveNonLiveTitle, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);