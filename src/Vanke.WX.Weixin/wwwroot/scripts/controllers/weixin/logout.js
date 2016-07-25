(function (angular, app) {
    'use strict';

    app.controller('LogoutCtrl', function ($window, api) {
        api.account.weixinLogout(function () {
            $window.location.href = "/weixin/login";
        });
    });

})(angular, app);