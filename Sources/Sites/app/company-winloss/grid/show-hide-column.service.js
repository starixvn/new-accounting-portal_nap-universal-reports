(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = ['$log'];
    function showHideColumnService($log) {
        // some notes for fanex grid: enableHiddenColumns = false -> hiddenColumns is affected
        // if hidding columns, then also collapsing tree items
        // so: defaultCollapseAllGroups = !enableHiddenColumns
        // however, defaultCollapseAllGroups is meaningless when using function 'hideColumns' and its value must be true
        var defaultOptions = {
            enableHiddenColumns: false, // default is hidding columns
            hiddenColumns: [1, 2] // default hidden column indexes
        };
        var service = {
            getButtonHtml: getButtonHtml,
            build: build
        };
        return service;

        function getButtonHtml() {
            var buttonClass = defaultOptions.enableHiddenColumns ? 'expanded' : 'collapsed';
            return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
        }

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
                gridOptions.defaultCollapseAllGroups = !gridOptions.enableHiddenColumns;
            }

            function showHideColumns($event) {
                // togging enableHiddenColumns
                options.enableHiddenColumns = !options.enableHiddenColumns;
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridElement = listOfGridElements[i];
                    var gridOptions = listOfGridOptions[i];
                    gridOptions.enableHiddenColumns = options.enableHiddenColumns;
                    gridOptions.defaultCollapseAllGroups = true;
                    if (gridOptions.enableHiddenColumns) {
                        gridElement.fanexGrid("hideColumns", gridOptions, []);
                    } else {
                        gridElement.fanexGrid("hideColumns", gridOptions, options.hiddenColumns);
                    }
                }

                $scope.pane.compileLinks();
                var target = angular.element($event.target);
                if (options.enableHiddenColumns) {
                    target.removeClass('collapsed').addClass('expanded');
                } else {
                    target.removeClass('expanded').addClass('collapsed');
                }
                defaultOptions.enableHiddenColumns = options.enableHiddenColumns;
            }
        }
    }
})(angular);