(function (angular, app) {
    'use strict';

    app.controller('LoginCtrl', function($scope, $state, api) {
        $scope.login = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                $state.go('admin.dashboard');
                //api.createAdmin($scope.data, function() {
                //
                //});
            }
        };
    });

})(angular, app);