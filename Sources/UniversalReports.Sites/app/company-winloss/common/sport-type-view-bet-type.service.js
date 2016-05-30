(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportTypeViewBetTypeService', sportTypeViewBetTypeService);

    sportTypeViewBetTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportTypeViewBetTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var httpData = {
                sportType: data.sportType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, httpData)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title,
                sportType: data.sportType,
                startDate: data.startDate,
                endDate: data.endDate
            };
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);