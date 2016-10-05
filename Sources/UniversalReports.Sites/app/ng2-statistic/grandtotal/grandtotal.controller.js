import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('GrandtotalController', GrandtotalController);

    GrandtotalController.$inject = ['$rootScope', '$element', '$scope', 'fanexGridService', 'ngDialog','$injector'];
    function GrandtotalController($rootScope, $element, $scope, fanexGridService, ngDialog, $injector) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        $scope.generate = generate;

        function generate() {
            pane.service.getData(pane).then(function(data){
                renderPopup(data);
            });
        }

        function exportExcelGrandTotal(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane, pane.getFileName());
        }

        function renderPopup(data){
            var titleInfo = {
                text: tab.generateBreadcrumbHtml(),
                showExcelButton: true,
                exportExcelFunction: exportExcelGrandTotal,
            };
            data.titleInfo = titleInfo;            
            ngDialog.open({template: 'templateId',
                plain: false,                
                width: 1190,
                closeByDocument: false,
                data: data                
            });

            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
                $('#myGrid').fanexGrid(data);
            });
        }
    }
})(angular);