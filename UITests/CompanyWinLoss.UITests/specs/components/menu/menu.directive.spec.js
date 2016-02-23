/// <reference path="../../../../sources/sites/scripts/jquery-2.2.0.min.js" />
/// <reference path="../../../../sources/sites/scripts/moment.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-route.min.js" />
/// <reference path="../../../../sources/sites/scripts/angular-mocks.js" />
/// <reference path="../../scripts/sinon-1.9.1.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../sources/sites/scripts/angular-moment.min.js" />
/// <reference path="../../../../sources/sites/app/components/menu/menu.directive.js" />

describe('Directive: MenuDirective', function () {
    var element,
        $timeout,
        scope,
        companyWinlossService,
        levels,
        mainService;

    // load the controller's module
    beforeEach(module('companyWinlossApp'));

    // Initialize the controller and a mock scope
    beforeEach(inject(function ($rootScope, $compile, _$timeout_, $templateCache, $httpBackend, _companyWinlossService_, _levels_, _mainService_) {
        $timeout = _$timeout_;
        $templateCache.put('app/company-winloss/shared/fanex-grid-with-title.html', '');
        $httpBackend.expectPOST('/api/company-win-loss/values').respond({});
        scope = $rootScope.$new();
        element = '<div data-nap-main></div>';
        element = $compile(element)(scope);
        scope.$digest();
        levels = _levels_;
        mainService = _mainService_;
        companyWinlossService = _companyWinlossService_;
        companyWinlossService.scope = scope;
        companyWinlossService.gridModel = {
            level: levels.PRODUCT
        };
        companyWinlossService.filterModel = {
            getDateRange: function () {
                return {
                    startDate: moment.utc(),
                    endDate: moment.utc()
                };
            }
        };
    }));

    it('should be created successfully', function () {
        expect(scope).toBeDefined();
        expect(element).toBeDefined();
        expect(levels).toBeDefined();
        expect(mainService).toBeDefined();
    });

    describe('generate MAIN', function () {
        it('mainService is called', function () {
            sinon.spy(mainService, 'getData');
            companyWinlossService.generate({
                level: levels.PRODUCT
            });
            $timeout.flush();
            expect(mainService.getData.calledOnce).toBe(true);
        });
    });
});