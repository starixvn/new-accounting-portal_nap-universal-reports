(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('levelService', levelService);

    levelService.$inject = ['levels', 'levelSettings', 'companyWinlossService'];
    function levelService(levels, levelSettings, companyWinlossService) {
        var service = {
            getSetting: getSetting
        };
        return service;

        function getSetting() {
            var gridModel = companyWinlossService.gridModel;
            var levelSetting = undefined;
            if (gridModel.level === levels.PRODUCT) {
                levelSetting = levelSettings.Product;
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

            if (angular.isFunction(levelSetting.templateUrl)) {
                levelSetting.templateUrl = levelSetting.templateUrl(gridModel);
            }

            if (angular.isFunction(levelSetting.controller)) {
                levelSetting.controller = levelSetting.controller(gridModel);
            }

            return levelSetting;
        }
    }
})();