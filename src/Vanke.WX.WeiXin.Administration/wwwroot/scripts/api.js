(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
        var apiHost = 'http://localhost:54843';

        return {
            /**
             * Admin Api
             */
            staffs: $resource(apiHost + '/api/staffs/:id', { id: '@id' }),

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
            itemBorrow: $resource(null, { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/itemborrow/search?status=:status',
                    isArray: true
                },
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/itemborrow/cancel/:id'
                }
            }),

            /**
             * Item Borrow Api
             */
            externalPersonnelDiningRegister: $resource(null, { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/externalpersonneldiningregister/search?status=:status',
                    isArray: true
                },
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/externalpersonneldiningregister/cancel/:id'
                }
            })
        };
    });
})(angular, app);