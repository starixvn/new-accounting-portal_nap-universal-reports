(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportTypeService', sportTypeService);

    sportTypeService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportTypeService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getProductTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {           
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = 'api/house-win-loss-by-products/' + companyWinlossService.resolveProductPath(data.productName) + '/sport-type/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);