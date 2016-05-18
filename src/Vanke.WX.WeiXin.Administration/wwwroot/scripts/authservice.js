(function (angular, app) {
    'use strict';

    app.factory('authService', function ($http, $window) {
        return {
            login: function (loginName, password, sucessFn) {
                var serviceBase = 'http://localhost:54843';

                var data = "grant_type=password&username=" + loginName + "&password=" + password;

                $http.post(serviceBase + '/token', data, {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function(response) {
                    $window.sessionStorage.setItem('access_token', response.access_token);

                    if (sucessFn) sucessFn();
                }).error(function() {
                    logout();
                });
            },

            logout: function () {
                $window.sessionStorage.removeItem('access_token');
            },

            getAccessToken: function () {
                return $window.sessionStorage.getItem('access_token');
            }
        };
    });

})(angular, app);