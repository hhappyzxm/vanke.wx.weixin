(function (angular, app) {
    'use strict';

    app.controller('ExternalPersonnelDiningRegisterCtrl', function ($scope, $window, api) {
        api.mealTypes.query(function (result) {
            $scope.mealTypes = result;
        });

        api.externalPersonnelDiningRegister.getOwnHistories(function (result) {
            $scope.hasHistories = result.length > 0;
        });

        $scope.save = function (form) {
            form.$setSubmitted(true);

            if (form.$valid) {
                api.externalPersonnelDiningRegister.save($scope.data, function () {
                    $window.location.href = "/weixin/externalpersonneldiningregisterhistories";
                });
            }
        };
    });

})(angular, window.app);