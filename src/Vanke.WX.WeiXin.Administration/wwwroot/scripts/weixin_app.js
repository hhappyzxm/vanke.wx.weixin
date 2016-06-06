(function (angular, document) {
    'use strict';

    window.app = angular.module('app', [
        'ngResource', // Angular resource
    ]);

    // Start angular by manual
    angular.element(document).ready(function () {
        angular.bootstrap(document, ['app']);
    });
})(angular, document);
