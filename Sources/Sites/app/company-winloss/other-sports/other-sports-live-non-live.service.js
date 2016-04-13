(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsLiveNonLiveService', otherSportsLiveNonLiveService);

    otherSportsLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function otherSportsLiveNonLiveService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/other-sports/live-non-live', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(sportTypeTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                sportTypeTitle: sportTypeTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/other-sports/live-non-live/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);