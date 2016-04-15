(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingSiteService', metricGamingSiteService);

    metricGamingSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function metricGamingSiteService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + 'site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);