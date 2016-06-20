(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('sportsbookSiteService', sportsbookSiteService);

    sportsbookSiteService.$inject = ['$http', 'httpResponseService', 'companyWinlossService', 'titleService'];
    function sportsbookSiteService($http, httpResponseService, companyWinlossService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var url = getServiceUrl(data.productName);
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title
            };
            angular.extend(httpData, data);
            var url = getServiceUrl(data.productName) + '/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }

        function getServiceUrl(productName) {
            return productName === 'Metric Gaming - Superlive'
            ? 'api/company-win-loss/metric-gaming-superlive/site'
                : 'api/company-win-loss/sportsbook/site';

        }
    }
})(angular);