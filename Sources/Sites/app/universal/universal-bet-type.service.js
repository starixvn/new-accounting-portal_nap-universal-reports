
(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('universalBetTypeService', universalBetTypeService);

    universalBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function universalBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/universal/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/universal/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);