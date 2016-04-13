(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('otherSportsSportTypeService', otherSportsSportTypeService);

    otherSportsSportTypeService.$inject = ['$http', 'httpResponseService'];
    function otherSportsSportTypeService($http, httpResponseService) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };

        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate,
                isLive: data.isLive
            };
            return $http.post('api/company-win-loss/other-sports/sport-type', httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(betTypeTitle, sportTypeTitle, data, fileName) {
            var httpData = {
                betTypeTitle: betTypeTitle,
                sportTypeTitle: sportTypeTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/other-sports/sport-type/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);