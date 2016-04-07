(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .directive('napFilter', napFilter);

    function napFilter() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/company-winloss/filter/filter.directive.html',
            replace: true,
            controller: ['$scope', '$rootScope', 'config', 'companyWinlossService', controller],
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        function controller($scope, $rootScope, config, companyWinlossService) {
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
            $scope.$on('nap-filter-date', function (event, data) {
                updateDateRange(data);
            });

            function generate() {
                vm.dateRange = createDateRange();
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
                if (vm.dateRange.startDate === vm.dateRange.endDate) {
                    vm.normalMode = true;
                    vm.date = vm.dateRange.startDate;
                } else {
                    vm.normalMode = false;
                    vm.startDate = vm.dateRange.startDate;
                    vm.endDate = vm.dateRange.endDate;
                }
            }

            function updateDateRange(dateRange) {
                vm.dateRange = dateRange;
                reloadDateRange();
            }
        }
    }
})(angular);