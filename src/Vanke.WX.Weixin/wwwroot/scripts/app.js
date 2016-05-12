(function(angular) {
    'use strict';

    window.app = angular.module('architecture', [
        'ngResource', // Angular resource
        'ui.router', // Angular flexible routing
        'ui.bootstrap', // AngularJS native directives for Bootstrap
        'angular-flot', // Flot chart
        'datatables', // Angular datatables plugin
        'datatables.buttons'
    ]);
})(angular);
