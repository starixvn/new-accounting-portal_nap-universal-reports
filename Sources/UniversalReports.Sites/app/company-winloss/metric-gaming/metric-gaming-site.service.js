(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingSiteService', metricGamingSiteService);

    metricGamingSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingSiteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
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
                isLive: data.isLive == undefined ? 2 : data.isLive
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
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
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);