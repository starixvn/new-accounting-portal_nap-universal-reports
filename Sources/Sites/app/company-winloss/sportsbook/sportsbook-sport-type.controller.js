(function (angular, undefined) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportsbookSportTypeController', SportsbookSportTypeController);

    SportsbookSportTypeController.$inject = ['$scope', '$element', 'fanexGridService', 'showHideColumnService'];
    function SportsbookSportTypeController($scope, $element, fanexGridService, showHideColumnService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(sportType, sportTypeName, isLive) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName,
                isLive: isLive
            };
            angular.extend(data, pane.data);
            tab.goForward('betType', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                showHideColumnService.build($scope, gridElement, data);
                createLinks(data);
                renderGrid(data);
                pane.compileAll();
            });
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

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeName = sportTypeRow.Columns[0].Value;
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular, undefined);