(function (angular) {
    'use strict';

    angular
        .module('architecture')
        .factory('api', function ($resource) {
        return $resource(null,
                    null,
                    {
                        'getCustomerDashboard': {
                            method: 'GET',
                            url: 'http://localhost:56286/api/dashboard'
                        }, // Get application
                    });
    });
})(angular);