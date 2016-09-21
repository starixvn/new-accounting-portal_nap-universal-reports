import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('dailyService', dailyService);

    dailyService.$inject = ['$http', 'httpResponseService'];
    function dailyService($http, httpResponseService) {
        console.log("dailyService");

        var service = {
            getData: getData
        };
        return service;

        function getData() {
            return {
                fakeData: "fake"
            };
        }

    }
})(angular);