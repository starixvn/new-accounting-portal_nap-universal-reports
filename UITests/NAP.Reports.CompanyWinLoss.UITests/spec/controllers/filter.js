/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular-route.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/scripts/angular-mocks.js" />
/// <reference path="../../scripts/jasmine.js" />
/// <reference path="../../scripts/jasmine-html.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/app-scripts/app.js" />
/// <reference path="../../../../nap.reports.companywinloss.site/app-scripts/controllers/filter.js" />

'use strict';

describe('Controller: FilterCtrl', function () {

  // load the controller's module
  beforeEach(module('companyWinlossApp'));

  var FilterCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    FilterCtrl = $controller('FilterCtrl', {
      $scope: scope      
    });
  }));

  it('after the form is loaded, the button export and expand are disable', function () {
      expect(scope.disableExport).toBe(true);
      expect(scope.disableExpand).toBe(true);
  });

  it('after the button generate is clicked, the button export and expand are enable', function () {
      scope.generate();
      expect(scope.disableExport).toBe(false);
      expect(scope.disableExpand).toBe(false);
  });

  it('after the button today is clicked, the button export and expand are enable', function () {
      scope.generate();
      expect(scope.disableExport).toBe(false);
      expect(scope.disableExpand).toBe(false);
  });

  it('after the button yesterday is clicked, the button export and expand are enable', function () {
      scope.generate();
      expect(scope.disableExport).toBe(false);
      expect(scope.disableExpand).toBe(false);
  });
});
