(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .constant('napDatePickerConfiguration', {
            minDate: moment('2014-8-25', 'YYYY-MM-DD'),
            maxDate: moment()
        })
        .directive('napDatePicker', napDatePicker);

    function napDatePicker() {
        var directive = {
            restrict: 'EA',
            template: '<div class="input-group input-group-sm date-picker"> \
                            <input type="text" class="form-control date-picker-input" data-ng-model="vm.text" readonly="readonly" data-ng-click="vm.openCalendar()" /> \
                            <ul class="dropdown-menu" dropdown-nested data-ng-if="vm.isOpen"> \
                                <li> \
                                    <div class="container-fluid date-picker-calendar"> \
                                        <div class="form-group form-group-sm calendar-header"> \
                                            <div class="col-xs-2 calendar-previous"> \
                                                <button class="btn btn-sm btn-primary" data-ng-class="{disabled: vm.previousDisabled}" data-ng-click="vm.goPreviousMonth()"><i class="glyphicon glyphicon-circle-arrow-left"/></button> \
                                            </div> \
                                            <div class="col-xs-4 calendar-month"> \
                                                <select class="input-sm form-control calendar-month-select" \
                                                    data-ng-model="vm.month" \
                                                    data-ng-change="vm.changeMonth()" \
                                                    data-ng-options="monthOption.name for monthOption in vm.monthOptions track by monthOption.value"> \
                                                </select> \
                                            </div> \
                                            <div class="col-xs-4 calendar-year"> \
                                                <select class="input-sm form-control calendar-year-select" \
                                                    data-ng-model="vm.year" \
                                                    data-ng-change="vm.changeYear()" \
                                                    data-ng-options="yearOption for yearOption in vm.yearOptions track by yearOption"> \
                                                </select> \
                                            </div> \
                                            <div class="col-xs-2 calendar-next"> \
                                                <button class="btn btn-sm btn-primary" data-ng-class="{disabled: vm.nextDisabled}" data-ng-click="vm.goNextMonth()"><i class="glyphicon glyphicon-circle-arrow-right"/></button> \
                                            </div> \
                                        </div> \
                                        <table> \
                                            <thead> \
                                                <tr> \
                                                    <th class="text-center calendar-day" data-ng-repeat="dayHeader in vm.dayHeaders" data-ng-class="{weekend: dayHeader.weekend}" title="{{dayHeader.title}}">{{dayHeader.name}}</th> \
                                                </tr> \
                                            </thead> \
                                            <tbody> \
                                                <tr data-ng-repeat="week in vm.weeks"> \
                                                    <td class="calendar-date" \
                                                        data-ng-repeat="date in week.dates" \
                                                        data-ng-click="vm.changeDate(date)"  > \
                                                        <button type="button" style="min-width: 100%" class="btn btn-default btn-sm date-button" data-ng-class="{\'btn-primary\': date.active, \'date-past\': date.past, \'date-future\': date.future}" data-ng-disabled="date.disabled">{{date.text}}</button> \
                                                    </td> \
                                                </tr> \
                                            </tbody> \
                                        </table> \
                                    </div> \
                                </li> \
                            </ul> \
                        </div>',
            scope: {
                ngModel: '='
            },
            require: ['^ngModel'],
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;

        controller.$inject = ['$scope', '$element', '$document', 'napDatePickerConfiguration'];
        function controller($scope, $element, $document, napDatePickerConfiguration) {
            var vm = this;
            var selectedDate;
            var minDate = moment.utc(napDatePickerConfiguration.minDate);
            var maxDate = moment.utc(napDatePickerConfiguration.maxDate);
            var startOfMonthOfMinDate = moment.utc(minDate).startOf('month');
            var endOfMonthOfMaxDate = moment.utc(maxDate).endOf('month');

            vm.openCalendar = function () {
                vm.isOpen = true;
                $document.unbind('click', documentClickBind);
                $document.bind('click', documentClickBind);
            };

            vm.goPreviousMonth = function () {
                if (vm.previousMonth) {
                    selectedDate = vm.previousMonth;
                    correctSelectedDate();
                    generateModel();
                }
            };

            vm.goNextMonth = function () {
                if (vm.nextMonth) {
                    selectedDate = vm.nextMonth;
                    correctSelectedDate();
                    generateModel();
                }
            };

            vm.changeMonth = function () {
                selectedDate.month(vm.month.value);
                correctSelectedDate();
                generateModel();
            };

            vm.changeYear = function () {
                selectedDate.year(vm.year);
                correctSelectedDate();
                generateModel();
            };

            vm.changeDate = function (date) {
                if (date.disabled) {
                    return;
                }

                selectedDate = date.value;
                generateModel();
                vm.text = selectedDate.format('MMM DD, YYYY');
                vm.ngModel = selectedDate.toDate();
            };

            $scope.$on('$destroy', function () {
                $document.unbind('click', documentClickBind);
            });

            $scope.$watch('vm.ngModel', function () {
                init();
            });

            function init() {
                selectedDate = moment(vm.ngModel);
                vm.isOpen = false;
                vm.text = selectedDate.format('MMM DD, YYYY');
                generateModel();
            }

            function correctSelectedDate() {
                if (selectedDate.isBefore(minDate)) {
                    selectedDate = moment(minDate);
                } else if (selectedDate.isAfter(maxDate)) {
                    selectedDate = moment(maxDate);
                }
            }

            function generateModel() {
                var selectedMonth = selectedDate.month();
                var selectedYear = selectedDate.year();
                var startOfMonth = moment.utc(selectedDate).startOf('month');
                var endOfMonth = moment.utc(selectedDate).endOf('month');
                var startDate = moment.utc(startOfMonth).subtract(Math.abs(startOfMonth.weekday()), 'days');

                vm.monthOptions = generateMonthOptions();
                vm.month = vm.monthOptions[0];
                angular.forEach(vm.monthOptions, function (monthOption) {
                    if (monthOption.value === selectedMonth) {
                        vm.month = monthOption;
                    }
                });
                vm.yearOptions = generateYearOptions();
                vm.year = selectedDate.year();
                vm.dayHeaders = vm.dayHeaders || generateDayHeaders();
                vm.weeks = generateWeeks();

                var previousMonth = moment(selectedDate).subtract(1, 'months');
                vm.previousDisabled = previousMonth.isBefore(startOfMonthOfMinDate);
                vm.previousMonth = vm.previousDisabled ? null : previousMonth;

                var nextMonth = moment(selectedDate).add(1, 'months');
                vm.nextDisabled = nextMonth.isAfter(endOfMonthOfMaxDate);
                vm.nextMonth = vm.nextDisabled ? null : nextMonth;

                function generateMonthOptions() {
                    var monthOptions = [];
                    var shortNames = moment.monthsShort();
                    var date = moment(selectedDate);
                    for (var monthNumber = 0; monthNumber < 12; monthNumber++) {
                        date.month(monthNumber);
                        if (date.isBefore(startOfMonthOfMinDate) || date.isAfter(endOfMonthOfMaxDate)) {
                            continue;
                        }

                        var shortName = shortNames[monthNumber];
                        monthOptions.push({
                            name: shortName,
                            value: monthNumber
                        });
                    }

                    return monthOptions;
                }

                function generateYearOptions() {
                    var yearOptions = [];
                    var beginYear = minDate.year();
                    var endYear = maxDate.year();
                    for (var yearNumber = beginYear; yearNumber <= endYear; yearNumber++) {
                        yearOptions.push(yearNumber);
                    }

                    return yearOptions;
                }

                function generateDayHeaders() {
                    var dayHeaders = [];
                    var shortNames = moment.weekdaysMin();
                    var fullNames = moment.weekdays();
                    for (var dayNumber = 0; dayNumber < 7; dayNumber++) {
                        var shortName = shortNames[dayNumber];
                        var fullName = fullNames[dayNumber];
                        var weekend = dayNumber === 0 || dayNumber === 6;
                        dayHeaders.push({
                            name: shortName,
                            title: fullName,
                            weekend: weekend
                        });
                    }

                    return dayHeaders;
                }

                function generateWeeks() {
                    var weeks = [];
                    for (var i = 0; i < 6; i++) {
                        var week = {
                            dates: []
                        };
                        for (var j = 0; j < 7; j++) {
                            var monthMoment = moment.utc(startDate).add((i * 7) + j, 'days');
                            var date = {
                                value: monthMoment,
                                text: monthMoment.format('D'),
                                active: monthMoment.format('YYYY-MMM-DD') === selectedDate.format('YYYY-MMM-DD'),
                                past: monthMoment.isBefore(startOfMonth),
                                future: monthMoment.isAfter(endOfMonth),
                                disabled: monthMoment.isBefore(minDate) || monthMoment.isAfter(maxDate)
                            };
                            week.dates.push(date);
                        }
                        weeks.push(week);
                    }

                    return weeks;
                }
            };

            function documentClickBind(event) {
                if (!vm.isOpen) {
                    $document.unbind('click', documentClickBind);
                    return;
                }

                var dpContainsTarget = $element[0].contains(event.target);
                if (vm.isOpen && !dpContainsTarget) {
                    $scope.$apply(function () {
                        vm.isOpen = false;
                    });
                }
            }
        }
    }
})();