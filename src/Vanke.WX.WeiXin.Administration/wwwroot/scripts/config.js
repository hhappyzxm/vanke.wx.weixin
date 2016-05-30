(function (angular, app) {
    'use strict';

    app
        .config(configState)
        .config(configHttpProvider)
        .run(function ($rootScope, $state) {
            $rootScope.$state = $state;
        });

    function configState($stateProvider, $urlRouterProvider, $compileProvider) {

        // Optimize load start with remove binding information inside the DOM element
        $compileProvider.debugInfoEnabled(true);

        // Set default state
        $urlRouterProvider.otherwise("/common/login");

        $stateProvider
            .state("settings", {
                abstract: true,
                url: "/settings",
                templateUrl: "views/common/content.html",
                data: {
                    pageTitle: 'Admin'
                }
            })
            .state("settings.dashboard", {
                url: "/dashboard",
                templateUrl: "views/dashboard.html",
                data: {
                    pageTitle: 'Dashboard'
                }
            })
            .state("settings.staffs", {
                 url: "/staffs",
                 templateUrl: "views/settings/staffs.html",
                 data: {
                     pageTitle: 'Vehicle Management'
                 }
             })
            .state("settings.staffedit", {
                url: "/staffedit?id",
                templateUrl: "views/settings/staffedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("settings.dinnertypes", {
                url: "/dinnertypes",
                templateUrl: "views/settings/dinnertypes.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("settings.dinnertypeedit", {
                url: "/dinnertypeedit?id",
                templateUrl: "views/settings/dinnertypeedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("settings.dinnerplaces", {
                url: "/dinnerplaces",
                templateUrl: "views/settings/dinnerplaces.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("settings.dinnerplaceedit", {
                url: "/dinnerplaceedit?id",
                templateUrl: "views/settings/dinnerplaceedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("settings.items", {
                url: "/items",
                templateUrl: "views/settings/items.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("settings.itemedit", {
                url: "/itemedit?id",
                templateUrl: "views/settings/itemedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })

            // 行政服务
            .state('service', {
                abstract: true,
                url: "/service",
                templateUrl: "views/common/content.html",
                data: {
                    pageTitle: 'Common'
                }
            })
            .state('service.itemborrow', {
                url: "/itemborrow",
                templateUrl: "views/services/itemborrowhistories.html",
                data: {
                    pageTitle: 'Login page',
                    specialClass: 'blank'
                }
            })
            .state('service.dinnerregister', {
                url: "/dinnerregister",
                templateUrl: "views/services/dinnerregisteredhistories.html",
                data: {
                    pageTitle: 'Login page',
                    specialClass: 'blank'
                }
            })
            .state('service.externalpersonneldiningregister', {
                url: "/externalpersonneldiningregister",
                templateUrl: "views/services/externalpersonneldiningregisterhistories.html",
                data: {
                    pageTitle: 'Login page',
                    specialClass: 'blank'
                }
            })

            // Common views
            .state('common', {
                abstract: true,
                url: "/common",
                templateUrl: "views/common/content_empty.html",
                data: {
                    pageTitle: 'Common'
                }
            })
            .state('common.login', {
                url: "/login",
                templateUrl: "views/common_app/login.html",
                data: {
                    pageTitle: 'Login page',
                    specialClass: 'blank'
                }
            });
    }

    function configHttpProvider($httpProvider) {
        //$httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
        $httpProvider.interceptors.push(function ($rootScope, $q, $injector, $window) {
            return {
                'request': function (config) {
                    var authService = $injector.get('authService');
                    config.headers = config.headers || {};

                    if (authService.getAccessToken()) {
                        config.headers.Authorization = 'Bearer ' + authService.getAccessToken();
                    }

                    return config;
                },

                //'requestError': function (rejection) {
                //    return $q.reject(rejection);
                //},

                //'response': function (response) {
                //    return response;
                //},

                'responseError': function(rejection) {
                    var sweetAlert = $injector.get('sweetAlert');
                    var $state = $injector.get('$state');

                    if (rejection.status === 400 &&
                        !angular.isUndefined(rejection.data) &&
                        !angular.isUndefined(rejection.data.error) &&
                        rejection.data.error === 'auth_invalid_grant') {
                        sweetAlert.error('用户名和密码错误');
                    } else if (rejection.status === 401) {
                        $state.go('common.login');
                    } else if (rejection.status === 404) {
                        sweetAlert.error('Not Found ' + rejection.config.url);
                    } else {
                        var errorData = rejection.data;
                        if (errorData.ErrorType === 'BusinessError') {
                            sweetAlert.warning(errorData.Message);
                        } else {
                            sweetAlert.error(errorData.Message);
                        }
                    }

                    return $q.reject(rejection);
                }
            };
        });
    }

})(angular, app);