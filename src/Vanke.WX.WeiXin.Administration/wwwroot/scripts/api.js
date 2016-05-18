(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
        var apiHost = 'http://localhost:54843';

        return {
            /**
             * Admin Api
             */
            admins: $resource(apiHost + '/api/admins/:id', { id: '@id' }),

            /**
             * Dinner Types Api
             */
            dinnerTypes: $resource(apiHost + '/api/dinnertypes/:id', { id: '@id' }),

            /**
             * Dinner Places Api
             */
            dinnerPlaces: $resource(apiHost + '/api/dinnerplaces/:id', { id: '@id' }),

            /**
             * Items Api
             */
            items: $resource(apiHost + '/api/items/:id', { id: '@id' }),

            /**
             * Item Borrow Api
             */
            itemBorrow: $resource(null, null, {
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/itemborrow/cancel'
                }
            })
        };
    });
})(angular, app);