(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function($rootScope, $scope, $state, api, sweetAlert, authService) {
        api.account.logout();
        authService.logout();

        $scope.login = function(form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.account.login({ LoginName: $scope.data.LoginName, Password: $scope.data.Password }, function (result) {
                    if (!result.IsAuthed) {
                        sweetAlert.error('用户名和密码错误');
                    } else {
                        authService.setUserName(result.User.UserName);
                        $state.go('settings.staffs');
                    }
                });
            };
        }
    });

})(angular, app);