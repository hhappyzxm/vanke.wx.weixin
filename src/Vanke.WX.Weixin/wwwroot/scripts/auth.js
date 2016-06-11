(function (angular, app) {
    'use strict';

    app.factory('authService', function ($http, $window) {
        var instance =  {
            login: function(loginName, password, sucessFn) {
                var serviceBase = 'http://localhost:54843';

                var data = "grant_type=password&username=" + loginName + "&password=" + password;

                // 先从服务器取得Access-Token
                $http.post(serviceBase + '/token', data, {
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                }).success(function (response) {
                    $window.sessionStorage.setItem('access-token', response.access_token);

                    // 获取登录用户信息
                    $http.get(serviceBase + '/api/account').success(
                        function (response) {
                            $window.sessionStorage.setItem('access-username', response.UserName);

                            if (sucessFn) sucessFn();
                        }
                    );
                }).error(function() {
                    instance.logout();
                });
            },

            logout: function() {
                $window.sessionStorage.removeItem('access-token');
                $window.sessionStorage.removeItem('access-username');
            },

            isAuth: function() {
                return $window.sessionStorage.getItem('access-token') != null; 
            },

            getAccessToken: function() {
                return $window.sessionStorage.getItem('access-token');
            },

            getUserName: function() {
                return $window.sessionStorage.getItem('access-username');
            },

            setUserName: function(value) {
                $window.sessionStorage.setItem('access-username', value);
            }
        };

        return instance;
    });

})(angular, app);