import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.core')
        .config(config);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        configRouting();

        function configRouting() {
            $routeProvider
                .when('/', {
                    templateUrl: 'app/ng2-statistics/ng2-statistics.html',
                    controller: 'NG2StatisticsController',
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
    }
})(angular);