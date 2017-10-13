//import angular from "angular";
(function (angular) {
    'use strict';

    angular
        .module('app.houseWinlossApp')
        .factory('soccerBetTypeFullService', soccerBetTypeFullService);

    soccerBetTypeFullService.$inject = ['$http', 'httpResponseService'];
    function soccerBetTypeFullService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel            
        };

        return service;

        function getData(data, isLive) {
            var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
            var isSumBetType = isMajor && isLive === 2;
            var isGroupBetType = isMajor && isLive === 0;
            var url = "api/house-win-loss-by-products/soccer/bettype";
            if (isSumBetType) {
                url = "api/house-win-loss-by-products/soccer/sum-bettype";
            }
            else if (isGroupBetType) {
                url = "api/house-win-loss-by-products/soccer/group-bettype";
            }

            var httpData = { isMajor: isMajor };
            angular.extend(httpData, data);
            httpData.isLive = isLive;
            return $http.post(url, httpData)
                            .then(httpResponseService.getDataComplete)
                            .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(viewSetting, data, fileName) {
            var isMajor = data.betTypeNameMajorMinor === "Soccer-Major Bet Types";
            var httpData = { isMajor: isMajor };
            angular.extend(httpData, data);

            var url = 'api/house-win-loss-by-products/soccer/bettype-full/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);