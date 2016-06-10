(function (angular, document) {
    'use strict';

    window.app = angular.module('app', [
        'ngResource', // Angular resource
        'ui.router', // Angular flexible routing
        'ui.bootstrap', // AngularJS native directives for Bootstrap
        'angular-flot', // Flot chart
        'datatables', // Angular datatables plugin
        'datatables.buttons',
        'ngFileUpload'
    ]);

    // Start angular by manual
    angular.element(document).ready(function () {
        angular.bootstrap(document, ['app']);
    });
})(angular, document);
