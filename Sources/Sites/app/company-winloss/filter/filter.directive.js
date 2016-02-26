(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/company-winloss/filter/filter.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope', 'config', 'companyWinlossService'];
        function controller($scope, config, companyWinlossService) {
            companyWinlossService.filterModel = this;
            /*jshint validthis: true */
            var vm = this;
            vm.currentLevel = 0;
            vm.normalMode = true;
            vm.today = config.today;
            vm.yesterday = config.yesterday;
            vm.date = config.today;
            vm.startDate = moment.utc(config.today).startOf('month');
            vm.endDate = config.today;
            vm.generate = generate;
            vm.todayClicked = todayClicked;
            vm.yesterdayClicked = yesterdayClicked;
            vm.viewNormalMode = viewNormalMode;
            vm.viewHistoryMode = viewHistoryMode;
            vm.dateRange = createDateRange();
            vm.getDateRange = getDateRange;
            vm.reloadDateRange = reloadDateRange;
            vm.updateDateRange = updateDateRange;

            function generate() {
                vm.dateRange = createDateRange();
                companyWinlossService.generate({});
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
            }

            function viewHistoryMode() {
                vm.normalMode = false;
            }

            function createDateRange() {
                if (vm.normalMode) {
                    return {
                        startDate: vm.date,
                        endDate: vm.date
                    };
                } else {
                    return {
                        startDate: vm.startDate,
                        endDate: vm.endDate
                    };
                }
            }

            function getDateRange() {
                return vm.dateRange;
            }

            function reloadDateRange() {
                vm.date = vm.dateRange.startDate;
                vm.startDate = vm.dateRange.startDate;
                vm.endDate = vm.dateRange.endDate;
            }

            function updateDateRange(dateRange) {
                vm.dateRange = dateRange;
                reloadDateRange();
            }
        }
    }
})();