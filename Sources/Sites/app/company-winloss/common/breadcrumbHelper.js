(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('breadcrumbHelper', breadcrumbHelper);

    breadcrumbHelper.$inject = ['$compile', 'levels', 'levelSettings', 'companyWinlossService'];
    function breadcrumbHelper($compile, levels, levelSettings, companyWinlossService) {
        var gridModel = companyWinlossService.gridModel;
        var currentScope;
        var service = {
            generateHtml: generateHtml,
            generateList: generateList,
            generateText: generateText,
            compile: compile
        };
        return service;

        function generateBreadcrumbItems(isLive) {
            var breadcrumbItems = [];
            if (gridModel.level === levels.PRODUCT) {
                breadcrumbItems.push({
                    text: 'Product Win/Loss Report',
                    level: levels.PRODUCT
                });
            } else {
                breadcrumbItems.push({
                    text: 'Main',
                    level: levels.PRODUCT
                });
                var level = levels.PRODUCT;
                var text = gridModel.productName;
                var productSetting = levelSettings[gridModel.productName];
                for (var i = 0; i < productSetting.templates.length; i++) {
                    var productSettingTemplate = productSetting.templates[i];
                    var maxLevel = Math.min(levels.BET_TYPE, gridModel.level);
                    if (productSettingTemplate.level > maxLevel) break;

                    var isActive = productSettingTemplate.level === gridModel.level;
                    var nextText = undefined;
                    var isAdded = true;
                    switch (productSettingTemplate.level) {
                        case levels.THIRD_PARTY_PRODUCT:
                            nextText = gridModel.thirdPartyProductName;
                            break;

                        case levels.SPORT_TYPE:
                            nextText = gridModel.sportTypeName;
                            break;

                        case levels.BET_TYPE:
                            nextText = gridModel.betTypeName;
                            break;

                        case levels.DETAIL:
                        case levels.SITE:
                            isAdded = isActive;
                            break;
                    }

                    breadcrumbItems.push({
                        text: text,
                        level: productSettingTemplate.level,
                        isLive: isLive
                    });
                    text = nextText;
                }

                if (gridModel.level === levels.DETAIL || gridModel.level === levels.SITE) {
                    breadcrumbItems.push({
                        text: text,
                        level: gridModel.level,
                        isLive: isLive
                    });
                }
            }

            return breadcrumbItems;
        }

        function getLiveText(isLive) {
            return angular.isDefined(isLive)
                ? isLive ? ' "Live"' : ' "Non-Live"'
                : '';
        }

        function generateBreadcrumbText(breadcrumbItem, isLast) {
            switch (breadcrumbItem.level) {
                case levels.PRODUCT:
                    return breadcrumbItem.text;

                case levels.THIRD_PARTY_PRODUCT:
                case levels.SPORT_TYPE:
                case levels.BET_TYPE:
                    return isLast
                        ? breadcrumbItem.text + getLiveText(breadcrumbItem.isLive) + ' Product Win/Loss Report'
                        : breadcrumbItem.text;

                case levels.DETAIL:
                    return breadcrumbItem.text + getLiveText(breadcrumbItem.isLive);

                case levels.SITE:
                    return breadcrumbItem.text + getLiveText(breadcrumbItem.isLive) + ' | Product Win Loss By ' + gridModel.site + ' Site'
            }
        }

        function generateList(isLive) {
            var breadcrumbItems = generateBreadcrumbItems(isLive);
            var list = [];
            for (var i = 0; i < breadcrumbItems.length; i++) {
                var breadcrumbItem = breadcrumbItems[i];
                var isLast = i === breadcrumbItems.length - 1;
                var breadcrumbText = generateBreadcrumbText(breadcrumbItem, isLast);
                list.push(breadcrumbText);
            }

            return list;
        }

        function generateText(isLive) {
            var list = this.generateList(isLive);
            return list.join(' > ');

        }

        function generateHtml(scope, isLive) {
            currentScope = scope;
            currentScope.breadcrumbClicked = breadcrumbClicked;
            var html = '<ol class="breadcrumb">';
            var breadcrumbItems = generateBreadcrumbItems(isLive);
            var list = [];
            for (var i = 0; i < breadcrumbItems.length; i++) {
                var breadcrumbItem = breadcrumbItems[i];
                var isLast = i === breadcrumbItems.length - 1;
                var breadcrumbText = generateBreadcrumbText(breadcrumbItem, isLast);
                if (isLast) {
                    html += '<li class="active">' + breadcrumbText + '</li>';
                } else {
                    html += '<li><a href data-ng-click="breadcrumbClicked(' + breadcrumbItem.level + ')">' + breadcrumbText + '</a></li>';
                }
            }

            html += '</ol>';
            return html;
        }

        function breadcrumbClicked(level) {
            companyWinlossService.generate({
                level: level
            });
        }

        function compile($element) {
            var breadcrumbElement = $element.find('.breadcrumb');
            $compile(breadcrumbElement)(currentScope);
        }
    }
})();