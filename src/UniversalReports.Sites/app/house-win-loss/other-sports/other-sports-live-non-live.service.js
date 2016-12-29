import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('otherSportsLiveNonLiveService', otherSportsLiveNonLiveService);

    otherSportsLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'houseWinlossService', 'remoteDataService'];
    function otherSportsLiveNonLiveService($http, httpResponseService, houseWinlossService,  remoteDataService) {
        var service = {
            getData: remoteDataService.getData,
            getSportTypeData: getSportTypeData,
            exportExcel: remoteDataService.exportExcel
        };

        function getSportTypeData(viewSetting, data) {
            var cloneViewSetting = {};
            angular.extend(cloneViewSetting, viewSetting);
            cloneViewSetting.serviceBaseUrl = "api/house-win-loss-by-products/other-sports/sport-type";
            return remoteDataService.getData(cloneViewSetting, data);
        }

        return service;
    }
})(angular);