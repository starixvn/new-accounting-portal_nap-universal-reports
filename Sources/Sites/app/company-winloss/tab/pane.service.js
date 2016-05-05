(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('napPane', napPane);

    napPane.$inject = ['$log', '$compile', '$injector', 'companyWinlossService', 'showHideColumnService'];
    function napPane($log, $compile, $injector, companyWinlossService, showHideColumnService) {
        function Pane(level, data) {
            this.level = level;
            this.data = data;
            this.$scope = undefined;
            this.$element = undefined;
            this.generate = generate;
            this.show = show;
            this.compileAll = compileAll;
            this.compileLinks = compileLinks;
            this.compileDrilldown = compileDrilldown;
            this.getFileName = getFileName;
            this.showHideColumnOptions = showHideColumnService.defaultOptions;

            if (angular.isUndefined(this.level) || angular.isUndefined(this.data)) {
                $log.error('Invalid pane');
                return;
            }

            var template = companyWinlossService.getTemplate(data, level);
            this.templateUrl = template.templateUrl;
            this.controller = template.controller;
            this.service = $injector.get(template.service);

            function generate() {
                this.$scope.generate();
            }

            function show() {
                var gridElement = this.$element.find('.freegrid');
                gridElement.fanexGrid('resizeGrid');
            }

            function getFileName() {
                return 'Company_Win_Loss_By_Products_From_' + this.data.startDate.format('DD_MM_YYYY') + '_To_' + this.data.endDate.format('DD_MM_YYYY') + '.xls';
            }

            function compileAll() {
                this.compileLinks();
                var elements = this.$element.find('.nap-component');
                $compile(elements)(this.$scope);
            }

            function compileLinks() {
                var elements = this.$element.find('.drill-down');
                $compile(elements)(this.$scope);
                elements = this.$element.find('.breadcrumb');
                $compile(elements)(this.$scope);
            }

            function compileDrilldown() {
                var elements = this.$element.find('.drill-down');
                $compile(elements)(this.$scope);
            }
        }

        return Pane;
    }
})(angular);