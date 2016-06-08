(function ($) {
    'use strict';

    angular
        .module('app.core')
        .run(reCheckIn);

    reCheckIn.$inject = ['$interval', 'legacyService'];
    function reCheckIn($interval, legacyService) {
        $interval(callback, 60000);

        function callback() {
            var url = legacyService.resolveUrl('/UserLogin/Login/ReCheckLogin');
            $.post(url, function (result) {
                if (result.IsKickedOut === "1") {
                    alert('Another session has been logged in or your session is expired. Forced to logout!');
                    window.location.href = legacyService.resolveUrl('/UserLogin/Login/LogOut');
                }
            }).fail(function (request, textStatus, error) {
                var result = $.parseJSON(request.responseText);
                if (result.code == 999999) {
                    window.location.href = legacyService.resolveUrl('/UserLogin/Common/Offline');
                }
            });;
        }
    }
})(jQuery);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('fanexGridService', fanexGridService);

    fanexGridService.$inject = [];
    function fanexGridService() {
        var service = {
            calculateExpandHeight: calculateExpandHeight
        };
        return service;

        function calculateExpandHeight(gridElement, hasTitle) {
            var bonusSpacing = hasTitle ? 25 : 5;
            var gridOffsetTop = gridElement.offset().top;
            return gridOffsetTop + bonusSpacing;
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('httpResponseService', httpResponseService);

    httpResponseService.$inject = ['loggerService'];
    function httpResponseService(loggerService) {
        var service = {
            getDataComplete: getDataComplete,
            getDataFailed: getDataFailed,
            saveExcelFile: saveExcelFile
        };

        return service;

        function getDataComplete(response) {
            loggerService.hide();
            return response.data;
        }

        function getDataFailed() {
            loggerService.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
        }

        function saveExcelFile(data, fileName) {
            var contentType = 'application/vnd.ms-excel';
            var blob = new Blob([data], { type: contentType });
            if (navigator.appVersion.toString().indexOf('.NET') > 0) {
                window.navigator.msSaveBlob(blob, fileName);
            }
            else {
                var e = document.createEvent('MouseEvents');
                var a = document.createElement('a');

                a.download = fileName;
                a.href = window.URL.createObjectURL(blob);
                a.dataset.downloadurl = [contentType, a.download, a.href].join(':');
                e.initMouseEvent('click', true, false, window,
                    0, 0, 0, 0, 0, false, false, false, false, 0, null);
                a.dispatchEvent(e);
            }
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('legacyService', legacyService);

    legacyService.$inject = ['config'];
    function legacyService(config) {
        var service = {
            legacyPath: config.legacyPath,
            resolveUrl: resolveUrl
        };
        return service;

        function resolveUrl(url) {
            return config.legacyPath + url;
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('loggerService', loggerService);

    loggerService.$inject = ['$rootScope'];
    function loggerService($rootScope) {
        var service = {
            log: log,
            hide: hide,
            logError: logError,
            logSuccess: logSuccess,
            logWarning: logWarning
        };
        return service;

        function hide() {
            $rootScope.$broadcast('alert-hide');
        }

        function log(message) {
            logIt(message, source, 'info');
        }

        function logWarning(message) {
            logIt(message, 'warning');
        }

        function logSuccess(message) {
            logIt(message, 'success');
        }

        function logError(message) {
            logIt(message, 'error');
        }

        function logIt(message, type) {
            if (type === 'error') {
                $rootScope.$broadcast('alert-show', message);
            }
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napAlert', napAlert);

    function napAlert() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/components/alert/alert.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope'];
    function controller($scope) {
        var vm = this;
        vm.isShow = false;
        vm.close = function () {
            vm.isShow = false;
        };

        $scope.$on('alert-show', function (event, message) {
            vm.message = message;
            vm.isShow = true;
        });

        $scope.$on('alert-hide', function () {
            vm.isShow = false;
        });
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napClick', napClick);

    napClick.$inject = ['$parse', '$rootScope'];
    function napClick($parse, $rootScope) {
        var directive = {
            restrict: 'A',
            compile: compile
        };
        return directive;

        function compile($element, attr) {
            // so that they are not executed in an inconsistent state.
            var forceAsyncEvents = {
                'blur': true,
                'focus': true
            };
            var eventName = 'click';
            var directiveName = 'napClick';
            var fn = $parse(attr[directiveName], /* interceptorFn */ null, /* expensiveChecks */ true);
            return function eventHandler(scope, element) {
                element.on(eventName, function (event) {
                    event.stopPropagation();
                    var callback = function () {
                        fn(scope);
                    };
                    if (forceAsyncEvents[eventName] && $rootScope.$$phase) {
                        scope.$evalAsync(callback);
                    } else {
                        scope.$apply(callback);
                    }
                });
            };
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napDatePicker', napDatePicker);

    function napDatePicker() {
        var directive = {
            restrict: 'EA',
            templateUrl: 'app/components/date-picker/date-picker.directive.html',
            scope: {
                ngModel: '='
            },
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope', '$element', '$document', 'moment', 'config'];
    function controller($scope, $element, $document, moment, config) {
        var vm = this;
        var selectedDate;
        var minDate = moment.utc([2011, 0, 1]);
        var maxDate = moment.utc(config.yesterday);
        var startOfMonthOfMinDate = moment.utc(minDate).startOf('month');
        var endOfMonthOfMaxDate = moment.utc(maxDate).endOf('month');

        vm.openCalendar = function () {
            vm.isOpen = true;
            $document.unbind('click', documentClickBind);
            $document.bind('click', documentClickBind);
        };

        vm.goPreviousMonth = function () {
            if (vm.previousDisabled) {
                return;
            }
            selectedDate = vm.previousMonth;
            correctSelectedDate();
            generateViewModel();
        };

        vm.goNextMonth = function () {
            if (vm.nextDisabled) {
                return;
            }
            selectedDate = vm.nextMonth;
            correctSelectedDate();
            generateViewModel();
        };

        vm.changeMonth = function () {
            selectedDate.month(vm.month.value);
            correctSelectedDate();
            generateViewModel();
        };

        vm.changeYear = function () {
            selectedDate.year(vm.year);
            correctSelectedDate();
            generateViewModel();
        };

        vm.changeDate = function (date) {
            if (date.disabled) {
                return;
            }

            selectedDate = date.value;
            generateViewModel();
            vm.text = selectedDate.format('MMM DD, YYYY');
            vm.ngModel = moment.utc(selectedDate);
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
            generateViewModel();
        }

        function correctSelectedDate() {
            if (selectedDate.isBefore(minDate)) {
                selectedDate = moment(minDate);
            } else if (selectedDate.isAfter(maxDate)) {
                selectedDate = moment(maxDate);
            }
        }

        function generateViewModel() {
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
            if (!vm.previousDisabled) {
                vm.previousMonth = previousMonth;
            }

            var nextMonth = moment(selectedDate).add(1, 'months');
            vm.nextDisabled = nextMonth.isAfter(endOfMonthOfMaxDate);
            if (!vm.nextDisabled) {
                vm.nextMonth = nextMonth;
            }

            function generateMonthOptions() {
                var monthShortNames = moment.monthsShort();
                var monthOptions = [];
                var date = moment(selectedDate);
                for (var monthNumber = 0; monthNumber < 12; monthNumber++) {
                    date.month(monthNumber);
                    if (date.isBefore(startOfMonthOfMinDate) || date.isAfter(endOfMonthOfMaxDate)) {
                        continue;
                    }

                    monthOptions.push({
                        name: monthShortNames[monthNumber],
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
                var dayShortNames = moment.weekdaysMin();
                var dayFullNames = moment.weekdays();
                var dayHeaders = [];
                for (var dayNumber = 0; dayNumber < 7; dayNumber++) {
                    var shortName = dayShortNames[dayNumber];
                    var fullName = dayFullNames[dayNumber];
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
        }

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
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napHeader', napHeader);

    function napHeader() {
        var directive = {
            restrict: 'EA',
            scope: {},
            templateUrl: 'app/components/header/header.directive.html',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['headerService', 'legacyService'];
    function controller(headerService, legacyService) {
        /*jshint validthis: true */
        var vm = this;
        vm.userProfileUrl = legacyService.resolveUrl('/UserControl/User/UserProfile');
        vm.changePasswordUrl = legacyService.resolveUrl('/UserControl/User/ChangePassword');
        vm.logOutUrl = legacyService.resolveUrl('/UserLogin/Login/LogOut');

        headerService.getData().then(function (data) {
            vm.username = data.Username;
            vm.menus = headerService.getCompiledMenu(data.Menus);
        });
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('headerService', headerService);

    headerService.$inject = ['$http', 'universalMenus', 'httpResponseService', 'legacyService'];
    function headerService($http, universalMenus, httpResponseService, legacyService) {
        var service = {
            getData: getData,
            getCompiledMenu: getCompiledMenu,
            getMenuUrl: getMenuUrl
        };
        return service;

        function getCompiledMenu(menus) {
            for (var i = 0; i < menus.length; i++) {
                var menu = menus[i];

                if (menu.Children && menu.Children.length > 0) {
                    menu.Url = menu.Link;
                    for (var j = 0; j < menu.Children.length; j++) {
                        menu.Children[j].Url = getMenuUrl(menu.Children[j].Link);
                    }
                } else {
                    menu.Url = getMenuUrl(menu.Link);
                }
            }

            return menus;
        }

        function getData() {
            return $http.post('api/application/header', {})
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getMenuUrl(url) {
            for (var i = 0; i < universalMenus.length; i++) {
                if (url.indexOf(universalMenus[i]) >= 0) {
                    return url;
                }
            }

            return legacyService.resolveUrl(url);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napLegend', napLegend);

    function napLegend() {
        var directive = {
            restrict: 'EA',
            scope: {
                menuId: '='
            },
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$element', 'legendService'];
    function controller($element, legendService) {
        var vm = this;
        legendService.getData(vm.menuId).then(function (data) {
            $element.html(data.Content);
        });
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .factory('legendService', legendService);

    legendService.$inject = ['$http', 'httpResponseService', 'legacyService'];
    function legendService($http, httpResponseService, legacyService) {
        var service = {
            getData: getData
        };
        return service;

        function getData(menuId) {
            var url = legacyService.resolveUrl('/LegendManagement/LegendManagement/GetReportLegend');
            return $http.post(url, {
                menuId: menuId
            }).then(httpResponseService.getDataComplete);
        }
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napLoading', napLoading);

    function napLoading() {
        var directive = {
            restrict: 'EA',
            scope: {},
            template: '<div class="loading-container" data-ng-show="vm.isLoading"><div class="block-overlay"></div><div class="block-loading"></div></div>',
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$scope'];
    function controller($scope) {
        var vm = this;
        vm.isLoading = false;
        vm.loadingCounter = 0;

        $scope.$on('loading-started', function () {
            vm.loadingCounter ++;
            vm.isLoading = vm.loadingCounter > 0;
        });

        $scope.$on('loading-complete', function () {
            vm.loadingCounter--;
            vm.isLoading = vm.loadingCounter > 0;
        });
    }
})(angular);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .directive('napMonthPicker', napMonthPicker);

    function napMonthPicker() {
        var directive = {
            restrict: 'EA',
            templateUrl: 'app/components/month-picker/month-picker.directive.html',
            scope: {
                startDate: '=',
                endDate: '=',
                maxDate: '='
            },
            replace: true,
            controller: controller,
            controllerAs: 'vm',
            bindToController: true
        };
        return directive;
    }

    controller.$inject = ['$log', '$scope', 'moment', 'config'];
    function controller($log, $scope, moment, config) {
        var vm = this;
        var minDate = moment.utc([2011, 0, 1]);
        var monthOfMinDate = minDate.month();
        var yearOfMinDate = minDate.year();
        var startOfMonthOfMinDate = moment.utc(minDate).startOf('month');
        var maxDate = moment.utc(vm.maxDate);
        var monthOfMaxDate = maxDate.month();
        var yearOfMaxDate = maxDate.year();
        var endOfMonthOfMaxDate = moment.utc(maxDate).endOf('month');
        var startDate = moment.utc(vm.startDate);
        var endDate = moment.utc(vm.endDate);
        if (startDate.year() !== endDate.year() || startDate.month() !== endDate.month()) {
            $log.error('startDate and endDate are not same month and year');
            return;
        }

        generateViewModel();

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
            startDate.date(vm.fromDay);
            if (vm.toDay < vm.fromDay) {
                vm.toDay = vm.fromDay;
                endDate.date(vm.toDay);
            }
            updateModel();
        };

        vm.selectToDay = function ($event, day) {
            $event.preventDefault();
            vm.toDay = day;
            endDate.date(vm.toDay);
            if (vm.toDay < vm.fromDay) {
                vm.fromDay = vm.toDay;
                startDate.date(vm.fromDay);
            }
            updateModel();
        };

        vm.selectYear = function ($event, year) {
            $event.stopPropagation();
            angular.forEach(vm.years, function (item) {
                item.expand = item.value === year;
            });
        };

        vm.selectMonth = function (year, month) {
            var fromDay = year === yearOfMinDate && month === monthOfMinDate ? minDate.date() : 1;
            startDate = moment.utc([year, month, fromDay]);
            var toDay = year === yearOfMaxDate && month === monthOfMaxDate ? maxDate.date() : startDate.daysInMonth();
            endDate = moment.utc([year, month, toDay]);
            generateViewModel();
            updateModel();
        };

        $scope.$watch('vm.startDate', function () {
            startDate = moment.utc(vm.startDate);
            generateViewModel();
        });
        $scope.$watch('vm.endDate', function () {
            endDate = moment.utc(vm.endDate);
            generateViewModel();
        });

        function generateViewModel() {
            var previousMonth = moment(startDate).subtract(1, 'months').startOf('month');
            var nextMonth = moment(startDate).add(1, 'months').endOf('month');
            vm.year = startDate.year();
            vm.month = startDate.month();
            vm.text = startDate.format('MMM YYYY');
            vm.years = generateYears();
            vm.fromDay = startDate.date();
            vm.toDay = endDate.date();
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
                var startDay = startDate.month() === minDate.month() && startDate.year() === minDate.year() ? minDate.date() : 1;
                var endDay = endDate.month() === maxDate.month() && endDate.year() === maxDate.year() ? maxDate.date() : moment(endDate).endOf('month').date();
                for (var dayNumber = startDay; dayNumber <= endDay; dayNumber++) {
                    daysOfMonth.push(dayNumber);
                }

                return daysOfMonth;
            }
        }

        function updateModel() {
            vm.startDate = moment.utc(startDate);
            vm.endDate = moment.utc(endDate);
        }
    }
})(angular);