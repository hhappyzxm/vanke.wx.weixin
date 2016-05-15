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
                },
                'logout': {
                    method: 'POST',
                    url: '/api/account/logout'
                }
            }),

            /**
             * Admin Api
             */
            admins: $resource('/api/admins/:id', { id: '@id' },
            {
            }),

            /**
             * Dinner Types Api
             */
            dinnerTypes: $resource('/api/dinnertypes/:id', { id: '@id' },
            {
            }),

            /**
             * Dinner Places Api
             */
            dinnerPlaces: $resource('/api/dinnerplaces/:id', { id: '@id' },
            {
            })
        };
    });
})(angular, app);