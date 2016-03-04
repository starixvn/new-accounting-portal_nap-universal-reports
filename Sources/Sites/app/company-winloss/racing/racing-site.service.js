(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('racingSiteService', racingSiteService);

    racingSiteService.$inject = ['$http', 'httpResponseService', 'levels', 'companyWinlossService', 'breadcrumbHelper'];
    function racingSiteService($http, httpResponseService, levels, companyWinlossService, breadcrumbHelper) {
        var service = {
            getData: getData,
            exportExcel: exportExcel
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };
            return $http.post('/api/company-win-loss/racing/site', data)
                .then(httpResponseService.getDataComplete)
                .catch(httpResponseService.getDataFailed);
        }

        function exportExcel() {
            var gridModel = companyWinlossService.gridModel;
            var data = {
                title: breadcrumbHelper.generateText(),
                startDate: gridModel.startDate,
                endDate: gridModel.endDate,
                sportType: gridModel.sportType,
                betType: gridModel.betType,
                site: gridModel.site
            };

            return $http.post('/api/company-win-loss/racing/site/excel', data, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, companyWinlossService.getExcelFileName());
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})();