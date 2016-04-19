(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('napTab', napTab);

    napTab.$inject = ['$rootScope', 'breadcrumbService', 'napPane'];
    function napTab($rootScope, breadcrumbService, Pane) {
        function Tab(panes) {
            this.panes = angular.isDefined(panes) ? panes : [];
            this.addPane = addPane;
            this.getActivePane = getActivePane;
            this.getPreviousPane = getPreviousPane;
            this.goBack = goBack;
            this.goForward = goForward;
            this.generateBreadcrumbList = generateBreadcrumbList;
            this.generateBreadcrumbHtml = generateBreadcrumbHtml;
            this.generateBreadcrumbText = generateBreadcrumbText;

            function addPane(pane) {
                this.panes.push(pane);
            }

            function getActivePane() {
                return this.panes[this.panes.length - 1];
            }

            function getPreviousPane(pane) {
                var previousPane = null;
                for (var i = 0; i < this.panes.length; i++) {
                    var currentPane = this.panes[i];
                    if (currentPane === pane) {
                        break;
                    }

                    previousPane = currentPane;
                }

                return previousPane;
            }

            function goBack(index) {
                this.panes = this.panes.slice(0, index + 1);
                var activePane = this.getActivePane();
                var dateRange = {
                    startDate: activePane.data.startDate,
                    endDate: activePane.data.endDate
                };
                $rootScope.$broadcast('nap-filter-date', dateRange);
            }

            function goForward(level, data) {
                var pane = new Pane(level, data);
                this.addPane(pane);
            }

            function generateBreadcrumbList() {
                var list = [];
                for (var i = 0; i < this.panes.length; i++) {
                    var pane = this.panes[i];
                    var isLast = i === this.panes.length - 1;
                    var title = pane.service.getTitle(pane.data, isLast);
                    list.push(title);
                }

                return list;
            }

            function generateBreadcrumbHtml() {
                var list = this.generateBreadcrumbList();
                return breadcrumbService.generateHtml(list);
            }

            function generateBreadcrumbText() {
                var list = this.generateBreadcrumbList();
                return breadcrumbService.generateText(list);
            }
        }

        return Tab;
    }
})(angular);