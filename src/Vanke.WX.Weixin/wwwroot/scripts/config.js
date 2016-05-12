(function (angular) {
    'use strict';

function configState($stateProvider, $urlRouterProvider, $compileProvider) {

    // Optimize load start with remove binding information inside the DOM element
    $compileProvider.debugInfoEnabled(true);

    // Set default state
    $urlRouterProvider.otherwise("/customer/dashboard");

    $stateProvider

        // Customer
        .state("admin", {
            abstract: true,
            url: "/admin",
            templateUrl: "views/common/content.html",
            data: {
                pageTitle: 'Customer'
            }
        })
        .state("customer.dashboard", {
            url: "/dashboard",
            templateUrl: "views/customer/index.html",
            data: {
                pageTitle: 'Dashboard'
            }
        })
        .state("customer.vehicles", {
            url: "/vehicles",
            templateUrl: "views/customer/fleetcore/vehicles.html",
            data: {
                pageTitle: 'Vehicle Management'
            }
        })
        .state("customer.vehicleedit", {
            url: "/vehicleedit",
            templateUrl: "views/customer/fleetcore/vehicleedit.html",
            data: {
                pageTitle: 'Edit Vehicle'
            }
        })
}

angular
    .module('architecture')
    .config(configState)
    .run(function ($rootScope, $state) {
        $rootScope.$state = $state;
    });

})(angular);