(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
            return $resource(null,
                null,
                {
                    'login': {
                        method: 'POST',
                        url: '/api/login'
                    },
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