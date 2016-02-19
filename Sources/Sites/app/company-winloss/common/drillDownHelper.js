(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('drillDownHelper', drillDownHelper);

    drillDownHelper.$inject = ['$compile', 'levels', 'levelSettings', 'companyWinlossService'];
    function drillDownHelper($compile, levels, levelSettings, companyWinlossService) {
        var gridModel = companyWinlossService.gridModel;
        var currentScope;
        var service = {
            build: build,
            compile: compile
        };
        return service;

        function build(scope, data, level) {
            currentScope = scope;
            switch (gridModel.level) {
                case levels.THIRD_PARTY_PRODUCT:
                    buildThirdPartyProduct(data);
                    break;

                case levels.SPORT_TYPE:
                    buildSportType(data);
                    break;

                case levels.BET_TYPE:
                    buildBetType(data);
                    break;
            }
        }

        function buildThirdPartyProduct(data) {
            currentScope.generateBetType = generateBetType;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var customAttr = data.bodyRows[i].Columns[0].CustomAttr;
                var customAttrData = customAttr.split('\,');
                data.bodyRows[i].Columns[0].Value = '<a class="drill-down" href data-ng-click="generateBetType(' + parseInt(customAttrData[0]) + ',\'' + customAttrData[1] + '\')">' + customAttrData[1] + '</a>';
            }
        }

        function buildSportType(data) {
            currentScope.generateBetType = generateBetType;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var customAttr = data.bodyRows[i].Columns[0].CustomAttr;
                var customAttrData = customAttr.split('\,');
                data.bodyRows[i].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateBetType(' + customAttrData[0] + ',\'' + customAttrData[1] + '\')">' + customAttrData[1] + '</a>';
            }
        }

        function buildBetType(data) {
            currentScope.generateSite = generateSite;
            for (var i = 0; i < data.bodyRows.length; i++) {
                var bettype = data.bodyRows[i];
                var betTypeName = bettype.Columns[0].Value;
                for (var j = 0; j < bettype.SubRows.length; j++) {
                    var customAttr = data.bodyRows[i].SubRows[j].Columns[0].CustomAttr;
                    var customAttrData = customAttr.split('\,');
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-nap-click="generateSite(' + customAttrData[0] + ',\'' + betTypeName + '\',\'' + customAttrData[1] + '\')">' + customAttrData[1] + '</a>';
                }
            }
        }

        function compile($element) {
            var elements = $element.find('.drill-down');
            $compile(elements)(currentScope);
        }

        function generateBetType(sportType, sportTypeName) {
            companyWinlossService.generate({
                level: levels.BET_TYPE,
                sportType: sportType,
                sportTypeName: sportTypeName
            });
        };

        function generateSite(betType, betTypeName, site) {
            companyWinlossService.generate({
                level: levels.SITE,
                betType: betType,
                betTypeName: betTypeName,
                site: site
            });
        }
    }
})();