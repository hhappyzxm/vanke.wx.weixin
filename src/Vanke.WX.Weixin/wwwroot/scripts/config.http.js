(function (angular, app) {
    'use strict';

    app
        .config(configHttpProvider);

    function configHttpProvider($httpProvider) {
        //$httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
        $httpProvider.interceptors.push(function ($rootScope, $q, $injector, $window) {
            return {
                //'request': function (config) {
                //    var authService = $injector.get('authService');
                //    config.headers = config.headers || {};

                //    if (authService.isAuth()) {
                //        config.headers.Authorization = 'Bearer ' + authService.getAccessToken();
                //    }

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
                    
                    if (rejection.status === 400 &&
                        !angular.isUndefined(rejection.data) &&
                        !angular.isUndefined(rejection.data.error) &&
                        rejection.data.error === 'auth_invalid_grant') {
                        sweetAlert.error('用户名和密码错误');
                    } else if (rejection.status === 401) {
                        var $state = $injector.get('$state');
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