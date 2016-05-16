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
            .state("admin", {
                abstract: true,
                url: "/admin",
                templateUrl: "views/admin/common/content.html",
                data: {
                    pageTitle: 'Admin'
                }
            })
            .state("admin.dashboard", {
                url: "/dashboard",
                templateUrl: "views/admin/dashboard.html",
                data: {
                    pageTitle: 'Dashboard'
                }
            })
            .state("admin.admins", {
                url: "/admins",
                templateUrl: "views/admin/settings/admins.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("admin.adminedit", {
                url: "/adminedit?id",
                templateUrl: "views/admin/settings/adminedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("admin.staffs", {
                 url: "/staffs",
                 templateUrl: "views/admin/settings/staffs.html",
                 data: {
                     pageTitle: 'Vehicle Management'
                 }
             })
            .state("admin.staffedit", {
                url: "/staffedit?id",
                templateUrl: "views/admin/settings/staffedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("admin.dinnertypes", {
                url: "/dinnertypes",
                templateUrl: "views/admin/settings/dinnertypes.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("admin.dinnertypeedit", {
                url: "/dinnertypeedit?id",
                templateUrl: "views/admin/settings/dinnertypeedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })
            .state("admin.dinnerplaces", {
                url: "/dinnerplaces",
                templateUrl: "views/admin/settings/dinnerplaces.html",
                data: {
                    pageTitle: 'Vehicle Management'
                }
            })
            .state("admin.dinnerplaceedit", {
                url: "/dinnerplaceedit?id",
                templateUrl: "views/admin/settings/dinnerplaceedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            })

            // Common views
            .state('common', {
                abstract: true,
                url: "/common",
                templateUrl: "views/admin/common/content_empty.html",
                data: {
                    pageTitle: 'Common'
                }
            })
            .state('common.login', {
                url: "/login",
                templateUrl: "views/admin/common_app/login.html",
                data: {
                    pageTitle: 'Login page',
                    specialClass: 'blank'
                }
            });
    }

    function configHttpProvider($httpProvider) {
        $httpProvider.interceptors.push(function ($rootScope, $q, $injector) {
            return {
                //'request': function (config) {
                //    //config.headers['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';

                //    return config;
                //},

                //'requestError': function (rejection) {
                //    return $q.reject(rejection);
                //},

                //'response': function (response) {
                //    return response;
                //},

                'responseError': function(rejection) {
                    var sweetAlert = $injector.get('sweetAlert');
                    var $state = $injector.get('$state');

                    if (rejection.status === 401) {
                        $state.go('common.login');
                    }
                    else if (rejection.status === 404) {
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