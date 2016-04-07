(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('numberGameBetTypeService', numberGameBetTypeService);

    numberGameBetTypeService.$inject = ['$http', 'httpResponseService'];
    function numberGameBetTypeService($http, httpResponseService) {
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
            return $http.post('/api/company-win-loss/number-game/bet-type', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(liveTitle, nonLiveTitle, data, fileName) {
            var httpData = {
                liveTitle: liveTitle,
                nonLiveTitle: nonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('/api/company-win-loss/number-game/bet-type/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);