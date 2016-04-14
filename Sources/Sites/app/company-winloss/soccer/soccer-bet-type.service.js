(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerBetTypeService', soccerBetTypeService);

    soccerBetTypeService.$inject = ['$http', 'httpResponseService'];
    function soccerBetTypeService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                isMajor: data.isMajor
            };
            
            return $http.post('api/company-win-loss/soccer/group-bettype', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive,
                isMajor: data.isMajor
            };
            return $http.post('api/company-win-loss/soccer/group-bettype/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);