import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerLiveNonLiveService', soccerLiveNonLiveService);

    soccerLiveNonLiveService.$inject = ['$http', 'httpResponseService'];
    function soccerLiveNonLiveService($http, httpResponseService) {
        var service = {
            getTitle: getTitleWhenLiveNonLive,
            getData: getData,
            getMajorMinorData: getMajorMinorData,
            exportExcel: exportExcel
        };

        return service;


        function getTitleWhenLiveNonLive(data, isLast) {
            return isLast ?
                data.productName + ' LIVE/NON-LIVE' :
                data.productName;
        }


        function getData(data) {
            return $http.post('api/house-win-loss-by-products/soccer/live-nonlive', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function getMajorMinorData(data) {
            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data)
                            .then(httpResponseService.getDataComplete)
                            .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(majorMinorTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                majorMinorTitle: majorMinorTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                normalMode: data.normalMode
            };
            return $http.post('api/house-win-loss-by-products/soccer/live-nonlive/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);