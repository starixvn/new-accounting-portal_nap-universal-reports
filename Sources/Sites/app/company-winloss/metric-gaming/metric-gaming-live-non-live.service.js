(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);

    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function metricGamingLiveNonLiveService($http, httpResponseService) {

        var service = {
            getData: getData,
            exportExcel: exportExcel
        }
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/metric-gaming/live-none-live', httpData)
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
            return $http.post('api/company-win-loss/metric-gaming/live-none-live/excel', httpData, { responseType: "arraybuffer" })
                        .then(function (response) {
                            httpResponseService.saveExcelFile(response.data, fileName);
                        })
                        .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);