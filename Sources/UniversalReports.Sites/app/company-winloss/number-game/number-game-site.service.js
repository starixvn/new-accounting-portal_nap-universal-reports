(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameSiteService', numberGameSiteService);

    numberGameSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'liveTitleService'];
    function numberGameSiteService($http, httpResponseService, companyWinlossService, liveTitleService) {
        var service = {
            getTitle: liveTitleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                betType: data.betType,
                site: data.site
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