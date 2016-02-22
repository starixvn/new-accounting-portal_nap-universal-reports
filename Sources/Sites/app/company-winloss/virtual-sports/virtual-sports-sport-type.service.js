(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('virtualSportsSportTypeService', virtualSportsSportTypeService);

    virtualSportsSportTypeService.$inject = ['$http', 'logger', 'levels', 'companyWinlossService'];
    function virtualSportsSportTypeService($http, logger, levels, companyWinlossService) {
        var service = {
            getData: getData,
            createLinks: createLinks,
            generateBetType: generateBetType
        };
        return service;

        function getData() {
            var gridModel = companyWinlossService.gridModel;
            var data = { startDate: gridModel.startDate, endDate: gridModel.endDate };
            return $http.post('/api/company-win-loss/virtual-sports/sport-type', data)
                .then(getDataComplete)
                .catch(getDataFailed);

            function getDataComplete(response) {
                logger.hide();
                return response.data;
            }

            function getDataFailed(error) {
                logger.logError('Sorry, an error occurred while processing your request, please notify the administrators.');
            }
        }

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        }

        function createLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var sportTypeRow = data.bodyRows[i];
                var sportTypeId = sportTypeRow.Columns[0].CustomAttr;
                var sportTypeName = sportTypeRow.Columns[0].Value;
                sportTypeRow.Columns[0].Value = '<a class="drill-down" href data-ng-click="generateBetType(' + sportTypeId + ',\'' + sportTypeName + '\')">' + sportTypeName + '</a>';
            }
        }
    }
})();
