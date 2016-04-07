(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napTab', napTab);

    function napTab() {
        var directive = {
            restrict: 'EA',
            scope: {
                panes: '='
            },
            templateUrl: 'app/company-winloss/tab/tab.directive.html',
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$rootScope', '$injector', '$compile', '$log', 'companyWinlossService', 'breadcrumbService'];
    function controller($scope, $rootScope, $injector, $compile, $log, companyWinlossService, breadcrumbService) {
        var tab = new Tab($scope.panes);
        var vm = this;
        vm.tab = tab;

        $scope.$on('nap-filter-generate', function (event, data) {
            if (tab.panes.length === 0) {
                var mainPane = new Pane('main', data);
                tab.addPane(mainPane);
            } else {
                var activePane = tab.getActivePane();
                angular.extend(activePane.data, data);
                activePane.generate();
            }
        });

        function Tab(panes) {
            this.panes = angular.isDefined(panes) ? panes : [];
            this.addPane = addPane;
            this.getActivePane = getActivePane;
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
                tab.addPane(pane);
            }

            function generateBreadcrumbList() {
                var list = [];
                for (var i = 0; i < this.panes.length; i++) {
                    var pane = this.panes[i];
                    var isLast = i === this.panes.length - 1;
                    var title = pane.getTitle(isLast);
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

        function Pane(level, data) {
            this.level = level;
            this.data = data;
            this.$scope = undefined;
            this.$element = undefined;
            this.generate = generate;
            this.show = show;
            this.compileLinks = compileLinks;
            this.getTitle = getTitle;
            this.getFileName = getFileName;

            if (angular.isUndefined(this.level) || angular.isUndefined(this.data)) {
                $log.error('Invalid pane');
                return;
            }

            if (level === 'main') {
                this.templateUrl = 'app/company-winloss/shared/fanex-grid-with-title.html';
                this.controller = 'ProductController';
                this.service = $injector.get('productService');
            } else {
                var template = companyWinlossService.getTemplate(data, level);
                this.templateUrl = template.templateUrl;
                this.controller = template.controller;
                this.service = $injector.get(template.service);
            }

            function generate() {
                this.$scope.generate();
            }

            function show() {
                var gridElement = this.$element.find('.freegrid');
                gridElement.fanexGrid('resizeGrid');
            }

            function getTitle(isLast) {
                var data = this.data;
                switch (this.level) {
                    case 'main':
                        return isLast ? 'Product Win/Loss Report' : 'Main';

                    case 'product':
                        return data.productName + (isLast ? ' Product Win/Loss Report' : '');

                    case 'thirdPartyProduct':
                        return data.thirdPartyProductName + (isLast ? ' Product Win/Loss Report' : '');

                    case 'sportType':
                        return data.sportTypeName + (isLast ? ' Product Win/Loss Report' : '');

                    case 'matchDetail':
                        return data.betTypeName + (isLast ? ' Product Win/Loss Report' : '');

                    case 'site':
                        return data.betTypeName + ' | Product Win/Loss By ' + data.site + ' Site';
                }
            }

            function getFileName() {
                return 'Company_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
            }

            function compileLinks() {
                var elements = this.$element.find('.drill-down');
                $compile(elements)(this.$scope);
                elements = this.$element.find('.breadcrumb');
                $compile(elements)(this.$scope);
            }
        };
    }
})(angular);