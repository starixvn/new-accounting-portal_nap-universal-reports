(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['$timeout', 'levels'];
    function companyWinlossService($timeout, levels) {
        var service = {
            scope: {},
            gridModel: {},
            filterModel: {},
            updateGridModel: updateGridModel,
            getExcelFileName: getExcelFileName,
            generate: generate
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level <= data.level;
            this.updateGridModel(data);
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel.level);
            } else {
                this.scope.$broadcast('show', this.gridModel.level);
            }
        }

        function updateGridModel(data) {
            var dateRange = this.filterModel.getDateRange();
            this.gridModel.startDate = dateRange.startDate;
            this.gridModel.endDate = dateRange.endDate;
            this.gridModel.level = angular.isDefined(data.level) ? data.level : this.gridModel.level;
            this.gridModel.productName = angular.isDefined(data.productName) ? data.productName : this.gridModel.productName;
            this.gridModel.thirdPartyProductId = angular.isDefined(data.thirdPartyProductId) ? data.thirdPartyProductId : this.gridModel.thirdPartyProductId;
            this.gridModel.thirdPartyProductName = angular.isDefined(data.thirdPartyProductName) ? data.thirdPartyProductName : this.gridModel.thirdPartyProductName;
            this.gridModel.sportType = angular.isDefined(data.sportType) ? data.sportType : this.gridModel.sportType;
            this.gridModel.sportTypeName = angular.isDefined(data.sportTypeName) ? data.sportTypeName : this.gridModel.sportTypeName;
            this.gridModel.isLive = angular.isDefined(data.isLive) ? data.isLive : this.gridModel.isLive;
            this.gridModel.betType = angular.isDefined(data.betType) ? data.betType : this.gridModel.betType;
            this.gridModel.betTypeName = angular.isDefined(data.betTypeName) ? data.betTypeName : this.gridModel.betTypeName;
            this.gridModel.site = angular.isDefined(data.site) ? data.site : this.gridModel.site;
        }

        function getExcelFileName() {
            return 'Company_Win_Loss_By_Products_From_' + this.gridModel.startDate.format('DD_MM_YYYY') + '_To_' + this.gridModel.endDate.format('DD_MM_YYYY') + '.xls';
        }
    }
})();