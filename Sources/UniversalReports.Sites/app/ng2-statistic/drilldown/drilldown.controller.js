import angular from "angular";
import numeral from "numeral";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .controller('DrilldownController', DrilldownController);

    DrilldownController.$inject = ['$rootScope','$element', '$scope', 'fanexGridService', 'ngDialog'];
    function DrilldownController($rootScope, $element, $scope, fanexGridService, ngDialog) {
        var pane = $scope.pane;
        var tab = $scope.tab;
        $scope.generate = generate;
        
        function generatePopup() {
            pane.service.getData(pane.data).then(function(data){
                renderPopup(data);
            });
        }

        function renderPopup(data){
            var titleInfo = {
                text: "GRAND TOTAL BY CURRENCY",
                showExcelButton: true,
                exportExcelFunction: exportExcel,
            };
            data.titleInfo = titleInfo;            
            ngDialog.open({template: 'templateId',
                plain: false,                
                width: 1190,
                closeByDocument: false,
                data: data,
                
            });

            $rootScope.$on('ngDialog.opened', function (e, $dialog) {
                $('#myGrid').fanexGrid(data);
            });
        }

        function exportExcel(){
            var title = tab.generateBreadcrumbText();
            pane.service.exportExcel(title, pane.data, pane.getFileName());
        }
    }
})(angular);