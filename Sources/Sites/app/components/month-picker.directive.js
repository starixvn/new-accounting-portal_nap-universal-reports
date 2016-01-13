(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .directive('napMonthPicker', napMonthPicker);

    function napMonthPicker() {
        var directive = {
            restrict: 'EA',
            templateUrl: '/app/components/month-picker.directive.html',
            scope: {
                fromDate: '=',
                toDate: '='
            },
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$log'];
        function controller($log) {
            var vm = this;
            var fromDate = moment.utc(vm.fromDate);
            var toDate = moment.utc(vm.toDate);
            if (fromDate.year() !== toDate.year() || fromDate.month() !== toDate.month()) {
                $log.error('fromDate and toDate are not same month and year');
                return;
            }

            generateModel();

            vm.goPreviousMonth = function ($event, year, month) {
                $event.stopPropagation();
                vm.selectMonth(year, month);
            };

            vm.goNextMonth = function ($event, year, month) {
                $event.stopPropagation();
                vm.selectMonth(year, month);
            };

            vm.selectFromDay = function (day) {
                vm.fromDay = day;
                if (vm.toDay < vm.fromDay) {
                    vm.toDay = vm.fromDay;
                }
                updateScope();
            };

            vm.selectToDay = function (day) {
                vm.toDay = day;
                if (vm.toDay < vm.fromDay) {
                    vm.fromDay = vm.toDay;
                }
                updateScope();
            };

            vm.selectYear = function ($event, year) {
                $event.stopPropagation();
                angular.forEach(vm.years, function (item) {
                    item.expand = item.value === year;
                });
            };

            vm.selectMonth = function (year, month) {
                fromDate = moment.utc([year, month, 1]);
                toDate = moment(fromDate).endOf('month');
                generateModel();
                updateScope();
            };

            function generateModel() {
                var previousMonth = moment(fromDate).subtract(1, 'months');
                var nextMonth = moment(fromDate).add(1, 'months');
                vm.previousMonth = previousMonth.month();
                vm.previousYear = previousMonth.year();
                vm.nextMonth = nextMonth.month();
                vm.nextYear = nextMonth.year();
                vm.year = fromDate.year();
                vm.month = fromDate.month();
                vm.text = fromDate.format('MMM YYYY');
                vm.years = generateYears();
                vm.daysOfMonth = generateDaysOfMonth();
                vm.fromDay = vm.daysOfMonth[fromDate.date() - 1];
                vm.toDay = vm.daysOfMonth[toDate.date() - 1];

                function generateYears() {
                    var years = [];
                    var monthFullNames = moment.months();
                    for (var yearNumber = 2014; yearNumber <= 2016; yearNumber++) {
                        var months = [];
                        for (var monthNumber = 0; monthNumber < 12; monthNumber++) {
                            months.push({
                                value: monthNumber,
                                text: monthFullNames[monthNumber]
                            });
                        }
                        years.push({
                            value: yearNumber,
                            expand: yearNumber === vm.year,
                            months: months
                        });
                    }

                    return years;
                }

                function generateDaysOfMonth() {
                    var daysOfMonth = [];
                    var maxDay = fromDate.daysInMonth();
                    for (var dayNumber = 1; dayNumber <= maxDay; dayNumber++) {
                        daysOfMonth.push(dayNumber);
                    }

                    return daysOfMonth;
                }
            }

            function updateScope() {
                vm.fromDate = fromDate.toDate();
                vm.toDate = toDate.toDate();
            }
        }
    }
})();