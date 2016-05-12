(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
            return $resource(null,
                null,
                {
                    'getCustomerDashboard': {
                        method: 'GET',
                        url: '/api/dashboard'
                    },
                    'createAdmin': {
                        method: 'POST',
                        url: '/api/admin'
                    }
                });
        });
})(angular, app);