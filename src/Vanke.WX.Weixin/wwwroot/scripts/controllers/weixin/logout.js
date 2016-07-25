(function (angular, app) {
    'use strict';

    app.controller('LogoutCtrl', function ($scope, $window, api) {
        $scope.logoutSuccessed = false;
        api.account.weixinLogout(function () {
            $scope.logoutSuccessed = true;
        });
    });

})(angular, app);