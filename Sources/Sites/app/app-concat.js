/* Author: Nexcel -  2016-04-27 */
(function (angular) {
    'use strict';

    angular
        .module('app.core', [
            'ui.bootstrap',
            'ngRoute',
            'ngSanitize',
            'angularMoment'
        ]);
})(angular);
(function (angular, moment) {
    'use strict';

    angular
        .module('app.core')
        .constant('moment', moment)
        .constant('config', (function () {
            moment.now = function () {
                return napConfig.Today;
            };
            var today = moment.utc().startOf('day');
            var yesterday = moment(today).subtract(1, 'days');

            return {
                rootUrl: napConfig.RootUrl,
                legacyPath: napConfig.LegacyPath,
                today: today,
                yesterday: yesterday
            };
        })())
        .constant('formatStrings', {
            INT_NUMBER: '0,0',
            TWO_DECIMAL_NUMBER: '0,0.00',
            FOUR_DECIMAL_NUMBER: '0,0.0000',
            TWO_DECIMAL_PERCENT_NUMBER: '0,0.00%',
            MMM_DD_YYYY_STRING: 'MMM DD, YYYY',
            M_DD_YY_STRING: 'M dd, yy',
            MM_DD_YYYY_WITH_SLASH_STRING: 'MM/dd/yyyy',
            MMM_YY_STRING: 'MMM YY',
            MMM_YY_STRING_MONTH_PICKER: 'MMM yyyy',
            MMM_DD_YY_STRING_MONTH_PICKER: 'MMM dd, yyyy',
            MM_DD_YYYY_WITH_SLASH_STRING_MOMENT: 'M/D/YYYY',
            MMM_DD_YYYY_STRING_MOMENT: 'MMM D, YYYY',
            MMM_DD_YYYY_H_M_STRING: 'MMM DD, YYYY HH:mm',
            MMM_DD_YYYY_H_M_S_A_STRING: 'MMMM DD, YYYY h:mm:ss A',
            PERCENT_NUMBER: '0%'
        })
        .constant('universalMenus', ['/UniversalReports/CompanyWinLoss']);
})(angular, moment);
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    config.$inject = ['$routeProvider', '$httpProvider', 'config'];
    function config($routeProvider, $httpProvider, config) {
        configRouting();
        configHttp();

        function configRouting() {
            $routeProvider
                .when('/', {
                    templateUrl: 'app/company-winloss/company-winloss.html',
                    controller: 'CompanyWinlossController',
                    controllerAs: 'vm'
                })
                .when('/about', {
                    templateUrl: 'app/about/about.html',
                    controller: 'AboutController',
                    controllerAs: 'vm'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }

        function configHttp() {
            $httpProvider.interceptors.push(templateInterceptor);
            templateInterceptor.$inject = ['$templateCache'];
            function templateInterceptor($templateCache) {
                return {
                    request: function (c) {
                        var url = c.url;
                        if ($templateCache.get(url) === undefined) {
                            var subString = url.substring(0, 4);
                            if (subString.toLowerCase() !== 'http') {
                                c.url = config.rootUrl + '/' + url;
                            }
                        }

                        return c;
                    }
                };
            }

            $httpProvider.interceptors.push(loadingInterceptor);
            loadingInterceptor.$inject = ['$q', '$rootScope'];
            function loadingInterceptor($q, $rootScope) {
                return {
                    request: function (config) {
                        $rootScope.$broadcast('loading-started');
                        return config || $q.when(config);
                    },
                    response: function (response) {
                        $rootScope.$broadcast('loading-complete');
                        return response || $q.when(response);
                    }, responseError: function (response) {
                        $rootScope.$broadcast('loading-complete');
                        return $q.reject(response);
                    }
                };
            }
        }
    }
})(angular);