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

        controller.$inject = ['$log', 'moment', 'config'];
        function controller($log, moment, config) {
            var vm = this;
            var minDate = moment.utc(config.today).subtract(2, 'years');
            var monthOfMinDate = minDate.month();
            var yearOfMinDate = minDate.year();
            var startOfMonthOfMinDate = moment.utc(minDate).startOf('month');
            var maxDate = moment.utc(config.today);
            var monthOfMaxDate = maxDate.month();
            var yearOfMaxDate = maxDate.year();
            var endOfMonthOfMaxDate = moment.utc(maxDate).endOf('month');
            var fromDate = moment.utc(vm.fromDate);
            var toDate = moment.utc(vm.toDate);
            if (fromDate.year() !== toDate.year() || fromDate.month() !== toDate.month()) {
                $log.error('fromDate and toDate are not same month and year');
                return;
            }

            generateModel();

            vm.goPreviousMonth = function ($event, year, month) {
                $event.stopPropagation();
                if (vm.previousDisabled) {
                    return;
                }

                vm.selectMonth(year, month);
            };

            vm.goNextMonth = function ($event, year, month) {
                $event.stopPropagation();
                if (vm.nextDisabled) {
                    return;
                }

                vm.selectMonth(year, month);
            };

            vm.selectFromDay = function ($event, day) {
                $event.preventDefault();
                vm.fromDay = day;
                fromDate.date(vm.fromDay);
                if (vm.toDay < vm.fromDay) {
                    vm.toDay = vm.fromDay;
                    toDate.date(vm.toDay);
                }
                updateScope();
            };

            vm.selectToDay = function ($event, day) {
                $event.preventDefault();
                vm.toDay = day;
                toDate.date(vm.toDay);
                if (vm.toDay < vm.fromDay) {
                    vm.fromDay = vm.toDay;
                    fromDate.date(vm.fromDay);
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
                var fromDay = year === yearOfMinDate && month === monthOfMinDate ? minDate.date() : 1;
                fromDate = moment.utc([year, month, fromDay]);
                var toDay = year === yearOfMaxDate && month === monthOfMaxDate ? maxDate.date() : fromDate.daysInMonth();
                toDate = moment.utc([year, month, toDay]);
                generateModel();
                updateScope();
            };

            function generateModel() {
                var previousMonth = moment(fromDate).subtract(1, 'months').startOf('month');
                var nextMonth = moment(fromDate).add(1, 'months').endOf('month');
                vm.year = fromDate.year();
                vm.month = fromDate.month();
                vm.text = fromDate.format('MMM YYYY');
                vm.years = generateYears();
                vm.fromDay = fromDate.date();
                vm.toDay = toDate.date();
                vm.daysOfMonth = generateDaysOfMonth();

                vm.previousDisabled = previousMonth.isBefore(startOfMonthOfMinDate);
                if (!vm.previousDisabled) {
                    vm.previousMonth = previousMonth.month();
                    vm.previousYear = previousMonth.year();
                }
                vm.nextDisabled = nextMonth.isAfter(endOfMonthOfMaxDate);
                if (!vm.nextDisabled) {
                    vm.nextMonth = nextMonth.month();
                    vm.nextYear = nextMonth.year();
                }

                function generateYears() {
                    var monthFullNames = moment.months();
                    var years = [];
                    for (var yearNumber = yearOfMinDate; yearNumber <= yearOfMaxDate; yearNumber++) {
                        var months = [];
                        var minMonth = yearNumber === yearOfMinDate ? monthOfMinDate : 0;
                        var maxMonth = yearNumber === yearOfMaxDate ? monthOfMaxDate : 11;
                        for (var monthNumber = minMonth; monthNumber <= maxMonth; monthNumber++) {
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
                    for (var dayNumber = vm.fromDay; dayNumber <= vm.toDay; dayNumber++) {
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