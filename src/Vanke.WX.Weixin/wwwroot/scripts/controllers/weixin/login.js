(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function ($scope, $location, $window, api) {
        $scope.login = function(form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                var parameter = $location.search();
                api.account.weixinLogin({ LoginName: $scope.data.LoginName, Password: $scope.data.Password, WeixinOpenId: parameter.openid }, function (result) {
                    if (!result.IsAuthed) {
                        sweetAlert.error('用户名和密码错误');
                    } else {
                        $window.location.href = parameter.redirect_uri;
                    }
                });
                
            };
        }
    });

})(angular, app);