(function (angular, app) {
    'use strict';

    app.factory('authService', function ($http) {
        var authData = {
            isAuthenticated: false,
            token: null
        };
        
        return {
            login: function (loginName, password, sucessFn) {
                var serviceBase = 'http://localhost:54843';

                var data = "grant_type=password&username=" + loginName + "&password=" + password;

                $http.post(serviceBase + '/token', data, {
                    headers:
                    { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function(response) {

                    authData.isAuthenticated = true;
                    authData.token = response.access_token;

                    if (sucessFn) sucessFn();
                });
            },

            logout: function () {
                authData.isAuthenticated = false;
                authData.token = null;
            },

            authentication: authData
        };
    });

})(angular, app);