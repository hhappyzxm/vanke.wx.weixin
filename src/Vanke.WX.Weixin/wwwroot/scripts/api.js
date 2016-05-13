(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
            return $resource(null,
                null,
                {
                    'login': {
                        method: 'POST',
                        url: '/api/account/login'
                    },
                    'getCustomerDashboard': {
                        method: 'GET',
                        url: '/api/dashboard'
                    },
                    'getAdmins': {
                        method: 'GET',
                        url: '/api/admin',
                        isArray: true
                    },
                    'createAdmin': {
                        method: 'POST',
                        url: '/api/admin'
                    }
                });
        });
})(angular, app);