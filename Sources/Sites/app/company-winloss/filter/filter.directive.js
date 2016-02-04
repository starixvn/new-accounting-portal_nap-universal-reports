(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: '/app/company-winloss/filter/filter.directive.html',
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
            vm.getDateRange = getDateRange;
            vm.updateDateRange = updateDateRange;

            vm.generate = function () {
                companyWinlossService.generate({});
            };

            vm.todayClicked = function () {
                vm.date = vm.today;
                vm.generate();
            };

            vm.yesterdayClicked = function () {
                vm.date = vm.yesterday;
                vm.generate();
            };

            vm.viewHistoryMode = function () {
                vm.normalMode = false;
            };

            vm.viewNormalMode = function () {
                vm.normalMode = true;
            };

            vm.getEndOfDay = function (date) {
                return moment.utc(date).endOf('day');
            };

            function getDateRange() {
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

            function updateDateRange(dateRange) {
                vm.date = dateRange.startDate;
                vm.startDate = dateRange.startDate;
                vm.endDate = dateRange.endDate;
            }
        }
    }
})();