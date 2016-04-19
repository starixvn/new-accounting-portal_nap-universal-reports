(function (angular) {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('soccerSportTypeService', soccerSportTypeService);

    soccerSportTypeService.$inject = ['$http', 'httpResponseService'];
    function soccerSportTypeService($http, httpResponseService) {
        var service = {
            exportExcel: exportExcel
        };

        return service;

        function exportExcel(majorMinorTitle, liveNonLiveTitle, data, fileName) {
            var httpData = {
                majorMinorTitle: majorMinorTitle,
                liveNonLiveTitle: liveNonLiveTitle,
                startDate: data.startDate,
                endDate: data.endDate
            };
            return $http.post('api/company-win-loss/soccer/sporttype/excel', httpData, { responseType: "arraybuffer" })
                .then(function (response) {
                    httpResponseService.saveExcelFile(response.data, fileName);
                })
                .catch(httpResponseService.getDataFailed);
        }
    }
})(angular);