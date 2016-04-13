(function (angular) {
    'use strict'
    angular
        .module('app.companyWinlossApp')
        .factory('MetricGamingLiveNonLiveService', MetricGamingLiveNonLiveService);

    MetricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function MetricGamingLiveNonLiveService($http, httpResponseService) {

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
            return $http.post('/api/company-win-loss/other-sports/live-non-live', httpData)
                    .then(httpResponseService.getDataComplete)
                    .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(betTypeTitle, data, fileName) {
            var httpData = {
                betTypeTitle: betTypeTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('/api/company-win-loss/other-sports/live-non-live/excel', httpData)
                        .then(function (response) {
                            httpResponseService.saveExcelFile(response.data, fileName);
                        })
                        .catch(httpResponseService.getDataFailed);
        }
    }

})(angular);