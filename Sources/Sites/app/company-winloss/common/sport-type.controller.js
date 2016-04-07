(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('SportTypeController', SportTypeController);

    SportTypeController.$inject = ['$injector', '$scope', '$element', 'fanexGridService'];
    function SportTypeController($injector, $scope, $element, fanexGridService) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');

        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function generateBetType(sportType, sportTypeName) {
            var data = {
                sportType: sportType,
                sportTypeName: sportTypeName
            };
            angular.extend(data, pane.data);
            tab.goForward('sportType', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                createLinks(data);
                renderGrid(data);
                pane.compileLinks();
            });
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                var sportTypeName = sportTypeRow.Columns[0].Value;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName.replace('\'', '\\\'') + '\')">' + sportTypeName + '</a>';
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showCollapseExpandButton: true,
                showExcelButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }
    }
})(angular);