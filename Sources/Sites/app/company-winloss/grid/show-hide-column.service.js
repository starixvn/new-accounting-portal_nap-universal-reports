(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = ['$log'];
    function showHideColumnService($log) {
        var defaultOptions = {
            enableHiddenColumns: false,
            hiddenColumns: [1, 2]
        };
        var customButtonHtml = '<input type="button" class="btExpand customized collapsed nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
        var service = {
            customButtonHtml: customButtonHtml,
            build: build
        };
        return service;

        function build($scope, listOfGridElements, listOfGridOptions, options) {
            options = angular.extend({}, defaultOptions, options);
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
                gridOptions.hiddenColumns = options.hiddenColumns;
                gridOptions.enableHiddenColumns = options.enableHiddenColumns;
            }

            function showHideColumns($event) {
                var target = angular.element($event.target);
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridElement = listOfGridElements[i];
                    var gridOptions = listOfGridOptions[i];
                    if (options.enableHiddenColumns) {
                        gridElement.fanexGrid("hideColumns", gridOptions, options.hiddenColumns);
                    } else {
                        gridElement.fanexGrid("hideColumns", gridOptions, []);
                    }
                }

                options.enableHiddenColumns = !options.enableHiddenColumns;
                if (options.enableHiddenColumns) {
                    target.removeClass('collapsed').addClass('expanded');
                } else {
                    target.removeClass('expanded').addClass('collapsed');
                }
                $scope.pane.compileLinks();
            }
        }
    }
})(angular);