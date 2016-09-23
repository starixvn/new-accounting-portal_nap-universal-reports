import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('usernameService', usernameService);

    usernameService.$inject = ['$http', 'httpResponseService','titleService'];
    function usernameService($http, httpResponseService, titleService) {

        var service = {
            getTitle: titleService.getReportMainTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;
        
        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode,
                reportType: data.reportType,
                sportbetType: data.sportbetType,
                username: data.username,
                currency: data.currency
            };
            var httpDatatemp = {
                startDate: data.startDate,
                endDate: data.endDate,
                casinoType: 2,
                normalMode: true
            };

            var url = 'api/ng2-statistic/report';
            return $http.post('api/house-win-loss-by-products/casino/product', httpDatatemp)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode,
                reportType: data.reportType,
                sportbetType: data.sportbetType,
                username: data.username,
                currency: data.currency
            };
            return $http.post('api/ng2-statistic/report/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);