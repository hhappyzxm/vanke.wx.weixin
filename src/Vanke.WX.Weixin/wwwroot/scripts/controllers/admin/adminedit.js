(function (angular, app) {
    'use strict';

    app.controller('AdminEditCtrl', function($scope, api, sweetAlert) {
        $scope.data = {};

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.createAdmin($scope.data, function() {

                });
            }
        };
    });

})(angular, app);