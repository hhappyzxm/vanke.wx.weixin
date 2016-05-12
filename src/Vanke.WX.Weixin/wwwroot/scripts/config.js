(function (angular) {
    'use strict';

function configState($stateProvider, $urlRouterProvider, $compileProvider) {

    // Optimize load start with remove binding information inside the DOM element
    $compileProvider.debugInfoEnabled(true);

    // Set default state
    $urlRouterProvider.otherwise("/admin/dashboard");

    $stateProvider

        // Customer
        .state("admin", {
            abstract: true,
            url: "/admin",
            templateUrl: "views/admin/common/content.html",
            data: {
                pageTitle: 'Admin'
            }
        })
        .state("admin.dashboard", {
            url: "/dashboard",
            templateUrl: "views/admin/dashboard.html",
            data: {
                pageTitle: 'Dashboard'
            }
        })
        .state("admin.admins", {
            url: "/admins",
            templateUrl: "views/admin/settings/admins.html",
            data: {
                pageTitle: 'Vehicle Management'
            }
        })
        .state("admin.adminedit", {
            url: "/adminedit",
            templateUrl: "views/admin/settings/adminedit.html",
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