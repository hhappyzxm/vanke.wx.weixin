(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function($scope, $state, api, sweetAlert) {
        $scope.login = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.login($scope.data, function(response) {
                    if(response.Result){
                        $state.go('admin.dashboard');
                    }
                    else{
                        sweetAlert.error('用户名和密码错误');
                    }
                });
            }
        };
    });

})(angular, app);