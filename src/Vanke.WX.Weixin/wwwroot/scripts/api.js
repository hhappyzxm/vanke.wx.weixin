(function (angular, app) {
    'use strict';

    app.factory('api', function($resource) {
        return {
            /**
             * Account Api
             */
            account: $resource('/api/account', null,
            {
                'login': {
                    method: 'POST',
                    url: '/api/account/login'
                }
            }),

            /**
             * Admin Api
             */
            admin: $resource('/api/admins/:id', { id: '@id' },
            {
                'createAdmin': {
                    method: 'POST',
                    url: '/api/admin'
                }
            })
        };
    });
})(angular, app);