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
            compile: compile
        };
        return service;

        function generateHtml(scope, liveIndicator) {
            currentScope = scope;
            var html = '<ol class="breadcrumb">';
            var breadcrumbLevels = [];
            if (gridModel.level === levels.PRODUCT) {
                html += generateProductHtml(true);
            } else {
                scope.breadcrumbClicked = breadcrumbClicked;
                html += generateProductHtml(false);
                var productSetting = levelSettings[gridModel.productName];
                var previousLevel = levels.PRODUCT;
                for (var i = 0; i < productSetting.templates.length; i++) {
                    var productSettingTemplate = productSetting.templates[i];
                    if (productSettingTemplate.level > gridModel.level) break;

                    var isActive = productSettingTemplate.level === gridModel.level;
                    if (productSettingTemplate.level === levels.SPORT_TYPE) {
                        html += generateSportTypeHtml(previousLevel, isActive, liveIndicator);
                    } else if (productSettingTemplate.level === levels.BET_TYPE) {
                        html += generateBetTypeHtml(previousLevel, isActive, liveIndicator);
                    }

                    previousLevel = productSettingTemplate.level;
                }

                if (gridModel.level === levels.DETAIL) {
                    html += generateDetailHtml(previousLevel, liveIndicator);
                } else if (gridModel.level === levels.SITE) {
                    html += generateSiteHtml(previousLevel, liveIndicator);
                }
            }

            html += '</ol>';
            return html;
        }

        function generateProductHtml(isActive) {
            if (isActive) {
                return '<li class="active">PRODUCT WIN/LOSS REPORT</li>';
            } else {
                return '<li><a href data-ng-click="breadcrumbClicked(' + levels.PRODUCT + ')">MAIN</a></li>';
            }
        }

        function generateSportTypeHtml(previousLevel, isActive, isLive) {
            if (isActive) {
                return '<li class="active">' + gridModel.productName + getLiveText(isLive) + ' PRODUCT WIN/LOSS REPORT' + '</li>';
            } else {
                return '<li><a href data-ng-click="breadcrumbClicked(' + levels.SPORT_TYPE + ')">' + gridModel.productName + '</a></li>';
            }
        }

        function getLiveText(isLive) {
            return angular.isDefined(isLive)
                ? isLive ? ' "LIVE"' : ' "NON-LIVE"'
                : '';
        }

        function generateBetTypeHtml(previousLevel, isActive, isLive) {
            var displayText = previousLevel === levels.PRODUCT ? gridModel.productName : gridModel.sportTypeName;
            if (isActive) {
                return '<li class="active">' + displayText + getLiveText(isLive) + ' PRODUCT WIN/LOSS REPORT' + '</li>';
            } else {
                return '<li><a href data-ng-click="breadcrumbClicked(' + levels.BET_TYPE + ')">' + displayText + '</a></li>';
            }
        }

        function generateDetailHtml(previousLevel, isLive) {
            return '<li class="active">' + gridModel.betTypeName + getLiveText(isLive) + '</li>';
        }

        function generateSiteHtml(previousLevel, isLive) {
            return '<li class="active">' + gridModel.betTypeName + getLiveText(isLive) + ' | PRODUCT WIN LOSS REPORT BY ' + gridModel.site + ' SITE</li>';
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