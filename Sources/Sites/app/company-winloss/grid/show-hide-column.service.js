(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = [];
    function showHideColumnService() {
        var enableHiddenColumns = false;
        var hiddenColumns = [1, 2];
        var customButtonHtml = '<input type="button" class="btn-show-hide nap-component" title="Show/Hide" data-ng-click="showHideColumns()" />';
        var service = {
            customButtonHtml: customButtonHtml,
            build: build
        };
        return service

        function build($scope, gridElement, gridOptions) {
            gridOptions.hiddenColumns = hiddenColumns;
            gridOptions.enableHiddenColumns = enableHiddenColumns;
            $scope.showHideColumns = showHideColumns;

            function showHideColumns() {
                if (enableHiddenColumns) {
                    gridElement.fanexGrid("hideColumns", gridOptions, hiddenColumns);
                } else {
                    gridElement.fanexGrid("hideColumns", gridOptions, []);
                }
                enableHiddenColumns = !enableHiddenColumns;
                $scope.pane.compileLinks();
            }
        }
    }
})(angular);