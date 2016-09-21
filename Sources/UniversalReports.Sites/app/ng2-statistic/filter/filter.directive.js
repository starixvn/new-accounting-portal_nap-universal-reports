import angular from "angular";
import moment from "moment";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/ng2-statistic/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$rootScope', 'config', 'filterService'];
    function controller($scope, $rootScope, config, filterService) {
        /*jshint validthis: true */
        var vm = this;
        vm.minDate= moment("20130101", "YYYYMMDD");
        vm.reportType="daily";
        vm.currentLevel = 0;
        vm.normalMode = false;

        vm.today = config.today;
        vm.yesterday = config.yesterday;
        vm.date = config.today;
        vm.startDate = moment.utc(config.yesterday).startOf('month');
        vm.endDate = moment.utc(config.yesterday);

        vm.sportItems = [];
        vm.sportSettings={
            hasFilter: false,
            //checkedAll: true,
            sourceData: 'app/ng2-statistic/filter/sports.json',
            templateUrl: 'app/root/components/fanex-dropdowntree/fanex.dropdowntree.directive.template.html'
        };
        vm.sportTextSettings = {
            CheckAll: "ALL",
            CollapseExpanse: "Collapse/Expanse",
            CollapseBranch: "Collapse/Expanse this branch",
            NoItemChecked: "Select bet type",
            ItemsSelected: "# selected",
            NoData:"Select bet type"
        };

        vm.currencies=[];
        filterService.getCurrencies().then(function (data) {
            vm.currencies= data;
            vm.currency= 1;
        });

        vm.generate = generate;
        vm.todayClicked = todayClicked;
        vm.yesterdayClicked = yesterdayClicked;
        vm.viewNormalMode = viewNormalMode;
        vm.viewHistoryMode = viewHistoryMode;
        vm.getDateRange = getDateRange;

        function generate() {
            vm.dateRange = getDateRange();
            $rootScope.$broadcast('nap-filter-generate', vm.dateRange);
        }

        function todayClicked() {
            vm.date = vm.today;
            vm.generate();
        }

        function yesterdayClicked() {
            vm.date = vm.yesterday;
            vm.generate();
        }

        function viewNormalMode() {
            vm.normalMode = true;
            $('.filter-note').css('display', 'block');
            $rootScope.$broadcast('nap-filter-switch');
        }

        function viewHistoryMode() {
            vm.normalMode = false;
            $('.filter-note').css('display', 'none');
            $rootScope.$broadcast('nap-filter-switch');
        }

        function getDateRange() {
            if (vm.normalMode) {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.date,
                    endDate: vm.date
                };
            } else {
                return {
                    normalMode: vm.normalMode,
                    startDate: vm.startDate,
                    endDate: vm.endDate
                };
            }
        }
    }
})(angular);