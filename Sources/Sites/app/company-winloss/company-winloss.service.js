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
            generate: generate,
            generateMain: generateMain
        };
        return service;

        function generate(data) {
            var hasGenerate = data.level === undefined || this.gridModel.level < data.level;
            this.gridModel.level = data.level || this.gridModel.level;
            this.gridModel.product = data.product || this.gridModel.product;
            this.gridModel.subProduct = data.subProduct || this.gridModel.subProduct;
            this.gridModel.sportType = data.sportType || this.gridModel.sportType;
            this.gridModel.betType = data.betType || this.gridModel.betType;
            if (hasGenerate) {
                this.scope.$broadcast('generate', this.gridModel);
            } else {
                this.scope.$broadcast('show', this.gridModel);
            }
        }

        function generateMain() {
            this.generate({
                level: levels.MAIN
            });
        }
    }
})();