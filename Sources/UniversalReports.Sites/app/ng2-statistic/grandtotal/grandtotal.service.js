import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('grandtotalService', grandtotalService);

    grandtotalService.$inject = ['$http', 'httpResponseService','titleService'];
    function grandtotalService($http, httpResponseService, titleService) {

        var service = {
            getTitle: titleService.getGrandTotalTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;
        
        function getData(data) {
            var httpData = {
                fromDate: data.startDate,
                toDate: data.endDate,
                betType: data.betType,
                username: data.username,
                currency: data.currency,
                moveBetsDay: data.balanceUpDate,
                isDrilldown: data.isDrilldown
            };

            var url = 'api/ng2-statistic/grandtotal';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
                        
        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                fromDate: data.startDate,
                toDate: data.endDate,
                betType: data.betType,
                username: data.username,
                currency: data.currency,
                moveBetsDay: data.balanceUpDate,
                isDrilldown: data.isDrilldown
            };

            var url = 'api/ng2-statistic/grandtotal/excel';

            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);