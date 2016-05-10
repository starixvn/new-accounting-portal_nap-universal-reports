(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$element', '$scope', 'fanexGridService', 'companyWinlossService', 'showHideColumnService'];
    function ProductController($element, $scope, fanexGridService, companyWinlossService, showHideColumnService) {
        var pane = $scope.pane;
        var showHideColumnBuilder = new showHideColumnService(pane);
        var tab = $scope.tab;
        var gridElement = $element.find('.freegrid');
        $scope.show = showHideColumnBuilder.toggle;
        $scope.generate = generate;
        $scope.generateProduct = generateProduct;

        function generateProduct(productName) {
            var data = {
                productName: productName
            };
            angular.extend(data, pane.data);
            var level = companyWinlossService.getTemplateSetting(productName)['product'];
            tab.goForward(level, data);
        }

        function generate() {
            pane.service.getData(pane.data).then(function (data) {
                updateFooterData(data);
                showHideColumnBuilder.build(gridElement, data);
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
                customButtons: showHideColumnBuilder.getButtonHtml()
            };

            data.titleInfo = titleInfo;
            data.gridExpandHeight = fanexGridService.calculateExpandHeight(gridElement, true);
            gridElement.fanexGrid(data);
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var productRow = data.bodyRows[i];
                var customAttr = productRow.CustomAttr;
                if (customAttr === 'product') {
                    var productName = productRow.Columns[0].Value;
                    productRow.Columns[0].Value = '<a class="drill-down" href data-nap-click="generateProduct(\'' + productName.replace('\'', '\\\'') + '\')">' + productName + '</a>';
                }
            }
        }

        function updateFooterData(data) {
            trimNote(data);
            appendNote(data);

            function trimNote(data) {
                var footerRows = data.footerRows;
                footerRows.splice(3, footerRows.length - 3);
            }

            function appendNote(data) {

                var reportNote = "* Sportsbook Total: Sportsbook Live + Sportsbook Non-Live + Parlay + Outright" +
                                 "<br/>* Grand Total: Sportsbook Total + Number Game + Live Casino + Casino + Virtual Sports + Keno + Racing +  Bingo + Bettrade + Colossus Bets";

                var noteRow = {
                    Columns: [{
                        Name: "Main",
                        Value: reportNote,
                        MergeColNumber: 13,
                        CellAlign: "left",
                        TdClass: "grand-total-note"
                    }]
                };

                data.footerRows.push(noteRow);
            }
        }
        function exportExcel() {
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);