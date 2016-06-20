(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('betTypeService', betTypeService);

    betTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function betTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSportTypeTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {           
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = 'api/company-win-loss/' + companyWinlossService.resolveProductPath(data.productName) + '/bet-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);