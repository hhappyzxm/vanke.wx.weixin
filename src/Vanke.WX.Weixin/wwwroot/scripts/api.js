(function (angular, app) {
    'use strict';

    app.factory('api', function ($resource) {
        var apiHost = '';  //var apiHost = 'http://localhost:54843';

        return {
            /**
             * Account Api
             */
            account: $resource(null, null, {
                'login': {
                    method: 'POST',
                    url: apiHost + '/api/account/login'
                },
                'logout': {
                    method: 'POST',
                    url: apiHost + '/api/account/logout'
                },
                'weixinLogin': {
                    method: 'POST',
                    url: apiHost + '/api/account/weixinlogin'
                },
                'getUserInfo': {
                    method: 'POST',
                    url: apiHost + '/api/account/getuserinfo'
                }
            }),

            /**
             * Admin Api
             */
            staffs: $resource(apiHost + '/api/staffs/:id', { id: '@id' }, {
                'import': {
                    method: 'POST',
                    url: apiHost + '/api/staffs/import',
                    isArray: false
                },
                'search': {
                    method: 'POST',
                    url: apiHost + '/api/staffs/search',
                    isArray:true
                }
            }),

            /**
             * Dinner Types Api
             */
            dinnerTypes: $resource(apiHost + '/api/dinnertypes/:id', { id: '@id' }),

            /**
             * Meal Types Api
             */
            mealTypes: $resource(apiHost + '/api/mealtypes/:id', { id: '@id' }),

            /**
             * Dinner Places Api
             */
            dinnerPlaces: $resource(apiHost + '/api/dinnerplaces/:id', { id: '@id' }),

            /**
             * Items Api
             */
            items: $resource(apiHost + '/api/items/:id', { id: '@id' }),

            /**
             * Item Storage Area  Api
             */
            itemStorageAreas: $resource(apiHost + '/api/itemstorageareas/:id', { id: '@id' }),

            /**
             * Settings  Api
             */
            settings: $resource(apiHost + '/api/settings'),

            /**
             * Item Storage Place  Api
             */
            itemStoragePlaces: $resource(apiHost + '/api/itemstorageplaces/:id', { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/itemstorageplaces/search?areaId=:areaId',
                    isArray: true
                },
            }),

            /**
             * Item Borrow Api
             */
            itemBorrow: $resource(apiHost + '/api/itemborrow/:id', { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/itemborrow/search?status=:status',
                    isArray: true
                },
                'getOwnHistories': {
                    method: 'GET',
                    url: apiHost + '/api/itemborrow/getownhistories',
                    isArray: true
                },
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/itemborrow/cancel/:id'
                },
                'return': {
                    method: 'POST',
                    url: apiHost + '/api/itemborrow/return/:id'
                }
            }),

            /**
             * Idle Assets Api
             */
            idleAssets: $resource(apiHost + '/api/idleassets/:id', { id: '@id' }, {
                'import': {
                    method: 'POST',
                    url: apiHost + '/api/idleassets/import',
                    isArray: true
                }
            }),

            /**
             * Dinner Register Api
             */
            dinnerRegister: $resource(apiHost + '/api/dinnerregister/:id', { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/dinnerregister/search?status=:status',
                    isArray: true
                },
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/dinnerregister/cancel/:id'
                },
                'getOwnHistories': {
                    method: 'GET',
                    url: apiHost + '/api/dinnerregister/getownhistories',
                    isArray: true
                },
                'read': {
                    method: 'POST',
                    url: apiHost + '/api/dinnerregister/read/:id'
                }
            }),

            /**
             * External Personnel Dining Register Api
             */
            externalPersonnelDiningRegister: $resource(apiHost + '/api/externalpersonneldiningregister/:id', { id: '@id' }, {
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/externalpersonneldiningregister/search?status=:status',
                    isArray: true
                },
                'cancel': {
                    method: 'POST',
                    url: apiHost + '/api/externalpersonneldiningregister/cancel/:id'
                },
                'getOwnHistories': {
                    method: 'GET',
                    url: apiHost + '/api/externalpersonneldiningregister/getownhistories',
                    isArray: true
                }
            }),

            /**
             * Designated Drivers Api
             */
            designatedDrivers: $resource(apiHost + '/api/designateddrivers/:id', { id: '@id' }),

            /**
             * Surrounding Service Api
             */
            surroundingServices: $resource(apiHost + '/api/surroundingservices/:id', { id: '@id' }),

            /**
             * Employ Discounts Api
             */
            employeeDiscounts: $resource(apiHost + '/api/employeediscounts/:id', { id: '@id' }, {
                'getTypes': {
                    method: 'GET',
                    url: apiHost + '/api/employeediscounts/gettypes',
                    isArray: true
                },
                'search': {
                    method: 'GET',
                    url: apiHost + '/api/employeediscounts/search?type=:type',
                    isArray: true
                }
            })
        };
    });
})(angular, app);