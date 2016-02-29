(function () {
    'use strict';

    angular
        .module('app.companyWinlossApp')
        .factory('levelService', levelService);

    levelService.$inject = ['levels', 'levelSettings', 'companyWinlossService'];
    function levelService(levels, levelSettings, companyWinlossService) {
        var service = {
            getSetting: getSetting
        };
        return service;

        function getSetting() {
            var gridModel = companyWinlossService.gridModel;
            var levelSetting;
            if (gridModel.level === levels.PRODUCT) {
                var levelSetting = levelSettings.Product;
            } else {
                var productSetting = levelSettings[gridModel.productName];
                for (var i = 0; i < productSetting.templates.length; i++) {
                    var productSettingTemplate = productSetting.templates[i];
                    if (gridModel.level === productSettingTemplate.level) {
                        levelSetting = productSettingTemplate;
                        break;
                    }
                }
            }

            return {
                templateUrl: angular.isFunction(levelSetting.templateUrl) ? levelSetting.templateUrl(gridModel) : levelSetting.templateUrl,
                controller: angular.isFunction(levelSetting.controller) ? levelSetting.controller(gridModel) : levelSetting.controller
            };
        }
    }
})();