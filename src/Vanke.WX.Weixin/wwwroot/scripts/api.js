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
                        url: '/api/dashboard'
                    },
                    'createAdmin': {
                        method: 'PUT',
                        url: '/api/admin'
                    }
                });
        });
})(angular);