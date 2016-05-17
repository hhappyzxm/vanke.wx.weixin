(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function ($rootScope,$scope, $state, authService, sweetAlert) {
        $scope.login = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                authService.login($scope.data.LoginName, $scope.data.Password,
                    function() {
                        $state.go('admin.dashboard');
                    });
            }
        };
    });

})(angular, app);