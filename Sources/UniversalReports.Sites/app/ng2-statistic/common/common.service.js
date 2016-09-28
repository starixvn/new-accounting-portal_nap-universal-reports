import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.numberGame2StatisticApp')
        .factory('commonService', commonService);

    commonService.$inject = ['$http', 'httpResponseService','titleService'];
    function commonService($http, httpResponseService, titleService) {

        var service = {
            getTitle: titleService.getTitleReport,
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

            var url = 'api/ng2-statistic/' + data.reportType;
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
            var url = 'api/ng2-statistic/' + data.reportType + '/excel';

            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);