(function () {
    'use strict';

    angular
        .module('companyWinlossApp')
        .factory('kenoDrilldownStyleHelper', kenoDrilldownStyleHelper);

    kenoDrilldownStyleHelper.$inject = [ 'companyWinlossService'];
    function kenoDrilldownStyleHelper(companyWinlossService) {
        var service = {
            createSiteLinks: createSiteLinks,
            generateSite: generateSite,
        };
        return service;
       
        function createSiteLinks(data) {
            for (var i = 0; i < data.bodyRows.length; i++) {
                var betTypeRow = data.bodyRows[i];
                var betTypeName = betTypeRow.Columns[0].Value;
                for (var j = 0; j < betTypeRow.SubRows.length; j++) {
                    var siteRow = data.bodyRows[i].SubRows[j];
                    var betTypeId = siteRow.Columns[0].CustomAttr;
                    var siteName = siteRow.Columns[0].Value;
                    data.bodyRows[i].SubRows[j].Columns[0].Value = '<a class="drill-down" href data-ng-click="generateSite(' + betTypeId + ',\'' + betTypeName + '\',\'' + siteName + '\')">' + siteName + '</a>';
                }
            }
        }

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