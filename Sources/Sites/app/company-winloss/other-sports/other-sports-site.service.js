(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsSiteService', otherSportsSiteService);

    otherSportsSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService'];
    function otherSportsSiteService($http, httpResponseService, companyWinlossService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isHedge: data.isHedge,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/sportsbook/site';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                betType: data.betType,
                site: data.site,
                startDate: data.startDate,
                endDate: data.endDate,
                isHedge: data.isHedge,
                isLive: data.isLive
            };
            var url = 'api/company-win-loss/sportsbook/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);