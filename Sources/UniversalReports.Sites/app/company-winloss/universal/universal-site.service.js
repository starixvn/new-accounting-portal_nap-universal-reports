(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('universalSiteService', universalSiteService);

    universalSiteService.$inject = ['$http', 'httpResponseService', 'titleService'];
    function universalSiteService($http, httpResponseService, titleService) {
        var service = {
            getTitle: titleService.getSiteTitle,
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData(data) {
            var url = 'api/company-win-loss/universal/site';
            return $http.post(url, data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel(title, data, fileName) {
            var httpData = {
                title: title                
            };
            angular.extend(httpData, data);
            var url = 'api/company-win-loss/universal/site/excel';
            return $http.post(url, httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);