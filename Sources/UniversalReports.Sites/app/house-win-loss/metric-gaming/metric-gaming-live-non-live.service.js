import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('metricGamingLiveNonLiveService', metricGamingLiveNonLiveService);

    metricGamingLiveNonLiveService.$inject = ['$http', 'httpResponseService', 'houseWinlossService', 'titleService', 'remoteDataService'];
    function metricGamingLiveNonLiveService($http, httpResponseService, houseWinlossService, titleService, remoteDataService) {
        var service = {
            getTitle: titleService.getProductLiveNonLiveTitle,
            getData: remoteDataService.getData,
            getBetTypeData: getBetTypeData,
            exportExcel: remoteDataService.exportExcel
        };
        return service;

        function getBetTypeData(viewSetting, data) {
            var httpData = {};
            angular.extend(httpData, data);
            angular.extend(httpData, viewSetting.mainParameters);

            var url = 'api/house-win-loss-by-products/metric-gaming-superlive/bet-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);