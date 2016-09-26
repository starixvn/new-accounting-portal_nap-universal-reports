import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('commonService', commonService);

    commonService.$inject = ['$http', 'httpResponseService','titleService'];
    function commonService($http, httpResponseService, titleService) {

        var service = {
            getTitle: titleService.getReportMainTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;
        
        function getData(data) {
            var httpData = {
                fromDate: data.startDate,
                toDate: data.endDate,
                normalMode: data.normalMode,
                betType: data.betType,
                username: data.username,
                currency: data.currency
            };

            var httpDatatemp = {
                startDate: data.endDate,
                endDate: data.endDate,
                casinoType: 2,
                normalMode: data.true
            };
            var urltemp = 'api/house-win-loss-by-products/casino/product';
            var url = 'api/ng2-statistic/report/' + data.reportType;
            return $http.post(urltemp, httpDatatemp)
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
            var url = 'api/ng2-statistic/report/' + data.reportType + '/excel';

            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);