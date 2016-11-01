import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('soccerLiveNonLiveService', soccerLiveNonLiveService);

    soccerLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'remoteDataService'];
    function soccerLiveNonLiveService($http, httpResponseService, remoteDataService) {
        var service = {
            getData: remoteDataService.getData,
            getMajorMinorData: getMajorMinorData,
            exportExcel: remoteDataService.exportExcel
        };

        return service;

        function getMajorMinorData(data) {
            return $http.post('api/house-win-loss-by-products/soccer/major-minor', data)
                            .then(httpResponseService.getDataComplete)
                            .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);