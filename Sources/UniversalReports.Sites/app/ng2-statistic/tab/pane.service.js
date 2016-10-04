import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('napPane', napPane);

    napPane.$inject = ['$log', '$compile', '$injector'];
    function napPane($log, $compile, $injector) {
        function Pane(data) {

            this.data = data;
            this.startDate = data.startDate;
            this.drilldownType = data.drilldownType === "undefined" ? "" : data.drilldownType;
            this.reportType = data.reportType;
            this.isDrilldown = data.isDrilldown;
            this.endDate = data.endDate;
            this.$scope = undefined;
            this.$element = undefined;
            this.generate = generate;
            this.show = show;
            this.compileAll = compileAll;
            this.compileLinks = compileLinks;
            this.compileDrilldown = compileDrilldown;
            this.getFileName = getFileName;

            this.templateUrl = 'app/ng2-statistic/shared/fanex-grid-with-title.html';
            this.controller = 'CommonController' ;// data.drilldownType === 'Grandtotal'? 'DrilldownController': 'CommonController';
            this.service = $injector.get("commonService");

            function generate() {
                this.$scope.generate();
            }

            function show() {
                var gridElement = this.$element.find('.freegrid');
                gridElement.fanexGrid('resizeGrid');
            }

            function getFileName() {
                return 'NG2_Statistic_Report_From_' + this.startDate.format('DD_MM_YYYY') + '_To_' + this.endDate.format('DD_MM_YYYY') + '.xls';
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