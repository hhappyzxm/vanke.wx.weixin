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
        $urlRouterProvider.otherwise("/admin/dashboard");

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
                url: "/adminedit",
                templateUrl: "views/admin/settings/adminedit.html",
                data: {
                    pageTitle: 'Edit Vehicle'
                }
            });
    }

    function configHttpProvider($httpProvider) {
        $httpProvider.interceptors.push(function ($rootScope, $q, $injector, $window) {
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

                'responseError': function (rejection) {
                    var sweetAlert = $injector.get('sweetAlert');

                    if (rejection.status === 401) {
                        sweetAlert.warning('身份认证失败', '请登录后再尝试');
                    }
                    else {
                        var errorData = rejection.data;
                        if (errorData.ErrorType === 'BusinessError') {
                            sweetAlert.warning('警告', errorData.Message);
                        } else {
                            sweetAlert.error('错误', errorData.Message);
                        }
                    }

                    return $q.reject(rejection);
                }
            };
        });
    }

})(angular, app);