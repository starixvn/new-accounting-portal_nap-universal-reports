import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('drilldownService', drilldownService);

    drilldownService.$inject = ['$http', 'httpResponseService','titleService'];
    function drilldownService($http, httpResponseService, titleService) {

        var service = {
            getTitle: titleService.getTitleDrilldown,
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
                startDate: "2016-09-17T00:00:00.000Z",
                endDate: "2016-09-17T00:00:00.000Z",
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