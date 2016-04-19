(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = ['$log'];
    function showHideColumnService($log) {
        var enableHiddenColumns = false;
        var hiddenColumns = [1, 2];
        var customButtonHtml = '<input type="button" class="btn-show-hide nap-component" title="Show/Hide" data-ng-click="showHideColumns()" />';
        var service = {
            customButtonHtml: customButtonHtml,
            build: build
        };
        return service

        function build($scope, listOfGridElements, listOfGridOptions) {
            if (!angular.isArray(listOfGridElements)) {
                listOfGridElements = [listOfGridElements];
            }
            if (!angular.isArray(listOfGridOptions)) {
                listOfGridOptions = [listOfGridOptions];
            }
            if (listOfGridElements.length !== listOfGridOptions.length) {
                $log.error('Invalid parameters');
            }

            $scope.showHideColumns = showHideColumns;
            for (var i = 0; i < listOfGridOptions.length; i++) {
                var gridOptions = listOfGridOptions[i];
                gridOptions.hiddenColumns = hiddenColumns;
                gridOptions.enableHiddenColumns = enableHiddenColumns;
            }

            function showHideColumns() {
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridElement = listOfGridElements[i];
                    var gridOptions = listOfGridOptions[i];
                    if (enableHiddenColumns) {
                        gridElement.fanexGrid("hideColumns", gridOptions, hiddenColumns);
                    } else {
                        gridElement.fanexGrid("hideColumns", gridOptions, []);
                    }
                }

                enableHiddenColumns = !enableHiddenColumns;
                $scope.pane.compileLinks();
            }
        }
    }
})(angular);