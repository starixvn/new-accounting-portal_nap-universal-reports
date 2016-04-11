(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ThirdPartyProductController', ThirdPartyProductController);

    ThirdPartyProductController.$inject = ['$scope', '$element', 'fanexGridService'];
    function ThirdPartyProductController($scope, $element, fanexGridService) {
        var pane = $scope.pane;
        pane.getTitle = getTitle;
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.generate = generate;
        $scope.generateBetType = generateBetType;

        function getTitle(isLast) {
            var previousPane = tab.getPreviousPane(pane);
            return data.thirdPartyProductName + (isLast ? ' Product Win/Loss Report' : '');
        }

        function generateBetType(thirdPartyProduct, thirdPartyProductName) {
            var data = {
                thirdPartyProduct: thirdPartyProduct,
                thirdPartyProductName: thirdPartyProductName
            };
            angular.extend(data, pane.data);
            tab.goForward('thirdPartyProduct', data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                createLinks(data);
                renderGrid(data);
                pane.compileLinks();
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productColumn = data.bodyRows[i].Columns[0];
                var productId = productColumn.CustomAttr;
                var productName = productColumn.Value;
                productColumn.Value = '<a class="drill-down" href data-nap-click="generateBetType(' + productId + ',\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
            }
        }

        function renderGrid(data) {
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                showCollapseExpandButton: true,
                exportExcelFunction: exportExcel
            };

            data.titleInfo = titleInfo;
            data.defaultCollapseAllGroups = true;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);