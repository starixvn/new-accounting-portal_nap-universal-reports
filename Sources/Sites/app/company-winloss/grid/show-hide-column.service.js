(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('showHideColumnService', showHideColumnService);

    showHideColumnService.$inject = ['$log', '$timeout'];
    function showHideColumnService($log, $timeout) {
        Builder.defaultOptions = {
            enableHiddenColumns: true, // default is hidding columns
            hiddenColumns: [1, 2] // default hidden column indexes
        };
        function Builder(pane) {
            var options = pane.showHideColumnOptions;
            this.getButtonHtml = getButtonHtml;
            this.build = build;
            this.toggle = toggle;
            this.updateOptions = updateOptions;

            function toggle() {
                var showHideButton = pane.$element.find('.btExpand').first();
                var isCollapsed = showHideButton.hasClass('collapsed');
                if (isCollapsed !== options.enableHiddenColumns) {
                    options.enableHiddenColumns = !options.enableHiddenColumns;
                    $timeout(function () {
                        showHideButton.trigger('click');
                    });
                }
            }

            function updateOptions(newOptions) {
                pane.showHideColumnOptions = angular.extend(options, newOptions);
            }

            function getButtonHtml() {
                var buttonClass = !options.enableHiddenColumns ? 'expanded' : 'collapsed';
                return '<input type="button" class="btExpand customized ' + buttonClass + ' nap-component" title="Collapse/Expand" data-ng-click="showHideColumns($event)" />';
            }

            function build(listOfGridElements, listOfGridOptions) {
                if (!angular.isArray(listOfGridElements)) {
                    listOfGridElements = [listOfGridElements];
                }
                if (!angular.isArray(listOfGridOptions)) {
                    listOfGridOptions = [listOfGridOptions];
                }
                if (listOfGridElements.length !== listOfGridOptions.length) {
                    $log.error('Invalid parameters');
                    return;
                }

                pane.$scope.showHideColumns = showHideColumns;
                for (var i = 0; i < listOfGridOptions.length; i++) {
                    var gridOptions = listOfGridOptions[i];
                    gridOptions.hiddenColumns = options.hiddenColumns;
                    gridOptions.enableHiddenColumns = !options.enableHiddenColumns;
                    gridOptions.defaultCollapseAllGroups = !gridOptions.enableHiddenColumns;
                }

                function showHideColumns($event) {
                    options.enableHiddenColumns = !options.enableHiddenColumns;
                    for (var i = 0; i < listOfGridOptions.length; i++) {
                        var gridElement = listOfGridElements[i];
                        var gridOptions = listOfGridOptions[i];
                        gridOptions.enableHiddenColumns = options.enableHiddenColumns;
                        gridOptions.defaultCollapseAllGroups = true;
                        if (gridOptions.enableHiddenColumns) {
                            gridElement.fanexGrid("hideColumns", gridOptions, options.hiddenColumns);
                        } else {
                            gridElement.fanexGrid("hideColumns", gridOptions, []);
                        }
                    }

                    pane.compileDrilldown();
                    var target = angular.element($event.target);
                    if (!options.enableHiddenColumns) {
                        target.removeClass('collapsed').addClass('expanded');
                    } else {
                        target.removeClass('expanded').addClass('collapsed');
                    }
                }
            }
        };

        return Builder;
    }
})(angular);