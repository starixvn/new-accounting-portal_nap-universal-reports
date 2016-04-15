(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);

    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function metricGamingLiveNonLiveService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: getData,
            exportExcel: exportExcel
        }
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live';
            return $http.post(url, httpData)
                    .then(httpResponseService.getDataComplete)
                    .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(betTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                betTypeTitle: betTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/live-none-live/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                        .then(function (response) {
                            httpResponseService.saveExcelFile(response.data, fileName);
                        })
                        .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);