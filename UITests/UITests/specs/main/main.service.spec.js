/// <reference path="../../../../sources/sites/scripts/jquery-2.1.4.min.js" />
/// <reference path="../../../../sources/sites/scripts/moment.min.js" />
/// <reference path="../../../../sources/sites/scripts/fanex.grid.js" />
/// <reference path="../../../../sources/sites/scripts/angular.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-route.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-mocks.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../sources/sites/scripts/angular-moment.min.js" />
/// <reference path="../../../../sources/sites/app/app.js" />
/// <reference path="../../../../sources/sites/app/app.constants.js" />
/// <reference path="../../../../sources/sites/app/app.config.js" />
/// <reference path="../../../../sources/sites/app/common/logger.js" />
/// <reference path="../../../../sources/sites/app/main/main.service.js" />

describe('Factory: MainService', function () {
    var dataService,
        rootScope,
        httpBackend,
        mockData;

    // load the controller's module
    beforeEach(module('companyWinlossApp'));

    // Initialize the controller and a mock scope
    beforeEach(inject(function ($rootScope, $injector, $httpBackend) {
        httpBackend = $httpBackend;
        rootScope = $rootScope;
        dataService = $injector.get('dataService');

        mockData = createFakeProductWinLoss("NumberGame");
        function createFakeProductWinLoss(productName) {
            var winLoss = {
                Total: { Title: productName, MemberWinLoss: 210, SMAWinLoss: 410, Commission: 30, RealIncome: 610, VirtualIncome: 810, VarianceIncome: -200, RealTurnover: 2100, VirtualTurnover: 2500, RealMargin: 0.290476, VirtualMargin: 0.324 },
                Credit: { Title: "Credit", MemberWinLoss: 100, SMAWinLoss: 200, Commission: 10, RealIncome: 300, VirtualIncome: 400, VarianceIncome: -100, RealTurnover: 1000, VirtualTurnover: 1200, RealMargin: 0.3, VirtualMargin: 0.3 },
                Deposit: { Title: "Deposit", MemberWinLoss: 110, SMAWinLoss: 210, Commission: 20, RealIncome: 310, VirtualIncome: 410, VarianceIncome: -100, RealTurnover: 1100, VirtualTurnover: 1300, RealMargin: 0.281818, VirtualMargin: 0.315384 }
            };

            return winLoss;
        };
    }));

    it('should be created successfully', function () {
        expect(dataService).toBeDefined();
    });

    describe('getDataNormal function', function () {
        it('should exist', function () {
            expect(dataService.getDataNormal).toBeDefined();
        });

        it('title should be NumberGame', function () {
            httpBackend.whenPOST('/api/productwinloss/values').respond(mockData);
            dataService.getDataNormal().then(function (data) {
                expect(data.Total.Title).toBe('NumberGame');
            });
            httpBackend.flush();
        });
    });
});