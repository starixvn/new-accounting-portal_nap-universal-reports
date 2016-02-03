(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .service('companyWinlossService', companyWinlossService);

    companyWinlossService.$inject = ['$timeout', 'levels'];
    function companyWinlossService($timeout, levels) {
        var service = {
            scope: undefined,
            gridModel: undefined,
            filterModel: undefined,
            updateGridModel: updateGridModel,
            generate: generate,
            generateMain: generateMain,
            generateProduct: generateProduct,
            generateBetType: generateBetType
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level < data.level;
            this.updateGridModel(data);
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel);
            } else {
                this.scope.$broadcast('show', this.gridModel);
            }
        }

        function updateGridModel(data) {
            this.gridModel.level = data.level || this.gridModel.level;
            this.gridModel.product = data.product || this.gridModel.product;
            this.gridModel.subProduct = data.subProduct || this.gridModel.subProduct;
            this.gridModel.sportType = data.sportType || this.gridModel.sportType;
            this.gridModel.sportTypeName = data.sportTypeName || this.gridModel.sportTypeName;
            this.gridModel.isLive = data.isLive || this.gridModel.isLive;
            this.gridModel.betType = data.betType || this.gridModel.betType;
            this.gridModel.betTypeName = data.betTypeName || this.gridModel.betTypeName;
        }

        function generateMain() {
            this.generate({
                level: levels.MAIN
            });
        }

        function generateProduct() {
            this.generate({
                level: levels.PRODUCT
            });
        }

        function generateBetType(betType, isLive) {
            this.generate({
                level: levels.BET_TYPE,
                betType: betType,
                isLive: isLive
            });
        }
    }
})();