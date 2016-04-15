(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingMatchDetailService', metricGamingMatchDetailService);

    metricGamingMatchDetailService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingMatchDetailService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getMatchDetailTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                isLive: data.isLive,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                isLive: data.isLive,
                sportType: data.sportType,
                betType: data.betType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/match-detail/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);